using System;
using SC.App.Queues.Bill.Business.Setting.Database.Models;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Setting.Repositories.Interface
{
    public interface IBillingRepository : IRepository
    {
        Billing GetByChannelId(Guid channelId);
    }
}