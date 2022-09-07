namespace SC.App.Queues.Bill.Business.Order.Database.Constants
{
    public class Order
    {
        public const string TableName = "orders";

        public static class Column
        {
            public const string Id = "id";

            public const string ChannelId = "channel_id";

            public const string LiveId = "live_id";

            public const string PostId = "post_id";

            public const string BillId = "bill_id";

            public const string BookingId = "booking_id";

            public const string ParcelId = "parcel_id";

            public const string ProductId = "product_id";

            public const string Code = "code";

            public const string Amount = "amount";

            public const string UnitPrice = "unit_price";

            public const string Paid = "paid";

            public const string OrderStatusId = "order_status_id";

            public const string CreatedBy = "created_by";

            public const string CreatedOn = "created_on";

            public const string UpdatedBy = "updated_by";

            public const string UpdatedOn = "updated_on";
        }
    }
}