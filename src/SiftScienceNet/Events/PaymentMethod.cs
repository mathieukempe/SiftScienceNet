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
        public Status? VerificationStatus { get; set; }

        [JsonProperty("$routing_number")]
        public string RoutingNumber { get; set; }

        [JsonProperty("$decline_reason_code")]
        public string DeclineReasonCode { get; set; }

        [JsonProperty("$paypal_payer_id")]
        public string PaypalPayerId { get; set; }

        [JsonProperty("$paypal_payer_email")]
        public string PaypalPayerEmail { get; set; }

        [JsonProperty("$paypal_payer_status")]
        public string PaypalPayerStatus { get; set; }

        [JsonProperty("$paypal_protection_eligibility")]
        public string PaypalProtectionEligibility { get; set; }

        [JsonProperty("$paypal_payment_status")]
        public string PaypalPaymentStatus { get; set; }

        [JsonProperty("$stripe_token")]
        public string StripeToken { get; set; }

        [JsonProperty("$stripe_cvc_check")]
        public string StripeCvcCheck { get; set; }

        [JsonProperty("$stripe_address_line1_check")]
        public string StripeAddressLine1Check { get; set; }

        [JsonProperty("$stripe_address_line2_check")]
        public string StripeAddressLine2Check { get; set; }

        [JsonProperty("$stripe_address_zip_check")]
        public string StripeAddressZipCheck { get; set; }

        [JsonProperty("$stripe_funding")]
        public string StripeFunding { get; set; }

        [JsonProperty("$stripe_brand")]
        public string StripeBrand { get; set; }



    }



}