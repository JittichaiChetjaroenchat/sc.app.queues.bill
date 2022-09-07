using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SC.App.Queues.Bill.Business.Enums;
using SC.App.Queues.Bill.Business.Helpers;
using SC.App.Queues.Bill.Business.Managers.Interface;
using SC.App.Queues.Bill.Business.Order.Enums;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Client.MessagingService;
using SC.App.Queues.Bill.Common.Constants;
using SC.App.Queues.Bill.Common.Exceptions;
using SC.App.Queues.Bill.Lib.Extensions;
using SC.App.Queues.Bill.Queue.Models.Messaging;
using Serilog;

namespace SC.App.Queues.Bill.Business.Managers
{
    public class BillProcessManager : IBillProcessManager
    {
        private readonly IBillRepository _billRepository;
        private readonly IBillNotificationRepository _billNotificationRepository;
        private readonly IBillStatusRepository _billStatusRepository;

        private readonly Area.Repositories.Interface.IAreaRepository _areaRepository;
        private readonly Customer.Repositories.Interface.ICustomerRepository _customerRepository;
        private readonly Inventory.Repositories.Interface.IProductRepository _productRepository;
        private readonly Order.Repositories.Interface.IOrderRepository _orderRepository;
        private readonly Order.Repositories.Interface.IOrderStatusRepository _orderStatusRepository;
        private readonly Setting.Repositories.Interface.IResponseMessageRepository _responseMessageRepository;
        private readonly Setting.Repositories.Interface.IPreferencesRepository _preferencesRepository;
        private readonly Streaming.Repositories.Interface.ILiveOptionRepository _liveOptionRepository;
        private readonly Streaming.Repositories.Interface.IOfferingRepository _offeringRepository;

        private readonly Customer.Managers.Interface.ICustomerManager _customerManager;
        private readonly Inventory.Managers.Interface.IProductManager _productManager;
        private readonly Order.Managers.Interface.IOrderManager _orderManager;
        private readonly Streaming.Managers.Interface.IBookingUnlockManager _bookingUnlockManager;
        
        private readonly Client.MessagingService.IMessagingServiceManager _messagingServiceManager;
        private readonly Queue.Managers.Interface.IQueueManager _queueManager;

        private readonly IConfiguration _configuration;

        public BillProcessManager(
            IBillRepository billRepository,
            IBillNotificationRepository billNotificationRepository,
            IBillStatusRepository billStatusRepository,

            Area.Repositories.Interface.IAreaRepository areaRepository,
            Customer.Repositories.Interface.ICustomerRepository customerRepository,
            Inventory.Repositories.Interface.IProductRepository productRepository,
            Order.Repositories.Interface.IOrderRepository orderRepository,
            Order.Repositories.Interface.IOrderStatusRepository orderStatusRepository,
            Setting.Repositories.Interface.IResponseMessageRepository responseMessageRepository,
            Setting.Repositories.Interface.IPreferencesRepository preferencesRepository,
            Streaming.Repositories.Interface.ILiveOptionRepository liveOptionRepository,
            Streaming.Repositories.Interface.IOfferingRepository offeringRepository,

            Customer.Managers.Interface.ICustomerManager customerManager,
            Inventory.Managers.Interface.IProductManager productManager,
            Order.Managers.Interface.IOrderManager orderManager,
            Streaming.Managers.Interface.IBookingUnlockManager bookingUnlockManager,

            Client.MessagingService.IMessagingServiceManager messagingServiceManager,
            Queue.Managers.Interface.IQueueManager queueManager,

            IConfiguration configuration)
        {
            _billRepository = billRepository;
            _billNotificationRepository = billNotificationRepository;
            _billStatusRepository = billStatusRepository;

            _areaRepository = areaRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _orderStatusRepository = orderStatusRepository;
            _responseMessageRepository = responseMessageRepository;
            _preferencesRepository = preferencesRepository;
            _liveOptionRepository = liveOptionRepository;
            _offeringRepository = offeringRepository;

            _customerManager = customerManager;
            _productManager = productManager;
            _orderManager = orderManager;
            _bookingUnlockManager = bookingUnlockManager;

            _messagingServiceManager = messagingServiceManager;
            _queueManager = queueManager;

            _configuration = configuration;
        }

        public async Task ConfirmBillAsync(Guid billId)
        {
            try
            {
                // Get bill
                var bill = _billRepository.GetById(billId);
                if (bill == null)
                {
                    throw new SkipProcessException("No bill found.");
                }

                // Update stock
                await _productManager.UpdateStockAsync(bill.Id);

                // Confirm order
                await _orderManager.ConfirmOrderAsync(bill.Id);

                // Update customer to regular
                await _customerManager.SetToRegularAsync(bill.BillRecipient.CustomerId);

                // Update bill to confirm
                var billStatus = _billStatusRepository.GetByCode(EnumBillStatus.Confirmed.GetDescription());

                bill.BillStatusId = billStatus.Id;
                bill.UpdatedBy = Guid.Empty;
                bill.UpdatedOn = DateTime.Now;

                _billRepository.Update(bill);

                // Unlock booking
                await _bookingUnlockManager.UnlockBooking(bill.ChannelId, bill.BillRecipient.AliasName);

                // Send response message for confirm bill
                await NotifyBillConfirmAsync(billId);
            }
            catch
            {
                throw;
            }
        }

        public async Task CancelBillAsync(Guid billId)
        {
            try
            {
                // Get bill
                var bill = _billRepository.GetById(billId);
                if (bill == null)
                {
                    throw new SkipProcessException("No bill found.");
                }

                // Check bill is ended
                if (BillHelper.IsEndState(bill))
                {
                    throw new SkipProcessException("Bill is ended.");
                }

                // Check bill is in-process
                if (BillHelper.IsInProcess(bill))
                {
                    throw new SkipProcessException("Bill is in-process.");
                }

                // Update bill's status
                var billStatus = _billStatusRepository.GetByCode(EnumBillStatus.Cancelled.GetDescription());

                bill.BillStatusId = billStatus.Id;
                bill.UpdatedBy = Guid.Empty;
                bill.UpdatedOn = DateTime.Now;

                _billRepository.Update(bill);

                // Update order's status
                var orders = _orderRepository.GetByBillId(bill.Id);
                if (!orders.IsEmpty())
                {
                    var orderStatus = _orderStatusRepository.GetByCode(EnumOrderStatus.Cancelled.GetDescription());
                    foreach (var order in orders)
                    {
                        order.OrderStatusId = orderStatus.Id;
                        order.UpdatedBy = Guid.Empty;
                        order.UpdatedOn = DateTime.Now;
                    }

                    _orderRepository.Updates(orders);
                }

                // Restore remaining to offering (stremiing)
                if (!orders.IsEmpty())
                {
                    foreach (var order in orders)
                    {
                        // Check order on live stream
                        if (order.LiveId.HasValue)
                        {
                            var offering = _offeringRepository.GetOfferingByFilter(order.LiveId.Value, order.ProductId);
                            if (offering != null)
                            {
                                // Update remaining
                                offering.Remaining = offering.Remaining + order.Amount;

                                _offeringRepository.Update(offering);
                            }
                        }
                    }
                }

                // Send response message
                await NotifyBillCancelAsync(billId);
            }
            catch
            {
                throw;
            }
        }

        public async Task NotifyBillConfirmAsync(Guid billId)
        {
            try
            {
                // Get bill
                var bill = _billRepository.GetById(billId);
                if (bill == null)
                {
                    throw new SkipProcessException("No bill found.");
                }

                if (bill.BillNotification == null)
                {
                    throw new SkipProcessException("No bill's notification found.");
                }

                if (bill.BillRecipient == null)
                {
                    throw new SkipProcessException("No bill's recipient found.");
                }

                if (bill.BillRecipient.BillRecipientContact == null)
                {
                    throw new SkipProcessException("No bill recipient's contact found.");
                }

                // Get response message
                var responseMessage = _responseMessageRepository.GetByChannelId(bill.ChannelId);
                if (responseMessage == null)
                {
                    throw new SkipProcessException("No response's message found.");
                }

                var responseMessageEnabled = ResponseMessageHelper.GetResponseMessageEnabled(EnumResponseMessageType.NotifyBillConfirm, responseMessage);
                if (!responseMessageEnabled)
                {
                    throw new SkipProcessException("Response's message diabled.");
                }

                // Get area
                var areaId = bill.BillRecipient.BillRecipientContact.AreaId.HasValue ? bill.BillRecipient.BillRecipientContact.AreaId.Value : Guid.Empty;
                var area = _areaRepository.GetById(areaId);

                // Get customer
                var customerId = bill.BillRecipient.CustomerId;
                var customer = _customerRepository.GetById(customerId);
                if (customer == null)
                {
                    throw new SkipProcessException("No customer found.");
                }

                if (customer.CustomerFacebook == null)
                {
                    throw new SkipProcessException("No customer's facebook found.");
                }

                // Get order
                var orders = _orderRepository.GetByBillIdWithStatus(bill.Id, EnumOrderStatus.Confirm);

                // Get product
                var productIds = orders
                    .Select(x => x.ProductId)
                    .ToArray();
                var products = _productRepository.GetByIds(productIds);

                var template = ResponseMessageHelper.GetResponseMessage(EnumResponseMessageType.NotifyBillConfirm, responseMessage);
                var text = ResponseMessageHelper.NotifyConfirmBill(template, bill, orders, products, bill.BillRecipient.BillRecipientContact, area);
                if (text.Contains("{delivery_address}"))
                {
                    Log.Information("========== Notify to confirm bill. ==========");
                    Log.Information("Bill: {billId}", bill.Id);
                    Log.Information("Customer: {customerName} ({customerId})", customer.Name, customer.Id);

                    if (bill?.BillRecipient?.BillRecipientContact != null)
                    {
                        Log.Information("Address: {address}", bill?.BillRecipient?.BillRecipientContact?.Address);
                    }
                    else
                    {
                        Log.Information("Address: NO ADDRESS");
                    }

                    if (area != null)
                    {
                        Log.Information("Area: {subDistrict} {district} {province} {postalCode}", area.SubDistrict, area.District, area.Province, area.PostalCode);
                    }
                    else
                    {
                        Log.Information("Area: NO AREA");
                    }

                    Log.Information("Template: {template}", template);
                    Log.Information("Text: {text}", text);
                    Log.Information("=============================================");
                }

                // Notify
                var sender = new ChatSender { Id = bill.ChannelId.ToString() };
                var recipient = new ChatRecipient { Id = customer.CustomerFacebook.FacebookId };
                var content = new ChatContent
                {
                    Text = text
                };

                await _queueManager.ReplyChatAsync(sender, recipient, content);
            }
            catch (SkipProcessException)
            {
            }
            catch
            {
                throw;
            }
        }

        public async Task NotifyBillBeforeCancelAsync(Guid billId)
        {
            try
            {
                // Get bill
                var bill = _billRepository.GetById(billId);
                if (bill == null)
                {
                    throw new SkipProcessException("No bill found.");
                }

                if (bill.BillNotification == null)
                {
                    throw new SkipProcessException("No bill's notification found.");
                }

                if (bill.BillRecipient == null)
                {
                    throw new SkipProcessException("No bill's recipient found.");
                }

                // Check bill is ended
                if (BillHelper.IsEndState(bill))
                {
                    throw new SkipProcessException("Bill is ended.");
                }

                // Check bill is in-process
                if (BillHelper.IsInProcess(bill))
                {
                    throw new SkipProcessException("Bill is in-process.");
                }

                // Get response message
                var responseMessage = _responseMessageRepository.GetByChannelId(bill.ChannelId);
                if (responseMessage == null)
                {
                    throw new SkipProcessException("No response's message found.");
                }

                var responseMessageEnabled = ResponseMessageHelper.GetResponseMessageEnabled(EnumResponseMessageType.NotifyBillBeforeCancel, responseMessage);
                if (!responseMessageEnabled)
                {
                    throw new SkipProcessException("Response's message diabled.");
                }

                // Get cancel bill's time
                var cancelBillTime = GetCancelTime(bill.Id);

                // Get customer
                var customerId = bill.BillRecipient.CustomerId;
                var customer = _customerRepository.GetById(customerId);
                if (customer == null)
                {
                    throw new SkipProcessException("No customer found.");
                }

                if (customer.CustomerFacebook == null)
                {
                    throw new SkipProcessException("No customer's facebook found.");
                }

                // Notify
                var sendMessagePayload = new Services.Messaging.Client.SendMessage
                {
                    Type = Services.Messaging.Client.EnumMessageType.Chat,
                    Provider = Services.Messaging.Client.EnumMessageProvider.Facebook,
                    Sender = new Services.Messaging.Client.SendMessageSender { Id = bill.ChannelId.ToString() },
                    Recipient = new Services.Messaging.Client.SendMessageRecipient { Id = customer.CustomerFacebook.FacebookId },
                    Content = new Services.Messaging.Client.SendMessageContent
                    {
                        Text = ResponseMessageHelper.NotifyBeforeCancelBill(responseMessage.BillNotifyBeforeCancelMessage, bill, cancelBillTime)
                    }
                };
                var sendMessageResponse = await _messagingServiceManager.SendAsync(sendMessagePayload);
                var canNotify = MessagingServiceClientHelper.IsSuccess(sendMessageResponse);

                // Update bill's notification
                var billNotification = _billNotificationRepository.GetByBillId(bill.Id);
                if (billNotification != null)
                {
                    billNotification.IsBeforeCancelNotified = true;
                    billNotification.BeforeCancelNotifiedOn = DateTime.Now;
                    billNotification.CanNotifyBeforeCancel = canNotify;
                    billNotification.UpdatedBy = Guid.Empty;
                    billNotification.UpdatedOn = DateTime.Now;

                    _billNotificationRepository.Update(billNotification);
                }
            }
            catch (SkipProcessException)
            {
            }
            catch
            {
                throw;
            }
        }

        public async Task NotifyBillCancelAsync(Guid billId)
        {
            try
            {
                // Get bill
                var bill = _billRepository.GetById(billId);
                if (bill == null)
                {
                    throw new SkipProcessException("No bill found.");
                }

                if (bill.BillNotification == null)
                {
                    throw new SkipProcessException("No bill's notification found.");
                }

                if (bill.BillRecipient == null)
                {
                    throw new SkipProcessException("No bill's recipient found.");
                }

                // Check bill is pending
                if (BillHelper.IsPending(bill))
                {
                    throw new SkipProcessException("Bill is pending.");
                }

                // Get response message
                var responseMessage = _responseMessageRepository.GetByChannelId(bill.ChannelId);
                if (responseMessage == null)
                {
                    throw new SkipProcessException("No response's message found.");
                }

                var responseMessageEnabled = ResponseMessageHelper.GetResponseMessageEnabled(EnumResponseMessageType.NotifyBillCancel, responseMessage);
                if (!responseMessageEnabled)
                {
                    throw new SkipProcessException("Response's message diabled.");
                }

                // Get customer
                var customerId = bill.BillRecipient.CustomerId;
                var customer = _customerRepository.GetById(customerId);
                if (customer == null)
                {
                    throw new SkipProcessException("No customer found.");
                }

                if (customer.CustomerFacebook == null)
                {
                    throw new SkipProcessException("No customer's facebook found.");
                }

                // Notify
                var sendMessagePayload = new Services.Messaging.Client.SendMessage
                {
                    Type = Services.Messaging.Client.EnumMessageType.Chat,
                    Provider = Services.Messaging.Client.EnumMessageProvider.Facebook,
                    Sender = new Services.Messaging.Client.SendMessageSender { Id = bill.ChannelId.ToString() },
                    Recipient = new Services.Messaging.Client.SendMessageRecipient { Id = customer.CustomerFacebook.FacebookId },
                    Content = new Services.Messaging.Client.SendMessageContent
                    {
                        Text = ResponseMessageHelper.NotifyCancelBill(responseMessage.BillCancelMessage, bill)
                    }
                };
                var sendMessageResponse = await _messagingServiceManager.SendAsync(sendMessagePayload);
                var canNotify = MessagingServiceClientHelper.IsSuccess(sendMessageResponse);

                // Update bill's notification
                var billNotification = _billNotificationRepository.GetByBillId(bill.Id);
                if (billNotification != null)
                {
                    billNotification.IsCancelNotified = true;
                    billNotification.CancelNotifiedOn = DateTime.Now;
                    billNotification.CanNotifyCancel = canNotify;
                    billNotification.UpdatedBy = Guid.Empty;
                    billNotification.UpdatedOn = DateTime.Now;

                    _billNotificationRepository.Update(billNotification);
                }
            }
            catch (SkipProcessException)
            {
            }
            catch
            {
                throw;
            }
        }

        public async Task NotifyBillSummaryAsync(Guid billId)
        {
            try
            {
                // Get bill
                var bill = _billRepository.GetById(billId);
                if (bill == null)
                {
                    throw new SkipProcessException("No bill found.");
                }

                if (bill.BillNotification == null)
                {
                    throw new SkipProcessException("No bill's notification found.");
                }

                if (bill.BillRecipient == null)
                {
                    throw new SkipProcessException("No bill's recipient found.");
                }

                // Check bill is pending
                if (!BillHelper.IsPending(bill))
                {
                    throw new SkipProcessException("Bill is not pending.");
                }

                // Get response message
                var responseMessage = _responseMessageRepository.GetByChannelId(bill.ChannelId);
                if (responseMessage == null)
                {
                    throw new SkipProcessException("No response's message found.");
                }

                var responseMessageEnabled = ResponseMessageHelper.GetResponseMessageEnabled(EnumResponseMessageType.NotifyBillSummary, responseMessage);
                if (!responseMessageEnabled)
                {
                    throw new SkipProcessException("Response's message diabled.");
                }

                // Get preferences
                var preferences = _preferencesRepository.GetByChannelId(bill.ChannelId);
                if (preferences == null)
                {
                    throw new SkipProcessException("No preferences found.");
                }

                // Get customer
                var customerId = bill.BillRecipient.CustomerId;
                var customer = _customerRepository.GetById(customerId);
                if (customer == null)
                {
                    throw new SkipProcessException("No customer found.");
                }

                if (customer.CustomerFacebook == null)
                {
                    throw new SkipProcessException("No customer's facebook found.");
                }

                // Get order
                var orders = _orderRepository.GetByBillIdWithStatus(bill.Id, EnumOrderStatus.Pending);

                // Get product
                var productIds = orders
                    .Select(x => x.ProductId)
                    .ToArray();
                var products = _productRepository.GetByIds(productIds);

                // Get buyer's base url
                var buyerBaseUrl = _configuration.GetValue<string>(AppSettings.Applications.Buyer.BaseUrl);

                // Notify
                var sendMessagePayload = new Services.Messaging.Client.SendMessage
                {
                    Type = Services.Messaging.Client.EnumMessageType.Chat,
                    Provider = Services.Messaging.Client.EnumMessageProvider.Facebook,
                    Sender = new Services.Messaging.Client.SendMessageSender { Id = bill.ChannelId.ToString() },
                    Recipient = new Services.Messaging.Client.SendMessageRecipient { Id = customer.CustomerFacebook.FacebookId },
                    Content = new Services.Messaging.Client.SendMessageContent
                    {
                        Text = ResponseMessageHelper.NotifySummaryBill(responseMessage.BillSummaryMessage, buyerBaseUrl, bill, orders, products, preferences)
                    }
                };
                var sendMessageResponse = await _messagingServiceManager.SendAsync(sendMessagePayload);
                var canNotify = MessagingServiceClientHelper.IsSuccess(sendMessageResponse);

                // Update bill's notification
                var billNotification = _billNotificationRepository.GetByBillId(bill.Id);
                if (billNotification != null)
                {
                    billNotification.IsSummaryNotified = true;
                    billNotification.SummaryNotifiedOn = DateTime.Now;
                    billNotification.CanNotifySummary = canNotify;
                    billNotification.UpdatedBy = Guid.Empty;
                    billNotification.UpdatedOn = DateTime.Now;

                    _billNotificationRepository.Update(billNotification);
                }
            }
            catch (SkipProcessException)
            {
            }
            catch
            {
                throw;
            }
        }

        private DateTime? GetCancelTime(Guid billId)
        {
            // Get order
            var orders = _orderRepository.GetByBillId(billId);
            if (orders.IsEmpty())
            {
                throw new SkipProcessException("No order found.");
            }

            // Get latest order (live)
            var latestLiveOrder = orders
                .Where(x => x.LiveId.HasValue)
                .OrderByDescending(x => x.CreatedOn)
                .FirstOrDefault();
            if (latestLiveOrder != null && latestLiveOrder.LiveId.HasValue)
            {
                // Get live's option
                var liveOption = _liveOptionRepository.GetByLiveId(latestLiveOrder.LiveId.Value);
                if (liveOption == null)
                {
                    throw new SkipProcessException("No live's option found.");
                }

                return liveOption.AutoCancelBillOn;
            }

            return null;
        }
    }
}