namespace SC.App.Queues.Bill.Business.Customer.Database.Constants
{
    public class Customer
    {
        public const string TableName = "customers";

        public static class Column
        {
            public const string Id = "id";

            public const string ChannelId = "channel_id";

            public const string Name = "name";

            public const string IsNew = "is_new";

            public const string IsBlocked = "is_blocked";

            public const string CreatedOn = "created_on";

            public const string UpdatedOn = "updated_on";
        }
    }
}