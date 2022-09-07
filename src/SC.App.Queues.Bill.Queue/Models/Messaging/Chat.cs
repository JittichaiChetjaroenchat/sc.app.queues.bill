using System.Collections.Generic;
using Newtonsoft.Json;

namespace SC.App.Queues.Bill.Queue.Models.Messaging
{
    public class Chat
    {
        [JsonProperty("sender")]
        public ChatSender Sender { get; set; }

        [JsonProperty("recipient")]
        public ChatRecipient Recipient { get; set; }

        [JsonProperty("content")]
        public ChatContent Content { get; set; }
    }

    public class ChatSender
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class ChatRecipient
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class ChatContent
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("link")]
        public ChatContentLink Link { get; set; }

        [JsonProperty("image")]
        public ChatContentImage Image { get; set; }

        [JsonProperty("text_image")]
        public ChatContentTextImage TextImage { get; set; }

        [JsonProperty("postback")]
        public ChatContentPostback Postback { get; set; }

        [JsonProperty("postbacks")]
        public List<ChatContentPostback> Postbacks { get; set; }
    }

    public class ChatContentLink
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class ChatContentImage
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class ChatContentTextImage
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class ChatContentPostback
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("payload")]
        public string Payload { get; set; }
    }
}