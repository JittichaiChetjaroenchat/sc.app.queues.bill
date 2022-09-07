using System;
using System.Threading.Tasks;

namespace SC.App.Queues.Bill.Business.Managers.Interface
{
    public interface IPaymentVerificationProcessManager
    {
        Task VerifyAsync(Guid paymentId);
    }
}