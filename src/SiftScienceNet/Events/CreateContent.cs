using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiftScienceNet.Events
{
    public class CreateContent
    {
        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$session_id")]
        public string SessionId { get; set; }

        [JsonProperty("$contact_email")]
        public string ContactEmail { get; set; }

        [JsonProperty("$contact_phone")]
        public string ContactPhone { get; set; }

        [JsonProperty("$subject")]
        public string Subject { get; set; }        
    }
}
