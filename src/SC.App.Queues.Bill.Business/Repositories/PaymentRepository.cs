using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Database;
using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Repositories
{
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        public PaymentRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public Payment GetById(Guid id)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Payments
                    .Include(x => x.PaymentStatus)
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public Payment GetLatestByBilId(Guid billId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Payments
                    .Include(x => x.PaymentStatus)
                    .OrderByDescending(x => x.PaymentNo)
                    .FirstOrDefault(x => x.BillId == billId);
            }
        }

        public void Update(Payment payment)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                context.Entry(payment).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}