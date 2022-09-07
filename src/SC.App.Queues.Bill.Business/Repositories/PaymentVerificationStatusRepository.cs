using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Database;
using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Repositories
{
    public class PaymentVerificationStatusRepository : BaseRepository, IPaymentVerificationStatusRepository
    {
        public PaymentVerificationStatusRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public PaymentVerificationStatus GetById(Guid id)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.PaymentVerificationStatuses
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public PaymentVerificationStatus GetByCode(string code)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.PaymentVerificationStatuses
                    .FirstOrDefault(x => x.Code == code);
            }
        }
    }
}