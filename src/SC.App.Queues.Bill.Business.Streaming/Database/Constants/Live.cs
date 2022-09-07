namespace SC.App.Queues.Bill.Business.Streaming.Database.Constants
{
    public class Live
    {
        public const string TableName = "lives";

        public static class Column
        {
            public const string Id = "id";

            public const string ChannelId = "channel_id";

            public const string LiveId = "live_id";

            public const string TaskId = "task_id";

            public const string Title = "title";

            public const string Description = "description";

            public const string LiveStatusId = "live_status_id";

            public const string StartedOn = "started_on";

            public const string EndedOn = "ended_on";
        }
    }
}