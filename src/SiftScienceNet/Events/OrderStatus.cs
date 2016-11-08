using System;
using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    [JsonConverter(typeof(StatusConverter))]
    public enum OrderStatus
    {
        Approved,
        Canceled,
        Held,
        Fulfilled,
        Returned
    }

    public class OrderStatusConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            OrderStatus status = (OrderStatus)value;

            if (status == OrderStatus.Approved)
                writer.WriteValue("$approved");

            if (status == OrderStatus.Canceled)
                writer.WriteValue("$canceled");

            if (status == OrderStatus.Held)
                writer.WriteValue("$held");

            if (status == OrderStatus.Fulfilled)
                writer.WriteValue("$fulfilled");

            if (status == OrderStatus.Returned)
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
}