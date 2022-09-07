using System.ComponentModel;

namespace SC.App.Queues.Bill.Business.Enums
{
    public enum EnumShippingCostType
    {
        [Description("unknown")]
        Unknown,

        [Description("range")]
        Range,

        [Description("total")]
        Total,

        [Description("free")]
        Free
    }
}