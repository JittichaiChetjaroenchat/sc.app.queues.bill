namespace SC.App.Queues.Bill.Business.Streaming.Database.Constants
{
    public class LiveOption
    {
        public const string TableName = "live_options";

        public static class Column
        {
            public const string Id = "id";

            public const string LiveId = "live_id";

            public const string DuplicateOrderProtectionEnabled = "duplicate_order_protection_enabled";

            public const string OfferFromPreviousEnabled = "offer_from_provious_enabled";

            public const string AutoNotifyBeforeCancelBillEnabled = "auto_notify_before_cancel_bill_enabled";

            public const string AutoNotifyBeforeCancelBillMinute = "auto_notify_before_cancel_bill_minute";

            public const string IsAutoNotifyBeforeCancelBillProcessed = "is_auto_notify_before_cancel_bill_processed";

            public const string AutoNotifyBeforeCancelBillProcessedOn = "auto_notify_before_cancel_bill_processed_on";

            public const string AutoCancelBillEnabled = "auto_cancel_bill_enabled";

            public const string AutoCancelBillOn = "auto_cancel_bill_on";

            public const string IsAutoCancelBillProcessed = "is_auto_cancel_bill_processed";

            public const string AutoCancelBillProcessedOn = "auto_cancel_bill_processed_on";
        }
    }
}