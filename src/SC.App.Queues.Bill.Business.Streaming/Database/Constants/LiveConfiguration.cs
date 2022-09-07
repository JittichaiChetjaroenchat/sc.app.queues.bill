namespace SC.App.Queues.Bill.Business.Streaming.Database.Constants
{
    public class LiveConfiguration
    {
        public const string TableName = "live_configurations";

        public static class Column
        {
            public const string Id = "id";

            public const string LiveId = "live_id";

            public const string AutoCancelBillEnabled = "auto_cancel_bill_enabled";

            public const string AutoCancelBillTime = "auto_cancel_bill_time";
        }
    }
}