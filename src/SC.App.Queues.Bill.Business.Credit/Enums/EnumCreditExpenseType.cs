using System.ComponentModel;

namespace SC.App.Queues.Bill.Business.Credit.Enums
{
    public enum EnumCreditExpenseType
    {
        [Description("unknown")]
        Unknown,

        [Description("initialize")]
        Initialize,

        [Description("topup")]
        Topup,

        [Description("billing")]
        Billing
    }
}