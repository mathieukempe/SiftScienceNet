using Newtonsoft.Json;
using SiftScienceNet.Labels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SiftScienceNet.Scores
{
    public class ScoreResponseBase
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonConverter(typeof(DictionaryWithAbuseTypeKeyConverter))]
        [JsonProperty("scores")]
        public Dictionary<AbuseType, SiftScore> Scores { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }

    public class LegacyScoreResponse : ScoreResponseBase
    {
        [JsonProperty("latest_labels")]
        public LatestLabel LatestLabels { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("reasons")]
        public List<ScoreReason> Reasons { get; set; }
    }

    public class ScoreResponse : ScoreResponseBase
    {
        [JsonProperty("latest_label")]
        public LatestLabel LatestLabel { get; set; }
    }

    public class DictionaryWithAbuseTypeKeyConverter : JsonConverter
    {
        // from http://stackoverflow.com/questions/31875103/deserializing-a-dictionary-key-from-json-to-an-enum-in-net
        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var valueType = objectType.GetGenericArguments()[1];
            var intermediateDictionaryType = typeof(Dictionary<,>).MakeGenericType(typeof(string), valueType);
            var intermediateDictionary = (IDictionary)Activator.CreateInstance(intermediateDictionaryType);
            serializer.Populate(reader, intermediateDictionary);

            var finalDictionary = (IDictionary)Activator.CreateInstance(objectType);
            foreach (DictionaryEntry pair in intermediateDictionary)
            {
                var str = pair.Key.ToString();
                AbuseType? abuseType = null;

                if (str.Equals("payment_abuse"))
                    abuseType = AbuseType.Payment;
                if (str.Equals("content_abuse"))
                    abuseType = AbuseType.Content;
                if (str.Equals("promotion_abuse"))
                    abuseType = AbuseType.Promotion;
                if (str.Equals("account_abuse"))
                    abuseType = AbuseType.Account;
                if (abuseType != null)
                {
                    finalDictionary.Add(abuseType.GetValueOrDefault(), pair.Value);
                }
            }

            return finalDictionary;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
