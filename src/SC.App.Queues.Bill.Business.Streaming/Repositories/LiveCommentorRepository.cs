using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Streaming.Database;
using SC.App.Queues.Bill.Business.Streaming.Database.Models;
using SC.App.Queues.Bill.Business.Streaming.Repositories.Interface;

namespace SC.App.Queues.Bill.Business.Streaming.Repositories
{
    public class LiveCommentorRepository : BaseRepository, ILiveCommentorRepository
    {
        public LiveCommentorRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public LiveCommentor GetByFilter(Guid channelId, string name)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.LiveCommentors
                    .FirstOrDefault(x => x.ChannelId == channelId && x.Name == name);
            }
        }
    }
}