using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SC.App.Queues.Bill.Business.Enums;
using SC.App.Queues.Bill.Business.Helpers;
using SC.App.Queues.Bill.Business.Managers.Interface;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Common.Constants;
using SC.App.Queues.Bill.Common.Exceptions;
using SC.App.Queues.Bill.Lib.Extensions;
using SC.App.Queues.Bill.Queue.Models.Messaging;

namespace SC.App.Queues.Bill.Business.Managers
{
    public class PaymentProcessManager : IPaymentProcessManager
    {
        private readonly IBillRepository _billRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentStatusRepository _paymentStatusRepository;

        private readonly Area.Repositories.Interface.IAreaRepository _areaRepository;
        private readonly Customer.Repositories.Interface.ICustomerRepository _customerRepository;
        private readonly Setting.Repositories.Interface.IResponseMessageRepository _responseMessageRepository;

        private readonly Queue.Managers.Interface.IQueueManager _queueManager;

        private readonly IConfiguration _configuration;

        public PaymentProcessManager(
            IBillRepository billRepository,
            IPaymentRepository paymentRepository,
            IPaymentStatusRepository paymentStatusRepository,

            Area.Repositories.Interface.IAreaRepository areaRepository,
            Customer.Repositories.Interface.ICustomerRepository customerRepository,
            Setting.Repositories.Interface.IResponseMessageRepository responseMessageRepository,

            Queue.Managers.Interface.IQueueManager queueManager,

            IConfiguration configuration)
        {
            _billRepository = billRepository;
            _paymentRepository = paymentRepository;
            _paymentStatusRepository = paymentStatusRepository;

            _areaRepository = areaRepository;
            _customerRepository = customerRepository;
            _responseMessageRepository = responseMessageRepository;

            _queueManager = queueManager;

            _configuration = configuration;
        }

        public async Task AcceptPaymentAsync(Guid paymentId)
        {
            try
            {
                // Get payment
                var payment = _paymentRepository.GetById(paymentId);
                if (payment == null)
                {
                    throw new SkipProcessException("No payment found.");
                }

                // Update latest payment's status to accepted
                var paymentStatus = _paymentStatusRepository.GetByCode(EnumPaymentStatus.Accepted.GetDescription());

                payment.PaymentStatusId = paymentStatus.Id;
                _paymentRepository.Update(payment);

                // Send response message
                await NotifyPaymentAcceptAsync(paymentId);
            }
            catch (SkipProcessException)
            {
            }
            catch
            {
                throw;
            }
        }

        public async Task NotifyPaymentAcceptAsync(Guid paymentId)
        {
            try
            {
                // Get payment
                var payment = _paymentRepository.GetById(paymentId);
                if (payment == null)
                {
                    throw new SkipProcessException("No payment found.");
                }

                // Get bill
                var bill = _billRepository.GetById(payment.BillId);
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

                // Get response message
                var responseMessage = _responseMessageRepository.GetByChannelId(bill.ChannelId);
                if (responseMessage == null)
                {
                    throw new SkipProcessException("No response's message found.");
                }

                var responseMessageEnabled = ResponseMessageHelper.GetResponseMessageEnabled(EnumResponseMessageType.NotifyPaymentAccept, responseMessage);
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

                // Notify (Text)
                var template = ResponseMessageHelper.GetResponseMessage(EnumResponseMessageType.NotifyPaymentAccept, responseMessage);
                var sender = new ChatSender { Id = bill.ChannelId.ToString() };
                var recipient = new ChatRecipient { Id = customer.CustomerFacebook.FacebookId };
                var text = new ChatContent
                {
                    Text = ResponseMessageHelper.NotifyAcceptPayment(template, bill, payment)
                };

                await _queueManager.ReplyChatAsync(sender, recipient, text);

                // Notify (Evidence)
                var baseUrl = _configuration.GetValue<string>(AppSettings.Services.BaseUrl);
                var evidence = new ChatContent
                {
                    Image = new ChatContentImage
                    {
                        Url = ResponseMessageHelper.GetPaymentEvidence(baseUrl, payment)
                    }
                };

                await _queueManager.ReplyChatAsync(sender, recipient, evidence);
            }
            catch (SkipProcessException)
            {
            }
            catch
            {
                throw;
            }
        }

        public async Task NotifyPaymentRejectAsync(Guid paymentId)
        {
            try
            {
                // Get payment
                var payment = _paymentRepository.GetById(paymentId);
                if (payment == null)
                {
                    throw new SkipProcessException("No payment found.");
                }

                // Get bill
                var bill = _billRepository.GetById(payment.BillId);
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

                // Get response message
                var responseMessage = _responseMessageRepository.GetByChannelId(bill.ChannelId);
                if (responseMessage == null)
                {
                    throw new SkipProcessException("No response's message found.");
                }

                var responseMessageEnabled = ResponseMessageHelper.GetResponseMessageEnabled(EnumResponseMessageType.NotifyPaymentReject, responseMessage);
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

                // Notify (Text)
                var template = ResponseMessageHelper.GetResponseMessage(EnumResponseMessageType.NotifyPaymentReject, responseMessage);
                var sender = new ChatSender { Id = bill.ChannelId.ToString() };
                var recipient = new ChatRecipient { Id = customer.CustomerFacebook.FacebookId };
                var text = new ChatContent
                {
                    Text = ResponseMessageHelper.NotifyAcceptPayment(template, bill, payment)
                };

                await _queueManager.ReplyChatAsync(sender, recipient, text);

                // Notify (Evidence)
                var baseUrl = _configuration.GetValue<string>(AppSettings.Services.BaseUrl);
                var evidence = new ChatContent
                {
                    Image = new ChatContentImage
                    {
                        Url = ResponseMessageHelper.GetPaymentEvidence(baseUrl, payment)
                    }
                };

                await _queueManager.ReplyChatAsync(sender, recipient, evidence);
            }
            catch (SkipProcessException)
            {
            }
            catch
            {
                throw;
            }
        }

        public async Task NotifyDeliveryAddressAcceptAsync(Guid billId)
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

                var responseMessageEnabled = ResponseMessageHelper.GetResponseMessageEnabled(EnumResponseMessageType.NotifyDeliveryAddressAccept, responseMessage);
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

                // Notify (Text)
                var template = ResponseMessageHelper.GetResponseMessage(EnumResponseMessageType.NotifyDeliveryAddressAccept, responseMessage);
                var sender = new ChatSender { Id = bill.ChannelId.ToString() };
                var recipient = new ChatRecipient { Id = customer.CustomerFacebook.FacebookId };
                var text = new ChatContent
                {
                    Text = ResponseMessageHelper.NotifyAcceptDeliveryAddress(template, bill, bill.BillRecipient, bill.BillRecipient.BillRecipientContact, area)
                };

                await _queueManager.ReplyChatAsync(sender, recipient, text);
            }
            catch (SkipProcessException)
            {
            }
            catch
            {
                throw;
            }
        }

        public async Task NotifyDeliveryAddressRejectAsync(Guid billId)
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

                // Get response message
                var responseMessage = _responseMessageRepository.GetByChannelId(bill.ChannelId);
                if (responseMessage == null)
                {
                    throw new SkipProcessException("No response's message found.");
                }

                var responseMessageEnabled = ResponseMessageHelper.GetResponseMessageEnabled(EnumResponseMessageType.NotifyDeliveryAddressReject, responseMessage);
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

                // Notify (Text)
                var template = ResponseMessageHelper.GetResponseMessage(EnumResponseMessageType.NotifyDeliveryAddressReject, responseMessage);
                var sender = new ChatSender { Id = bill.ChannelId.ToString() };
                var recipient = new ChatRecipient { Id = customer.CustomerFacebook.FacebookId };
                var text = new ChatContent
                {
                    Text = ResponseMessageHelper.NotifyRejectDeliveryAddress(template, bill)
                };

                await _queueManager.ReplyChatAsync(sender, recipient, text);
            }
            catch (SkipProcessException)
            {
            }
            catch
            {
                throw;
            }
        }
    }
}