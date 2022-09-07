using System;
using SC.App.Queues.Bill.Business.Setting.Database.Models;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Setting.Repositories.Interface
{
    public interface IPaymentRepository : IRepository
    {
        Payment GetByChannelId(Guid channelId);
    }
}