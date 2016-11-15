using System;
using Newtonsoft.Json;

namespace SiftScienceNet.Labels
{   
    [JsonConverter(typeof(AbuseTypeConverter))]
    public enum AbuseType
    {
        Payment,
        Content,
        Promotion,
        Account
    }

    public class AbuseTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            AbuseType abuseType = (AbuseType)value;

            if (abuseType == AbuseType.Payment)
                writer.WriteValue("payment_abuse");

            if (abuseType == AbuseType.Content)
                writer.WriteValue("content_abuse");

            if (abuseType == AbuseType.Promotion)
                writer.WriteValue("promotion_abuse");

            if (abuseType == AbuseType.Account)
                writer.WriteValue("account_abuse");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AbuseType);
        }
    }
}