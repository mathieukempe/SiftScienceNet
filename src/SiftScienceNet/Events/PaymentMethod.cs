using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    public class PaymentMethod
    {
        [JsonProperty("$payment_type")]
        public PaymentType PaymentType { get; set; }

        [JsonProperty("$payment_gateway")]
        public PaymentGateway? PaymentGateway { get; set; }

        [JsonProperty("$card_bin")]
        public string CardBin { get; set; }

        [JsonProperty("$card_last4")]
        public string CardLast4 { get; set; }

        [JsonProperty("$avs_result_code")]
        public string AvsResultCode { get; set; }

        [JsonProperty("$cvv_result_code")]
        public string CvvResultCode { get; set; }

        [JsonProperty("$verification_status")]
        public Status VerificationStatus { get; set; }

        [JsonProperty("$routing_number")]
        public string RoutingNumber { get; set; }
    }


   
}