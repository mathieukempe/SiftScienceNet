using System;
using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    public enum TransactionStatus
    {
        Success,
        Failure,
        Pending
    }

    public class TransactionStatusConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            TransactionStatus transactionStatus = (TransactionStatus)value;

            if (transactionStatus == TransactionStatus.Success)
                writer.WriteValue("$success");

            if (transactionStatus == TransactionStatus.Failure)
                writer.WriteValue("$failure");

            if (transactionStatus == TransactionStatus.Pending)
                writer.WriteValue("$pending");            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TransactionStatus);
        }
    }
}