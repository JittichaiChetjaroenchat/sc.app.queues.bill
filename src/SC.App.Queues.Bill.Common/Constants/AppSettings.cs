namespace SC.App.Queues.Bill.Common.Constants
{
    public class AppSettings
    {
        public class Applications
        {
            public class Buyer
            {
                public const string BaseUrl = "Applications:Buyer:BaseUrl";
            }

            public class Bill
            {
                public const string Name = "Applications:Bill:Name";
            }
        }

        public class Culture
        {
            public const string Default = "Culture:Default";

            public const string Supports = "Culture:Supports";
        }

        public class Databases
        {
            public class Area
            {
                public const string ConnectionString = "Databases:Area:ConnectionString";
            }

            public class Bill
            {
                public const string ConnectionString = "Databases:Bill:ConnectionString";
            }

            public class Courier
            {
                public const string ConnectionString = "Databases:Courier:ConnectionString";
            }

            public class Credit
            {
                public const string ConnectionString = "Databases:Credit:ConnectionString";
            }

            public class Customer
            {
                public const string ConnectionString = "Databases:Customer:ConnectionString";
            }

            public class Inventory
            {
                public const string ConnectionString = "Databases:Inventory:ConnectionString";
            }

            public class Order
            {
                public const string ConnectionString = "Databases:Order:ConnectionString";
            }

            public class Setting
            {
                public const string ConnectionString = "Databases:Setting:ConnectionString";
            }

            public class Streaming
            {
                public const string ConnectionString = "Databases:Streaming:ConnectionString";
            }
        }

        public class Services
        {
            public const string BaseUrl = "Services:BaseUrl";

            public class Bank
            {
                public const string BaseUrl = "Services:Bank:BaseUrl";
            }

            public class Messaging
            {
                public const string BaseUrl = "Services:Messaging:BaseUrl";
            }
        }

        public class Queues
        {
            public const string HostName = "Queues:HostName";

            public const string UserName = "Queues:UserName";

            public const string Password = "Queues:Password";
        }

        public class ElasticSearch
        {
            public const string Uri = "ElasticSearch:Uri";
        }

        public class Cache
        {
            public const string Configuration = "Cache:Configuration";

            public const string CacheTime = "Cache:CacheTime";
        }
    }
}