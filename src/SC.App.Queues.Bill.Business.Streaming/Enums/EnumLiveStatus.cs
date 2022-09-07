using System.ComponentModel;

namespace SC.App.Queues.Bill.Business.Streaming.Enums
{
    public enum EnumLiveStatus
    {
        [Description("unknown")]
        Unknown,

        [Description("pending")]
        Pending,

        [Description("connected")]
        Connected,

        [Description("disconnected")]
        Disconnected
    }
}