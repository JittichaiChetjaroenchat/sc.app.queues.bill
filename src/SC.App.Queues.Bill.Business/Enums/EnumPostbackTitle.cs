using System.ComponentModel;

namespace SC.App.Queues.Bill.Business.Enums
{
    public enum EnumPostbackTitle
    {
        [Description("unknown")]
        Unknown,

        [Description("ดูบิล/ชำระเงิน")]
        NotifyPayment,

        [Description("ลงชื่อสินค้าหลุดจอง")]
        QueueBooking,

        [Description("ติดตามสถานะพัสดุ")]
        TrackParcel,

        [Description("แจ้งปัญหาเกี่ยวกับพัสดุ")]
        FeedbackParcel
    }
}