namespace SC.App.Queues.Bill.Business.Streaming.Database.Constants
{
    public class OfferingStatus
    {
        public const string TableName = "offering_statuses";

        public static class Column
        {
            public const string Id = "id";

            public const string Code = "code";

            public const string Description = "description";

            public const string Index = "index";
        }
    }
}