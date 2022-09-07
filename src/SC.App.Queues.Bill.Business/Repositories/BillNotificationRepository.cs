using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Database;
using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Repositories
{
    public class BillNotificationRepository : BaseRepository, IBillNotificationRepository
    {
        public BillNotificationRepository(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public BillNotification GetByBillId(Guid billId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.BillNotifications
                    .FirstOrDefault(x => x.BillId == billId);
            }
        }

        public void Update(BillNotification billNotification)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                context.Entry(billNotification).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}