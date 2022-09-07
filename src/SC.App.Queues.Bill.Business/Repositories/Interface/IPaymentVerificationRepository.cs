using System;
using System.Collections.Generic;
using SC.App.Queues.Bill.Common.Repositories;
using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Repositories.Interface
{
    public interface IPaymentVerificationRepository : IRepository
    {
        PaymentVerification GetByPaymentId(Guid paymentId);

        List<BillRecipient> GetDuplicateTos(string transactionRefNo, Guid channelId, Guid exceptPaymentId);

        Guid Add(PaymentVerification paymentVerification);

        void Update(PaymentVerification paymentVerification);
    }
}