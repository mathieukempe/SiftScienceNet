using System;
using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    [JsonConverter(typeof(TransactionTypeConverter))]
    public enum TransactionType
    {
        Sale,
        Authorize,
        Capture,
        Void,
        Refund,
        Deposit,
        Withdrawal,
        Transfer
    }

    public class TransactionTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var transactionType = (TransactionType)value;

            if (transactionType == TransactionType.Sale)
                writer.WriteValue("$sale");

            if (transactionType == TransactionType.Authorize)
                writer.WriteValue("$authorize");

            if (transactionType == TransactionType.Capture)
                writer.WriteValue("$capture");

            if (transactionType == TransactionType.Void)
                writer.WriteValue("$void");

            if (transactionType == TransactionType.Refund)
                writer.WriteValue("$refund");

            if (transactionType == TransactionType.Deposit)
                writer.WriteValue("$deposit");

            if (transactionType == TransactionType.Refund)
                writer.WriteValue("$withdrawal");

            if (transactionType == TransactionType.Refund)
                writer.WriteValue("$transfer");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TransactionType);
        }
    }
}