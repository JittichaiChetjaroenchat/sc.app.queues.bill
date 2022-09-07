using System.Threading.Tasks;
using SC.App.Queues.Bill.Queue.Models.Bill;

namespace SC.App.Queues.Bill.Business.Managers.Interface
{
    public interface IBillQueueManager
    {
        Task ProcessAsync(NotifyPaymentAccept data);

        Task ProcessAsync(NotifyPaymentReject data);

        Task ProcessAsync(NotifyDeliveryAddressAccept data);

        Task ProcessAsync(NotifyDeliveryAddressReject data);

        Task ProcessAsync(NotifyBillConfirm data);

        Task ProcessAsync(NotifyBillBeforeCancel data);

        Task ProcessAsync(NotifyBillCancel data);

        Task ProcessAsync(NotifyBillSummary data);

        Task ProcessAsync(NotifyParcelIssue data);

        Task ProcessAsync(VerifyPayment data);

        Task ProcessAsync(CancelBill data);
    }
}