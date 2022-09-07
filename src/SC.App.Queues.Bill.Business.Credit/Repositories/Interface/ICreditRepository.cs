using System;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Credit.Repositories.Interface
{
    public interface ICreditRepository : IRepository
    {
        Database.Models.Credit GetByChannelId(Guid channelId);

        void Update(Database.Models.Credit credit);
    }
}