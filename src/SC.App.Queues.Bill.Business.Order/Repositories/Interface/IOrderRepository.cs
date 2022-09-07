using System;
using System.Collections.Generic;
using SC.App.Queues.Bill.Business.Order.Enums;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Order.Repositories.Interface
{
    public interface IOrderRepository : IRepository
    {
        List<Database.Models.Order> GetByBillId(Guid billId);

        List<Database.Models.Order> GetByBillIdWithStatus(Guid billId, EnumOrderStatus status);

        void Updates(List<Database.Models.Order> orders);
    }
}