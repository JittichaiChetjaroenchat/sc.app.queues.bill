using System;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Database;
using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Repositories
{
    public class PaymentVerificationDetailRepository : BaseRepository, IPaymentVerificationDetailRepository
    {
        public PaymentVerificationDetailRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public Guid Add(PaymentVerificationDetail paymentVerificationDetail)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                context.Add(paymentVerificationDetail);
                context.SaveChanges();

                return paymentVerificationDetail.Id;
            }
        }
    }
}