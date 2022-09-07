using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Streaming.Database;
using SC.App.Queues.Bill.Business.Streaming.Database.Models;
using SC.App.Queues.Bill.Business.Streaming.Enums;
using SC.App.Queues.Bill.Business.Streaming.Repositories.Interface;
using SC.App.Queues.Bill.Lib.Extensions;

namespace SC.App.Queues.Bill.Business.Streaming.Repositories
{
    public class LiveRepository : BaseRepository, ILiveRepository
    {
        public LiveRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public Live GetLatestLiveByFilter(Guid channelId, EnumLiveStatus status)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Lives
                    .Include(x => x.LiveOption)
                    .Include(x => x.LiveStatus)
                    .FirstOrDefault(x => x.ChannelId == channelId && x.LiveStatus.Code == status.GetDescription());
            }
        }
    }
}