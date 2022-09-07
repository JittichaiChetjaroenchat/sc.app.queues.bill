using System;
using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Repositories.Interface
{
    public interface IPaymentVerificationStatusRepository
    {
        PaymentVerificationStatus GetById(Guid id);

        PaymentVerificationStatus GetByCode(string code);
    }
}