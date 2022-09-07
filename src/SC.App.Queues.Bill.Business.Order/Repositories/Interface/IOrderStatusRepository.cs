using SC.App.Queues.Bill.Business.Order.Database.Models;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Order.Repositories.Interface
{
    public interface IOrderStatusRepository : IRepository
    {
        OrderStatus GetByCode(string code);
    }
}