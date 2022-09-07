namespace SC.App.Queues.Bill.Business.Streaming.Database.Constants
{
    public class LiveCommentor
    {
        public const string TableName = "live_commentors";

        public static class Column
        {
            public const string Id = "id";

            public const string ChannelId = "channel_id";

            public const string ClientId = "client_id";

            public const string Name = "name";

            public const string PictureUrl = "picture_url";
        }
    }
}