using System;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Repositories.Interface
{
    public interface IPaymentVerificationDetailRepository : IRepository
    {
        Guid Add(Database.Models.PaymentVerificationDetail paymentVerificationDetail);
    }
}