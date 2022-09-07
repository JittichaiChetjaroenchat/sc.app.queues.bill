using System;
using Newtonsoft.Json;

namespace SC.App.Queues.Bill.Queue.Models.Bill
{
    public class NotifyBillBeforeCancel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public NotifyBillBeforeCancel(Guid id)
        {
            Id = id;
        }
    }
}