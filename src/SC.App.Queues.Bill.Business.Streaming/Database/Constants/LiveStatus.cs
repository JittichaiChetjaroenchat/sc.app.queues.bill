namespace SC.App.Queues.Bill.Business.Streaming.Database.Constants
{
    public class LiveStatus
    {
        public const string TableName = "live_statuses";

        public static class Column
        {
            public const string Id = "id";

            public const string Code = "code";

            public const string Description = "description";

            public const string Index = "index";
        }
    }
}