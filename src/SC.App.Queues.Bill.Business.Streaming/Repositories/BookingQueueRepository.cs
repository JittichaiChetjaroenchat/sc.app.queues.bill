using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Streaming.Database;
using SC.App.Queues.Bill.Business.Streaming.Database.Models;
using SC.App.Queues.Bill.Business.Streaming.Repositories.Interface;

namespace SC.App.Queues.Bill.Business.Streaming.Repositories
{
    public class BookingQueueRepository : BaseRepository, IBookingQueueRepository
    {
        public BookingQueueRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public BookingQueue GetById(Guid id)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.BookingQueues
                    .Include(x => x.BookingChannel)
                    .Include(x => x.Offering)
                    .ThenInclude(x => x.Live)
                    .Include(x => x.LiveComment)
                    .ThenInclude(x => x.LiveCommentor)
                    .FirstOrDefault(x => x.Id == id);
            }
        }
    }
}