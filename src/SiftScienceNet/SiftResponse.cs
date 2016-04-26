using Newtonsoft.Json;
using SiftScienceNet.Scores;

namespace SiftScienceNet
{
    public class SiftResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("request")]
        public string Request { get; set; }

        [JsonProperty("score_response")]
        public SiftScore Score { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Status, ErrorMessage);
        }
    }
}