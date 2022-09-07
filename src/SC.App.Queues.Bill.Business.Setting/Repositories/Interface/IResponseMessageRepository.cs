using System;
using SC.App.Queues.Bill.Business.Setting.Database.Models;

namespace SC.App.Queues.Bill.Business.Setting.Repositories.Interface
{
    public interface IResponseMessageRepository
    {
        ResponseMessage GetByChannelId(Guid channelId);
    }
}