using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Streaming.Database;
using SC.App.Queues.Bill.Business.Streaming.Database.Models;
using SC.App.Queues.Bill.Business.Streaming.Repositories.Interface;

namespace SC.App.Queues.Bill.Business.Streaming.Repositories
{
    public class LiveOptionRepository : BaseRepository, ILiveOptionRepository
    {
        public LiveOptionRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public LiveOption GetByLiveId(Guid liveId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.LiveOptions
                    .FirstOrDefault(x => x.LiveId == liveId);
            }
        }
    }
}