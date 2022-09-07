using System.Collections.Generic;
using System.Linq;

namespace SC.App.Queues.Bill.Business.Order.Helpers
{
    public class OrderHelper
    {
        public static int GetAmount(List<Database.Models.Order> orders)
        {
            return orders
                .Sum(x => x.Amount);
        }

        public static decimal GetPrice(Database.Models.Order order)
        {
            return order.Amount * order.UnitPrice;
        }

        public static decimal GetPrice(List<Database.Models.Order> orders)
        {
            return orders
                .Sum(x => x.Amount * x.UnitPrice);
        }
    }
}