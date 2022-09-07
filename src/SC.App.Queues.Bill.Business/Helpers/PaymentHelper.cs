using System;
using System.Collections.Generic;
using System.Linq;
using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Helpers
{
    public class PaymentHelper
    {
        public static ICollection<Payment> GetPayments(ICollection<Payment> payments, string[] statuses)
        {
            return payments
                .Where(x => statuses.Contains(x.PaymentStatus.Code))
                .ToList();
        }
    }
}