using System.ComponentModel;

namespace SC.App.Queues.Bill.Business.Order.Enums
{
    public enum EnumOrderStatus
    {
        [Description("unknown")]
        Unknown,

        [Description("pending")]
        Pending,

        [Description("confirm")]
        Confirm,

        [Description("cancelled")]
        Cancelled
    }
}