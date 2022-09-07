using System;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Repositories.Interface
{
    public interface IBillRepository : IRepository
    {
        Database.Models.Bill GetById(Guid id);

        void Update(Database.Models.Bill bill);
    }
}