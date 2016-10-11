using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    public class UpdateOrderStatus
    {
        [JsonProperty("$order_id")]
        public string OrderId { get; set; }

        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$order_status")]
        public OrderStatus? OrderStatus { get; set; }

        [JsonProperty("$reason")]
        public OrderStatusReason? Reason { get; set; }

        [JsonProperty("$source")]
        public OrderStatusSource? Source { get; set; }

        [JsonProperty("$analyst")]
        public string Analyst { get; set; }

        [JsonProperty("$webhook_id")]
        public string WebhookId { get; set; }

        [JsonProperty("$description")]
        public string Description { get; set; }

        [JsonProperty("$time")]
        public int? Time { get; set; }
    }

    [JsonConverter(typeof(OrderStatusConverter))]
    public enum OrderStatus
    {
        Approved,
        Canceled,
        Held,
        Fulfilled,
        Returned
    }

    [JsonConverter(typeof(OrderStatusReasonConverter))]
    public enum OrderStatusReason
    {
        PaymentRisk,
        Aabuse,
        Policy,
        Other
    }

    [JsonConverter(typeof(OrderStatusSourceConverter))]
    public enum OrderStatusSource
    {
        Automated,
        ManualReview,
    }

    public class OrderStatusConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var method = (OrderStatus)value;

            if (method == OrderStatus.Approved)
                writer.WriteValue("$approved");

            if (method == OrderStatus.Canceled)
                writer.WriteValue("$canceled");

            if (method == OrderStatus.Held)
                writer.WriteValue("$held");

            if (method == OrderStatus.Fulfilled)
                writer.WriteValue("$fulfilled");

            if (method == OrderStatus.Returned)
                writer.WriteValue("$returned");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(OrderStatus);
        }
    }

    public class OrderStatusReasonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var method = (OrderStatusReason)value;

            if (method == OrderStatusReason.PaymentRisk)
                writer.WriteValue("$payment_risk");

            if (method == OrderStatusReason.Aabuse)
                writer.WriteValue("$abuse");

            if (method == OrderStatusReason.Policy)
                writer.WriteValue("$policy");

            if (method == OrderStatusReason.Other)
                writer.WriteValue("$other");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(OrderStatusReason);
        }
    }

    public class OrderStatusSourceConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var method = (OrderStatusSource)value;

            if (method == OrderStatusSource.Automated)
                writer.WriteValue("$automated");

            if (method == OrderStatusSource.ManualReview)
                writer.WriteValue("$manual_review");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(OrderStatusSource);
        }
    }
}