namespace SC.App.Queues.Bill.Business.Streaming.Database.Constants
{
    public class BookingQueue
    {
        public const string TableName = "booking_queues";

        public static class Column
        {
            public const string Id = "id";

            public const string BookingChannelId = "booking_channel_id";

            public const string OfferingId = "offering_id";

            public const string LiveCommentId = "live_comment_id";

            public const string Amount = "amount";

            public const string IsConfirmed = "is_confirmed";

            public const string IsCancelled = "is_cancelled";

            public const string CreatedOn = "created_on";

            public const string ExpiredOn = "expired_on";
        }
    }
}