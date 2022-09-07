using System.Collections.Generic;
using System.Linq;
using SC.App.Queues.Bill.Business.Enums;
using SC.App.Queues.Bill.Business.Order.Enums;
using SC.App.Queues.Bill.Business.Order.Helpers;
using SC.App.Queues.Bill.Database.Models;
using SC.App.Queues.Bill.Lib.Extensions;

namespace SC.App.Queues.Bill.Business.Helpers
{
    public class CostHelper
    {
        public static decimal GetPayExtra(List<Order.Database.Models.Order> orders, BillShipping billShipping, ICollection<Payment> payments, BillDiscount billDiscount, BillPayment billPayment)
        {
            var nonCancelledOrders = orders
                .Where(x => x.OrderStatus.Code != EnumOrderStatus.Cancelled.GetDescription())
                .ToList();
            var goods = OrderHelper.GetPrice(nonCancelledOrders);
            var shipping = ShippingHelper.CalculateCost(nonCancelledOrders, billShipping);
            var beforeDiscount = goods + shipping;
            var discount = DiscountHelper.Calculate(beforeDiscount, billDiscount);
            var afterDiscount = beforeDiscount - discount;
            var cod = CodHelper.Calculate(afterDiscount, billPayment);
            var afterCod = afterDiscount + cod;
            var gross = afterCod;
            var vat = VatHelper.Calculate(gross, billPayment);
            var afterVat = gross + vat;
            var net = afterVat;
            var paid = GetAcceptedAmount(payments);
            var payExtra = net - paid;

            return payExtra;
        }

        public static decimal GetAcceptedAmount(ICollection<Payment> payments)
        {
            var acceptedPayments = PaymentHelper.GetPayments(payments, new string[] { EnumPaymentStatus.Accepted.GetDescription() });

            return acceptedPayments
                .Sum(x => x.Amount);
        }
    }
}