using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Database;
using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Repositories
{
    public class PaymentStatusRepository : BaseRepository, IPaymentStatusRepository
    {
        public PaymentStatusRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public PaymentStatus GetByCode(string code)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.PaymentStatuses
                    .FirstOrDefault(x => x.Code == code);
            }
        }
    }
}