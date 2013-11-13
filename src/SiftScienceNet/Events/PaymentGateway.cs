using System;
using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    public enum PaymentGateway
    {
        Stripe,
        Braintree,
        Paypal,
        AmazonPayments,
        Authorizenet        
    }

    public class PaymentGatewayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            PaymentGateway paymentGateway = (PaymentGateway)value;

            if (paymentGateway == PaymentGateway.Stripe)
                writer.WriteValue("$stripe");

            if (paymentGateway == PaymentGateway.Braintree)
                writer.WriteValue("$braintree");

            if (paymentGateway == PaymentGateway.Paypal)
                writer.WriteValue("$paypal");

            if (paymentGateway == PaymentGateway.AmazonPayments)
                writer.WriteValue("$amazon_payments");

            if (paymentGateway == PaymentGateway.Authorizenet)
                writer.WriteValue("$authorizenet");

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(PaymentGateway);
        }
    }
}