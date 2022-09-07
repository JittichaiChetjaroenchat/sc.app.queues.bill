namespace SC.App.Queues.Bill.Business.Streaming.Database.Constants
{
    public class LiveCommentDescription
    {
        public const string TableName = "live_comment_descriptions";

        public static class Column
        {
            public const string Id = "id";

            public const string LiveCommentId = "live_comment_id";

            public const string IsNewCustomer = "is_new_customer";

            public const string IsCustomerBlocked = "is_customer_blocked";

            public const string Tags = "tags";

            public const string IsRequestOfferLink = "is_request_offer_link";

            public const string IsPurchaseSucceed = "is_purchase_succeed";

            public const string IsPurchaseLimitReached = "is_purchase_limit_reached";

            public const string HasBill = "has_bill";

            public const string LatestBillCost = "lastest_bill_cost";

            public const string LatestBillPaymentId = "latest_bill_payment_id";

            public const string IsLatestBillDeposited = "is_latest_bill_deposited";

            public const string IsLatestBillPending = "is_latest_bill_pending";

            public const string IsLatestBillNotified = "is_latest_bill_notified";

            public const string IsLatestBillConfirmed = "is_latest_bill_confirmed";

            public const string IsLatestBillCancelled = "is_latest_bill_cancelled";
        }
    }
}