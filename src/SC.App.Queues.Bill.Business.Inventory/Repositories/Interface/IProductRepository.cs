using System;
using System.Collections.Generic;
using SC.App.Queues.Bill.Business.Inventory.Database.Models;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Inventory.Repositories.Interface
{
    public interface IProductRepository : IRepository
    {
        Product GetById(Guid id);

        List<Product> GetByIds(Guid[] ids);

        void Updates(List<Product> products);
    }
}