using System;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Repositories.Interface
{
    public interface IPaymentRepository : IRepository
    {
        Database.Models.Payment GetById(Guid id);

        Database.Models.Payment GetLatestByBilId(Guid billId);

        void Update(Database.Models.Payment payment);
    }
}