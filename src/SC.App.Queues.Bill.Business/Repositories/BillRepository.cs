using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Database;

namespace SC.App.Queues.Bill.Business.Repositories
{
    public class BillRepository : BaseRepository, IBillRepository
    {
        public BillRepository(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public Database.Models.Bill GetById(Guid id)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Bills
                    .Include(x => x.BillDiscount)
                    .Include(x => x.BillNotification)
                    .Include(x => x.BillRecipient)
                    .ThenInclude(x => x.BillRecipientContact)
                    .Include(x => x.BillPayment)
                    .ThenInclude(x => x.BillPaymentType)
                    .Include(x => x.BillShipping)
                    .ThenInclude(x => x.BillShippingRangeRule)
                    .ThenInclude(x => x.BillShippingRanges)
                    .Include(x => x.BillShipping)
                    .ThenInclude(x => x.BillShippingTotalRule)
                    .Include(x => x.BillShipping)
                    .ThenInclude(x => x.BillShippingFreeRule)
                    .Include(x => x.BillStatus)
                    .Include(x => x.Payments)
                    .ThenInclude(x => x.PaymentStatus)
                    .OrderByDescending(x => x.CreatedOn)
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public void Update(Database.Models.Bill bill)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                context.Entry(bill).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}