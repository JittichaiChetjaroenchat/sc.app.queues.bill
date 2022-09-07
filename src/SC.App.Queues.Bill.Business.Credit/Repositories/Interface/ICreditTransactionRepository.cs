using System;
using SC.App.Queues.Bill.Business.Credit.Database.Models;
using SC.App.Queues.Bill.Common.Repositories;

namespace SC.App.Queues.Bill.Business.Credit.Repositories.Interface
{
    public interface ICreditTransactionRepository : IRepository
    {
        CreditTransaction GetLatestByChannelId(Guid channelId);

        CreditTransaction GetLatestByCreditId(Guid creditId);

        Guid Add(CreditTransaction creditTransaction);
    }
}