namespace SC.App.Queues.Bill.Business.Order.Database.Constants
{
    public class OrderStatus
    {
        public const string TableName = "order_statuses";

        public static class Column
        {
            public const string Id = "id";

            public const string Code = "code";

            public const string Description = "description";

            public const string Index = "index";
        }
    }
}