using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Credit.Database;
using SC.App.Queues.Bill.Business.Credit.Database.Models;
using SC.App.Queues.Bill.Business.Credit.Repositories.Interface;

namespace SC.App.Queues.Bill.Business.Credit.Repositories
{
    public class CreditTransactionRepository : BaseRepository, ICreditTransactionRepository
    {
        public CreditTransactionRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public CreditTransaction GetLatestByChannelId(Guid channelId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.CreditTransactions
                    .Include(x => x.Credit)
                    .Include(x => x.CreditExpenseType)
                    .Where(x => x.Credit.ChannelId == channelId)
                    .OrderByDescending(x => x.CreatedOn)
                    .FirstOrDefault();
            }
        }

        public CreditTransaction GetLatestByCreditId(Guid creditId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.CreditTransactions
                    .Include(x => x.Credit)
                    .Include(x => x.CreditExpenseType)
                    .OrderByDescending(x => x.CreatedOn)
                    .FirstOrDefault(x => x.CreditId == creditId);
            }
        }

        public Guid Add(CreditTransaction creditTransaction)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                context.Add(creditTransaction);
                context.SaveChanges();

                return creditTransaction.Id;
            }
        }
    }
}