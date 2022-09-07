using System.ComponentModel;

namespace SC.App.Queues.Bill.Business.Enums
{
    public enum EnumPaymentStatus
    {
        [Description("unknown")]
        Unknown,

        [Description("pending")]
        Pending,

        [Description("rejected")]
        Rejected,

        [Description("accepted")]
        Accepted
    }
}