using System;
using SC.App.Queues.Bill.Business.Streaming.Database.Models;
using SC.App.Queues.Bill.Business.Streaming.Enums;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Streaming.Repositories.Interface
{
    public interface ILiveRepository : IRepository
    {
        Live GetLatestLiveByFilter(Guid channelId, EnumLiveStatus status);
    }
}