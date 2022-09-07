using Newtonsoft.Json;

namespace SC.App.Queues.Bill.Queue.Models.Messaging
{
    public class Reaction
    {
        [JsonProperty("sender")]
        public ReactionSender Sender { get; set; }

        [JsonProperty("recipient")]
        public ReactionRecipient Recipient { get; set; }

        [JsonProperty("content")]
        public ReactionContent Content { get; set; }
    }

    public class ReactionSender
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class ReactionRecipient
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class ReactionContent
    {
        [JsonProperty("is_like")]
        public bool IsLike { get; set; }
    }
}