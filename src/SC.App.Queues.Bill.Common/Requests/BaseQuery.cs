using Microsoft.AspNetCore.Http;

namespace SC.App.Queues.Bill.Common.Requests
{
    public class BaseQuery
    {
        public HttpRequest Request { get; private set; }

        public BaseQuery(HttpRequest request)
        {
            Request = request;
        }
    }
}