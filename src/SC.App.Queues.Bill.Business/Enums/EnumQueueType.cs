using System.ComponentModel;

namespace SC.App.Queues.Bill.Business.Enums
{
    public enum EnumQueueType
    {
        [Description("unknown")]
        Unknown,

        [Description("notify_payment_accept")]
        NotifyPaymentAccept,

        [Description("notify_payment_reject")]
        NotifyPaymentReject,

        [Description("notify_delivery_address_accept")]
        NotifyDeliveryAddressAccept,

        [Description("notify_delivery_address_reject")]
        NotifyDeliveryAddressReject,

        [Description("notify_bill_confirm")]
        NotifyBillConfirm,

        [Description("notify_bill_cancel")]
        NotifyBillCancel,

        [Description("notify_bill_before_cancel")]
        NotifyBillBeforeCancel,

        [Description("notify_parcel_issue")]
        NotifyParcelIssue
    }
}