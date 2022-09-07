using System;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Repositories.Interface
{
    public interface IBillNotificationRepository : IRepository
    {
        Database.Models.BillNotification GetByBillId(Guid billId);

        void Update(Database.Models.BillNotification billNotification);
    }
}