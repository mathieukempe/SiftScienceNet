using Newtonsoft.Json;
using System.Collections.Generic;

namespace SiftScienceNet.Events
{
    public class OrderStatusEvent
    {
        [JsonProperty("$order_id")]
        public string OrderId { get; set; }

        [JsonProperty("$order_status")]
        public OrderStatus Status { get; set; }

        [JsonProperty("$reason")]
        public string Reason { get; set; }

        [JsonProperty("$source")]
        public Source? Source { get; set; }

        [JsonProperty("$analyst")]
        public string Analyst { get; set; }

        [JsonProperty("$webhook_id")]
        public string WebhookId { get; set; }

        [JsonProperty("$description")]
        public string Description { get; set; }
 
    }
}
