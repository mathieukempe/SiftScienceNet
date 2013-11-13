using Newtonsoft.Json;

namespace SiftScienceNet
{
    public class Error
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("request")]
        public string Request { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Status, ErrorMessage);
        }
    }
}