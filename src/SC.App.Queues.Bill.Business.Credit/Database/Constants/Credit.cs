namespace SC.App.Queues.Bill.Business.Credit.Database.Constants
{
    public class Credit
    {
        public const string TableName = "credits";

        public static class Column
        {
            public const string Id = "id";

            public const string ChannelId = "channel_id";

            public const string Balance = "balance";

            public const string CreatedBy = "created_by";

            public const string CreatedOn = "created_on";

            public const string UpdatedBy = "updated_by";

            public const string UpdatedOn = "updated_on";
        }
    }
}