using Newtonsoft.Json;

namespace SC.App.Queues.Bill.Queue.Models.Messaging
{
    public class Comment
    {
        [JsonProperty("sender")]
        public CommentSender Sender { get; set; }

        [JsonProperty("recipient")]
        public CommentRecipient Recipient { get; set; }

        [JsonProperty("content")]
        public CommentContent Content { get; set; }
    }

    public class CommentSender
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class CommentRecipient
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class CommentContent
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("link")]
        public CommentContentLink Link { get; set; }

        [JsonProperty("image")]
        public CommentContentImage Image { get; set; }

        [JsonProperty("text_image")]
        public CommentContentTextImage TextImage { get; set; }

        [JsonProperty("postback")]
        public CommentContentPostback Postback { get; set; }
    }

    public class CommentContentLink
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class CommentContentImage
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class CommentContentTextImage
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class CommentContentPostback
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("payload")]
        public string Payload { get; set; }
    }
}