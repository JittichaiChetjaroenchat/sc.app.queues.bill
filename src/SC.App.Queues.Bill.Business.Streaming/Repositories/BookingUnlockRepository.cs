using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Streaming.Database;
using SC.App.Queues.Bill.Business.Streaming.Database.Models;
using SC.App.Queues.Bill.Business.Streaming.Repositories.Interface;

namespace SC.App.Queues.Bill.Business.Streaming.Repositories
{
    public class BookingUnlockRepository : BaseRepository, IBookingUnlockRepository
    {
        public BookingUnlockRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public BookingUnlock GetByUniqueKey(Guid liveId, Guid liveCommentorId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.BookingUnlocks
                    .Include(x => x.Live)
                    .Include(x => x.LiveCommentor)
                    .FirstOrDefault(x => x.LiveId == liveId && x.LiveCommentorId == liveCommentorId);
            }
        }

        public Guid Add(BookingUnlock bookingUnlock)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                context.Add(bookingUnlock);
                context.SaveChanges();

                return bookingUnlock.Id;
            }
        }

        public void Update(BookingUnlock bookingUnlock)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                context.Entry(bookingUnlock).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}