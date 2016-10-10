using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    public class Order
    {
        [JsonProperty("$order_id")]
        public string OrderId { get; set; }

        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$user_email")]
        public string UserEmail { get; set; }

        [JsonProperty("$session_id")]
        public string SessionId { get; set; }

        [JsonProperty("$amount")]
        public long Amount { get; set; }

        [JsonProperty("$seller_user_id")]
        public string SellerUserId { get; set; }

        [JsonProperty("$currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("$billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("$payment_methods")]
        public List<PaymentMethod> PaymentMethods { get; set; }

        [JsonProperty("$shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("$shipping_method")]
        public ShippingMethod ShippingMethod { get; set; }

        [JsonProperty("$items")]
        public List<Item> Items { get; set; }

        [JsonProperty("$expedited_shipping")]
        public bool? ExpeditedShipping { get; set; }

        [JsonProperty("$time")]
        public int? Time { get; set; }

        [JsonProperty("$ip")]
        public string Ip { get; set; }
    }

    [JsonConverter(typeof(ShippingMethodConverter))]
    public enum ShippingMethod
    {
        Physical,
        Electronic
    }

    public class ShippingMethodConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ShippingMethod method = (ShippingMethod)value;

            if (method == ShippingMethod.Physical)
                writer.WriteValue("$physical");

            if (method == ShippingMethod.Electronic)
                writer.WriteValue("$electronic");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ShippingMethod);
        }
    }
}