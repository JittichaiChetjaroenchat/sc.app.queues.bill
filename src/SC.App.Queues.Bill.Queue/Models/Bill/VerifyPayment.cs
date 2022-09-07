﻿using System;
using Newtonsoft.Json;

namespace SC.App.Queues.Bill.Queue.Models.Bill
{
    public class VerifyPayment
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public VerifyPayment(Guid id)
        {
            Id = id;
        }
    }
}