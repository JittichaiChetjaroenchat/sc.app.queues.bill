namespace SC.App.Queues.Bill.Business.Courier.Database.Constants
{
    public class Order
    {
        public const string TableName = "orders";

        public static class Column
        {
            public const string Id = "id";

            public const string ChannelId = "channel_id";

            public const string RefId = "ref_id";

            public const string OrderStateStatusId = "order_state_status_id";

            public const string OrderStatusId = "order_status_id";

            public const string CreatedBy = "created_by";

            public const string CreatedOn = "created_on";

            public const string UpdatedBy = "updated_by";

            public const string UpdatedOn = "updated_on";
        }
    }
}