using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    public class Review
    {
        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$session_id")]
        public string SessionId { get; set; }

        [JsonProperty("$content")]
        public string Content { get; set; }

        [JsonProperty("$review_title")]
        public string ReviewTitle { get; set; }

        [JsonProperty("$item_id")]
        public string ItemId { get; set; }

        [JsonProperty("$reviewed_user_id")]
        public string ReviewedUserId { get; set; }

        [JsonProperty("$submission_status")]
        public Status SubmissionStatus { get; set; }

        [JsonProperty("$time")]
        public int? Time { get; set; }
    }
}