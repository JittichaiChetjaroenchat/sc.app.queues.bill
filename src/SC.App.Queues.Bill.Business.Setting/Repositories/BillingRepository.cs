using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Setting.Database;
using SC.App.Queues.Bill.Business.Setting.Database.Models;
using SC.App.Queues.Bill.Business.Setting.Repositories.Interface;
using SC.App.Queues.Streaming.Business.Setting.Repositories;

namespace SC.App.Queues.Bill.Business.Setting.Repositories
{
    public class BillingRepository : BaseRepository, IBillingRepository
    {
        public BillingRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public Billing GetByChannelId(Guid channelId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Billings
                    .Include(x => x.Status)
                    .FirstOrDefault(x => x.ChannelId == channelId);
            }
        }
    }
}