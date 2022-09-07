using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Helpers
{
    public class VatHelper
    {
        public static decimal Calculate(decimal cost, BillPayment billPayment)
        {
            if (billPayment != null &&
                billPayment.HasVat &&
                !billPayment.IncludedVat)
            {
                return (cost * billPayment.VatPercentage) / 100;
            }

            return 0;
        }
    }
}