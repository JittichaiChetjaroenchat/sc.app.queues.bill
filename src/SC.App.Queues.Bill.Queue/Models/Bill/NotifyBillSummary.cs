using System;
using Newtonsoft.Json;

namespace SC.App.Queues.Bill.Queue.Models.Bill
{
    public class NotifyBillSummary
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public NotifyBillSummary(Guid id)
        {
            Id = id;
        }
    }
}