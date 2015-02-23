using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    public class Transaction
    {
        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$user_email")]
        public string UserEmail { get; set; }

        [JsonProperty("$transaction_type")]
        public TransactionType TransactionType { get; set; }

        [JsonProperty("$transaction_status")]
        public TransactionStatus Status { get; set; }

        [JsonProperty("$amount")]
        public long Amount { get; set; }

        [JsonProperty("$currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("$order_id")]
        public string OrderId { get; set; }

        [JsonProperty("$transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("$billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("$payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("$shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("$session_id")]
        public string SessionId { get; set; }

        [JsonProperty("$seller_user_id")]
        public string SellerUserId { get; set; }

        [JsonProperty("$time")]
        public int? Time { get; set; }
    }
}