using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SC.App.Queues.Bill.Business.Enums;
using SC.App.Queues.Bill.Business.Helpers;
using SC.App.Queues.Bill.Business.Managers.Interface;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Common.Exceptions;
using SC.App.Queues.Bill.Lib.Extensions;
using SC.App.Queues.Bill.Queue.Managers.Interface;
using SC.App.Queues.Bill.Queue.Models.Messaging;

namespace SC.App.Queues.Bill.Business.Managers
{
    public class ParcelProcessManager : IParcelProcessManager
    {
        private readonly IBillRepository _billRepository;
        private readonly IParcelRepository _parcelRepository;

        private readonly Area.Repositories.Interface.IAreaRepository _areaRepository;
        private readonly Courier.Repositories.Interface.IOrderRepository _courierOrderRepository;
        private readonly Customer.Repositories.Interface.ICustomerRepository _customerRepository;
        private readonly Setting.Repositories.Interface.IResponseMessageRepository _responseMessageRepository;

        private readonly IQueueManager _queueManager;

        public ParcelProcessManager(
            IBillRepository billRepository,
            IParcelRepository parcelRepository,

            Area.Repositories.Interface.IAreaRepository areaRepository,
            Courier.Repositories.Interface.IOrderRepository courierOrderRepository,
            Customer.Repositories.Interface.ICustomerRepository customerRepository,
            Setting.Repositories.Interface.IResponseMessageRepository responseMessageRepository,

            IQueueManager queueManager)
        {
            _billRepository = billRepository;
            _parcelRepository = parcelRepository;

            _areaRepository = areaRepository;
            _courierOrderRepository = courierOrderRepository;
            _customerRepository = customerRepository;
            _responseMessageRepository = responseMessageRepository;

            _queueManager = queueManager;
        }

        public async Task NotifyParcelIssueAsync(Guid parcelId)
        {
            try
            {
                // Get parcel
                var parcel = _parcelRepository.GetById(parcelId);
                if (parcel == null)
                {
                    throw new SkipProcessException("No parcel found.");
                }

                // Get bill
                var bill = _billRepository.GetById(parcel.BillId);
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

                var responseMessageEnabled = ResponseMessageHelper.GetResponseMessageEnabled(EnumResponseMessageType.NotifyParcelIssue, responseMessage);
                if (!responseMessageEnabled)
                {
                    throw new SkipProcessException("Response's message diabled.");
                }

                // Get courier's order
                var courierOrder = _courierOrderRepository.GetByUniqueKey(parcel.Id);
                if (courierOrder == null)
                {
                    throw new SkipProcessException("No courier's order found.");
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

                // Notify
                var template = ResponseMessageHelper.GetResponseMessage(EnumResponseMessageType.NotifyParcelIssue, responseMessage);
                var sender = new ChatSender { Id = bill.ChannelId.ToString() };
                var recipient = new ChatRecipient { Id = customer.CustomerFacebook.FacebookId };
                var postbacks = new List<ChatContentPostback>
                {
                    new ChatContentPostback { Title = EnumPostbackTitle.TrackParcel.GetDescription(), Payload = courierOrder.Id.ToString() },
                    new ChatContentPostback { Title = EnumPostbackTitle.FeedbackParcel.GetDescription(), Payload = parcel.Id.ToString() },
                };
                var content = new ChatContent
                {
                    Text = ResponseMessageHelper.NotifyIssueParcel(template, courierOrder, bill.BillRecipient, bill.BillRecipient.BillRecipientContact, area),
                    Postbacks = postbacks
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
    }
}