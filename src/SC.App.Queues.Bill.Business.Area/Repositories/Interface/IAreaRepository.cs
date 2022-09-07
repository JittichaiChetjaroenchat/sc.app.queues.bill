using System;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Area.Repositories.Interface
{
    public interface IAreaRepository : IRepository
    {
        Database.Models.Area GetById(Guid id);
    }
}