namespace SC.App.Queues.Bill.Business.Setting.Database.Constants
{
    public class Payment
    {
        public const string TableName = "payments";

        public static class Column
        {
            public const string Id = "id";

            public const string ChannelId = "channel_id";

            public const string IsComplete = "is_complete";

            public const string StatusId = "status_id";

            public const string CreatedBy = "created_by";

            public const string CreatedOn = "created_on";

            public const string UpdatedBy = "updated_by";

            public const string UpdatedOn = "updated_on";

            public const string IsVerifySlipAutomatic = "is_verify_slip_automatic";

            public const string IsConfirmBillAutomatic = "is_confirm_bill_automatic";

            public const string VerifySlipTransactionFee = "verify_slip_transaction_fee";
        }
    }
}