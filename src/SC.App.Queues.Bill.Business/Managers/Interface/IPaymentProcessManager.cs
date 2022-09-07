using System;
using System.Threading.Tasks;

namespace SC.App.Queues.Bill.Business.Managers.Interface
{
    public interface IPaymentProcessManager
    {
        Task AcceptPaymentAsync(Guid paymentId);

        Task NotifyPaymentAcceptAsync(Guid paymentId);
        
        Task NotifyPaymentRejectAsync(Guid paymentId);

        Task NotifyDeliveryAddressAcceptAsync(Guid billId);

        Task NotifyDeliveryAddressRejectAsync(Guid billId);
    }
}