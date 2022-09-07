using System;
using SC.App.Queues.Bill.Business.Courier.Database.Models;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Courier.Repositories.Interface
{
    public interface IOrderRepository : IRepository
    {
        Order GetByUniqueKey(Guid refId);
    }
}