using System;
using System.Threading.Tasks;

namespace SC.App.Queues.Bill.Business.Customer.Managers.Interface
{
    public interface ICustomerManager
    {
        Task SetToRegularAsync(Guid customerId);
    }
}