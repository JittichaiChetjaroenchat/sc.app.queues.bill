namespace SC.App.Queues.Bill.Business.Setting.Database.Constants
{
    public class Preferences
    {
        public const string TableName = "preferences";

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

            public const string Language = "language";

            public const string Currency = "currency";
        }
    }
}