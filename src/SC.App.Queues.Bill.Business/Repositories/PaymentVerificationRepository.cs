using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Database;
using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Repositories
{
    public class PaymentVerificationRepository : BaseRepository, IPaymentVerificationRepository
    {
        public PaymentVerificationRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public PaymentVerification GetByPaymentId(Guid paymentId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.PaymentVerifications
                    .FirstOrDefault(x => x.PaymentId == paymentId);
            }
        }

        public List<BillRecipient> GetDuplicateTos(string transactionRefNo, Guid channelId, Guid exceptPaymentId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.PaymentVerificationDetails
                    .Include(x => x.PaymentVerification)
                    .ThenInclude(x => x.Payment)
                    .ThenInclude(x => x.Bill)
                    .ThenInclude(x => x.BillRecipient)
                    .Where(x => x.PaymentVerification != null && x.PaymentVerification.Payment != null && x.PaymentVerification.Payment.Bill != null && x.PaymentVerification.Payment.Bill.ChannelId == channelId)
                    .Where(x => x.TransactionRefNo != null && x.TransactionRefNo == transactionRefNo)
                    .Where(x => x.PaymentVerification != null && x.PaymentVerification.PaymentId != exceptPaymentId)
                    .Select(x => x.PaymentVerification.Payment.Bill.BillRecipient)
                    .ToList();
            }
        }

        public Guid Add(PaymentVerification paymentVerification)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                context.Add(paymentVerification);
                context.SaveChanges();

                return paymentVerification.Id;
            }
        }

        public void Update(PaymentVerification paymentVerification)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                context.Entry(paymentVerification).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}