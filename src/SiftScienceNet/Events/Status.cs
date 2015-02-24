using System;
using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    [JsonConverter(typeof(StatusConverter))]
    public enum Status
    {
        Success,
        Failure,
        Pending
    }

    public class StatusConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Status status = (Status)value;

            if (status == Status.Success)
                writer.WriteValue("$success");

            if (status == Status.Failure)
                writer.WriteValue("$failure");

            if (status == Status.Pending)
                writer.WriteValue("$pending");            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Status);
        }
    }
}