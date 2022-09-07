using System;
using SC.App.Queues.Bill.Business.Credit.Database.Models;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Credit.Repositories.Interface
{
    public interface ICreditExpenseTypeRepository : IRepository
    {
        CreditExpenseType GetById(Guid id);

        CreditExpenseType GetByCode(string code);
    }
}