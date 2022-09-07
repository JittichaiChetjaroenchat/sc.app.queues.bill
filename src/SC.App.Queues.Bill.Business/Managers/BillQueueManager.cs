using System.Threading.Tasks;
using SC.App.Queues.Bill.Business.Managers.Interface;
using SC.App.Queues.Bill.Queue.Models.Bill;

namespace SC.App.Queues.Bill.Business.Managers
{
    public class BillQueueManager : IBillQueueManager
    {
        private readonly IBillProcessManager _billProcessManager;
        private readonly IParcelProcessManager _parcelProcessManager;
        private readonly IPaymentProcessManager _paymentProcessManager;
        private readonly IPaymentVerificationProcessManager _paymentVerificationProcessManager;

        public BillQueueManager(
            IBillProcessManager billProcessManager,
            IParcelProcessManager parcelProcessManager,
            IPaymentProcessManager paymentProcessManager,
            IPaymentVerificationProcessManager paymentVerificationProcessManager)
        {
            _billProcessManager = billProcessManager;
            _parcelProcessManager = parcelProcessManager;
            _paymentProcessManager = paymentProcessManager;
            _paymentVerificationProcessManager = paymentVerificationProcessManager;
        }

        public async Task ProcessAsync(NotifyPaymentAccept data)
        {
            try
            {
                await _paymentProcessManager.NotifyPaymentAcceptAsync(data.Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task ProcessAsync(NotifyPaymentReject data)
        {
            try
            {
                await _paymentProcessManager.NotifyPaymentRejectAsync(data.Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task ProcessAsync(NotifyDeliveryAddressAccept data)
        {
            try
            {
                await _paymentProcessManager.NotifyDeliveryAddressAcceptAsync(data.Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task ProcessAsync(NotifyDeliveryAddressReject data)
        {
            try
            {
                await _paymentProcessManager.NotifyDeliveryAddressRejectAsync(data.Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task ProcessAsync(NotifyBillConfirm data)
        {
            try
            {
                await _billProcessManager.NotifyBillConfirmAsync(data.Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task ProcessAsync(NotifyBillBeforeCancel data)
        {
            try
            {
                await _billProcessManager.NotifyBillBeforeCancelAsync(data.Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task ProcessAsync(NotifyBillCancel data)
        {
            try
            {
                await _billProcessManager.NotifyBillCancelAsync(data.Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task ProcessAsync(NotifyBillSummary data)
        {
            try
            {
                await _billProcessManager.NotifyBillSummaryAsync(data.Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task ProcessAsync(NotifyParcelIssue data)
        {
            try
            {
                await _parcelProcessManager.NotifyParcelIssueAsync(data.Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task ProcessAsync(VerifyPayment data)
        {
            try
            {
                await _paymentVerificationProcessManager.VerifyAsync(data.Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task ProcessAsync(CancelBill data)
        {
            try
            {
                await _billProcessManager.CancelBillAsync(data.Id);
            }
            catch
            {
                throw;
            }
        }
    }
}