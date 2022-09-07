using System;
using SC.App.Queues.Bill.Database.Models;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Repositories.Interface
{
    public interface IBillStatusRepository : IRepository
    {
        BillStatus GetById(Guid id);

        BillStatus GetByCode(string code);
    }
}