namespace SC.App.Queues.Bill.Business.Streaming.Database.Constants
{
    public class BookingChannel
    {
        public const string TableName = "booking_channels";

        public static class Column
        {
            public const string Id = "id";

            public const string Code = "code";

            public const string Description = "description";

            public const string Index = "index";
        }
    }
}