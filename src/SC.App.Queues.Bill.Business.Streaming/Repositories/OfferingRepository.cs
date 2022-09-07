using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Streaming.Database;
using SC.App.Queues.Bill.Business.Streaming.Database.Models;
using SC.App.Queues.Bill.Business.Streaming.Repositories.Interface;

namespace SC.App.Queues.Bill.Business.Streaming.Repositories
{
    public class OfferingRepository : BaseRepository, IOfferingRepository
    {
        public OfferingRepository(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public Offering GetOfferingByFilter(Guid liveId, Guid productId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Offerings
                    .FirstOrDefault(x => x.LiveId == liveId && x.ProductId == productId);
            }
        }

        public void Update(Offering offering)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                context.Entry(offering).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}