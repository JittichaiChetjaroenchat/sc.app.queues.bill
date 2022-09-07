using System;
using Newtonsoft.Json;

namespace SC.App.Queues.Bill.Queue.Models.Bill
{
    public class CancelBill
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public CancelBill(Guid id)
        {
            Id = id;
        }
    }
}