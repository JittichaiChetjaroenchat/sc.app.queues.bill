namespace SC.App.Queues.Bill.Business.Streaming.Database.Constants
{
    public class BookingUnlock
    {
        public const string TableName = "booking_unlocks";

        public static class Column
        {
            public const string Id = "id";

            public const string LiveId = "live_id";

            public const string LiveCommentorId = "live_commentor_id";

            public const string Enabled = "enabled";

            public const string CreatedOn = "created_on";
        }
    }
}