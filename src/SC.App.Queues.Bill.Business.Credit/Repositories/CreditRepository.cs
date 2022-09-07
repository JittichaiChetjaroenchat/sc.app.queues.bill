using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Credit.Database;
using SC.App.Queues.Bill.Business.Credit.Repositories.Interface;

namespace SC.App.Queues.Bill.Business.Credit.Repositories
{
    public class CreditRepository : BaseRepository, ICreditRepository
    {
        public CreditRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public Database.Models.Credit GetByChannelId(Guid channelId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Credits
                    .FirstOrDefault(x => x.ChannelId == channelId);
            }
        }

        public void Update(Database.Models.Credit credit)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                context.Entry(credit).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}