using SC.App.Queues.Bill.Common.Repositories;
using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Repositories.Interface
{
    public interface IPaymentStatusRepository : IRepository
    {
        PaymentStatus GetByCode(string code);
    }
}