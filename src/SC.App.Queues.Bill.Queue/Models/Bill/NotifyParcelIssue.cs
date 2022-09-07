using System;
using Newtonsoft.Json;

namespace SC.App.Queues.Bill.Queue.Models.Bill
{
    public class NotifyParcelIssue
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public NotifyParcelIssue(Guid id)
        {
            Id = id;
        }
    }
}