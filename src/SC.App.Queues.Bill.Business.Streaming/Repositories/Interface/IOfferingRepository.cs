using System;
using SC.App.Queues.Bill.Business.Streaming.Database.Models;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Streaming.Repositories.Interface
{
    public interface IOfferingRepository : IRepository
    {
        Offering GetOfferingByFilter(Guid liveId, Guid productId);

        void Update(Offering offering);
    }
}