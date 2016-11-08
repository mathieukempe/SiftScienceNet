using System;
using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    [JsonConverter(typeof(StatusConverter))]
    public enum Source
    {
        Automated,
        ManualReview
    }

    public class SourceConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Source source = (Source)value;

            if (source == Source.Automated)
                writer.WriteValue("$automated");

            if (source == Source.ManualReview)
                writer.WriteValue("$manual_review"); 
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Source);
        }
    }
}