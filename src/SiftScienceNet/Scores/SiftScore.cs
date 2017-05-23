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

    public class LatestLabel
    {
        [JsonProperty("is_bad")]
        public bool IsBad { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }
    }

    public class SiftScore
    {
        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("reasons")]
        public List<ScoreReason> Reasons { get; set; }
    }
}