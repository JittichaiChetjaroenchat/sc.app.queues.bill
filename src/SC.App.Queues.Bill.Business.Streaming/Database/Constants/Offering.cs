namespace SC.App.Queues.Bill.Business.Streaming.Database.Constants
{
    public class Offering
    {
        public const string TableName = "offerings";

        public static class Column
        {
            public const string Id = "id";

            public const string LiveId = "live_id";

            public const string ProductId = "product_id";

            public const string Code = "code";

            public const string Amount = "amount";

            public const string Price = "price";

            public const string Remaining = "remaining";

            public const string OfferingStatusId = "offering_status_id";

            public const string CreatedBy = "created_by";

            public const string CreatedOn = "created_on";

            public const string UpdatedBy = "updated_by";

            public const string UpdatedOn = "updated_on";
        }
    }
}