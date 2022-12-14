using System.Collections.Generic;
using Newtonsoft.Json;
using SC.App.Queues.Bill.Common.Enums;

namespace SC.App.Queues.Bill.Common.Responses
{
    public class Response<T> where T : class
    {
        [JsonProperty("status")]
        public EnumResponseStatus Status { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("errors")]
        public ICollection<ResponseError> Errors { get; set; }
    }
}