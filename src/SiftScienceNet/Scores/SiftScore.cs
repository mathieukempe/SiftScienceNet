using System.Collections.Generic;
using Newtonsoft.Json;

namespace SiftScienceNet.Scores
{
    public class Details
    {
        [JsonProperty("users")]
        public string Users { get; set; }
    }

    public class ScoreReason
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("details")]
        public Details Details { get; set; }
    }

    public class SiftScore
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("reasons")]
        public List<ScoreReason> Reasons { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}