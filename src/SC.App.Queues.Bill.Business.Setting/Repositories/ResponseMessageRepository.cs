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
    public class ResponseMessageRepository : BaseRepository, IResponseMessageRepository
    {
        public ResponseMessageRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public ResponseMessage GetByChannelId(Guid channelId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.ResponseMessages
                    .Include(x => x.Status)
                    .FirstOrDefault(x => x.ChannelId == channelId);
            }
        }
    }
}