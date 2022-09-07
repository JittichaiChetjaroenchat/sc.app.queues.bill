using System;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Repositories.Interface
{
    public interface IParcelRepository : IRepository
    {
        Database.Models.Parcel GetById(Guid id);
    }
}