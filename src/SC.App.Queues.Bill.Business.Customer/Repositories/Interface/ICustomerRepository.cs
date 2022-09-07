using System;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Customer.Repositories.Interface
{
    public interface ICustomerRepository : IRepository
    {
        Database.Models.Customer GetById(Guid id);

        void Update(Database.Models.Customer customer);
    }
}