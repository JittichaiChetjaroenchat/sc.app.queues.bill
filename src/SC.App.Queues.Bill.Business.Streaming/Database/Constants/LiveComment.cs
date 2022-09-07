namespace SC.App.Queues.Bill.Business.Streaming.Database.Constants
{
    public class LiveComment
    {
        public const string TableName = "live_comments";

        public static class Column
        {
            public const string Id = "id";

            public const string LiveId = "live_id";

            public const string LiveCommentorId = "live_commentor_id";

            public const string MessageId = "message_id";

            public const string Message = "message";

            public const string IsProcessed = "is_processed";

            public const string CreatedOn = "created_on";
        }
    }
}