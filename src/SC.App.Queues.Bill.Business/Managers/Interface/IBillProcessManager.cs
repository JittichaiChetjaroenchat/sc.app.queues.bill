using System;
using System.Threading.Tasks;

namespace SC.App.Queues.Bill.Business.Managers.Interface
{
    public interface IBillProcessManager
    {
        Task ConfirmBillAsync(Guid billId);

        Task CancelBillAsync(Guid billId);

        Task NotifyBillConfirmAsync(Guid billId);

        Task NotifyBillBeforeCancelAsync(Guid billId);

        Task NotifyBillCancelAsync(Guid billId);

        Task NotifyBillSummaryAsync(Guid billId);
    }
}