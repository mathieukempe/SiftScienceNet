using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiftScienceNet.Events
{
    public class Chargeback
    {
        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$order_id")]
        public string OrderId { get; set; }

        [JsonProperty("$transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("$chargeback_state")]
        public ChargebackState ChargebackState { get; set; }

        [JsonProperty("$chargeback_reason")]
        public ChargebackReason ChargebackReason { get; set; }
    }

    [JsonConverter(typeof(ChargebackStateConverter))]
    public enum ChargebackState
    {
        Received,
        Accepted,
        Disputed,
        Won,
        Lost
    }

    [JsonConverter(typeof(ChargebackReasonConverter))]
    public enum ChargebackReason
    {
        Fraud,
        Duplicate,
        Product_Not_Received,
        Product_Unacceptable,
        Other
    }

    public class ChargebackStateConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ChargebackState state = (ChargebackState)value;

            if (state == ChargebackState.Received)
                writer.WriteValue("$received");

            if (state == ChargebackState.Accepted)
                writer.WriteValue("$accepted");

            if (state == ChargebackState.Disputed)
                writer.WriteValue("$disputed");

            if (state == ChargebackState.Won)
                writer.WriteValue("$won");

            if (state == ChargebackState.Lost)
                writer.WriteValue("$lost");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ChargebackState);
        }
    }

    public class ChargebackReasonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ChargebackReason reason = (ChargebackReason)value;

            if (reason == ChargebackReason.Fraud)
                writer.WriteValue("$fraud");

            if (reason == ChargebackReason.Duplicate)
                writer.WriteValue("$duplicate");

            if (reason == ChargebackReason.Product_Not_Received)
                writer.WriteValue("$product_not_received");

            if (reason == ChargebackReason.Product_Unacceptable)
                writer.WriteValue("$product_unacceptable");

            if (reason == ChargebackReason.Other)
                writer.WriteValue("$other");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ChargebackReason);
        }
    }
}
