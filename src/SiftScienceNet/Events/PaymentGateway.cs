using System;
using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    [JsonConverter(typeof(PaymentGatewayConverter))]
    public enum PaymentGateway
    {
        Adyen,
        Affirm,
        Alipay,
        AltaPay,
        AmazonPayments,
        Authorizenet,
        Balanced,
        Beanstream,
        BluePay,
        Braintree,
        CCAvenue,
        ChasePaymentech,
        Checkoutcom,
        Ciel,
        Cofinoga,
        Coinbase,
        Collector,
        ComproPago,
        Conekta,
        CuentaDigital,
        CyberSource,
        DataCash,
        DebitWay,
        DIBS,
        DigitalRiver,
        Elavon,
        Epayeu,
        EProcessingNetwork,
        EWAY,
        FirstAtlanticCommerce,
        FirstData,
        Giropay,
        GlobalPayment,
        GlobalCollect,
        HDFCFSSnet,
        Ingenico,
        InternetSecure,
        IntuitQuickbooksPayments,
        Iugu,
        Jabong,
        MasterCardPaymentGateway,
        MercadoPago,
        MerchanteSolutions,
        Mirjeh,
        MoIP,
        Mollie,
        MonerisSolutions,
        NMI,
        Ogon,
        Omise,
        Openpaymx,
        OptimalPayments,
        PayFast,
        PayGate,
        PaymentExpress,
        PAYMILL,
        PayOne,
        PayPal,
        Paystation,
        PayTrace,
        Paytrail,
        Payture,
        PayU,
        PayULatam,
        Payza,
        PinPayments,
        PivotalPayments,
        PrincetonPaymentSolutions,
        PsiGate,
        QIWI,
        QuickPay,
        Raberil,
        Rede,
        Redpagos,
        Redsys,
        RewardsPay,
        RocketGate,
        SagePay,
        Sermepa,
        SimplifyCommerce,
        Skrill,
        SmartCoin,
        Sofort,
        SPSDecidir,
        Stripe,
        SynapsePay,
        TeleRecargas,
        Towah,
        TNSPay,
        TwoCheckout,
        UnionPay,
        USAePay,
        Vantiv,
        Veritrans,
        Venmo,
        Vindicia,
        VirtualCardServices,
        VME,
        WebpayOneclick,
        Wirecard,
        Worldpay
    }

    public class PaymentGatewayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            PaymentGateway paymentGateway = (PaymentGateway)value;

            if (paymentGateway == PaymentGateway.Adyen)
                writer.WriteValue("$adyen");
                    
            if (paymentGateway == PaymentGateway.Affirm)
                writer.WriteValue("$affirm");
                    
            if (paymentGateway == PaymentGateway.Alipay)
                writer.WriteValue("$alipay");
    
            if (paymentGateway == PaymentGateway.AltaPay)
                writer.WriteValue("$altapay");
                    
            if (paymentGateway == PaymentGateway.AmazonPayments)
                writer.WriteValue("$amazon_payments");
                    
            if (paymentGateway == PaymentGateway.Authorizenet)
                writer.WriteValue("$authorizenet");
                    
            if (paymentGateway == PaymentGateway.Balanced)
                writer.WriteValue("$balanced");
                    
            if (paymentGateway == PaymentGateway.Beanstream)
                writer.WriteValue("$beanstream");
                    
            if (paymentGateway == PaymentGateway.BluePay)
                writer.WriteValue("$bluepay");
                    
            if (paymentGateway == PaymentGateway.Braintree)
                writer.WriteValue("$braintree");                    

            if (paymentGateway == PaymentGateway.CCAvenue)
                writer.WriteValue("$ccavenue");

            if (paymentGateway == PaymentGateway.ChasePaymentech)
                writer.WriteValue("$chase_paymentech");

            if (paymentGateway == PaymentGateway.Checkoutcom)
                writer.WriteValue("$checkoutcom");

            if (paymentGateway == PaymentGateway.Ciel)
                writer.WriteValue("$ciel");

            if (paymentGateway == PaymentGateway.Cofinoga)
                writer.WriteValue("$cofinoga");

            if (paymentGateway == PaymentGateway.Coinbase)
                writer.WriteValue("$coinbase");

            if (paymentGateway == PaymentGateway.Collector)
                writer.WriteValue("$collector");

            if (paymentGateway == PaymentGateway.ComproPago)
                writer.WriteValue("$compropago");

            if (paymentGateway == PaymentGateway.Conekta)
                writer.WriteValue("$conekta");

            if (paymentGateway == PaymentGateway.CuentaDigital)
                writer.WriteValue("$cuentadigital");

            if (paymentGateway == PaymentGateway.CyberSource)
                writer.WriteValue("$cybersource");

            if (paymentGateway == PaymentGateway.DataCash)
                writer.WriteValue("$datacash");

            if (paymentGateway == PaymentGateway.DebitWay)
                writer.WriteValue("$debitway");

            if (paymentGateway == PaymentGateway.DIBS)
                writer.WriteValue("$dibs");

            if (paymentGateway == PaymentGateway.DigitalRiver)
                writer.WriteValue("$digital_river");

            if (paymentGateway == PaymentGateway.Elavon)
                writer.WriteValue("$elavon");

            if (paymentGateway == PaymentGateway.Epayeu)
                writer.WriteValue("$epayeu");

            if (paymentGateway == PaymentGateway.EProcessingNetwork)
                writer.WriteValue("$eprocessing_network");

            if (paymentGateway == PaymentGateway.EWAY)
                writer.WriteValue("$eway");

            if (paymentGateway == PaymentGateway.FirstAtlanticCommerce)
                writer.WriteValue("$first_atlantic_commerce");

            if (paymentGateway == PaymentGateway.FirstData)
                writer.WriteValue("$first_data");

            if (paymentGateway == PaymentGateway.Giropay)
                writer.WriteValue("$giropay");

            if (paymentGateway == PaymentGateway.GlobalPayment)
                writer.WriteValue("$global_payment");

            if (paymentGateway == PaymentGateway.GlobalCollect)
                writer.WriteValue("$globalcollect");

            if (paymentGateway == PaymentGateway.HDFCFSSnet)
                writer.WriteValue("$hdfc_fssnet");

            if (paymentGateway == PaymentGateway.Ingenico)
                writer.WriteValue("$ingenico");

            if (paymentGateway == PaymentGateway.InternetSecure)
                writer.WriteValue("$internetsecure");

            if (paymentGateway == PaymentGateway.IntuitQuickbooksPayments)
                writer.WriteValue("$intuit_quickbooks_payments");

            if (paymentGateway == PaymentGateway.Iugu)
                writer.WriteValue("$iugu");

            if (paymentGateway == PaymentGateway.Jabong)
                writer.WriteValue("$jabong");

            if (paymentGateway == PaymentGateway.MasterCardPaymentGateway)
                writer.WriteValue("$mastercard_payment_gateway");

            if (paymentGateway == PaymentGateway.MercadoPago)
                writer.WriteValue("$mercadopago");

            if (paymentGateway == PaymentGateway.MerchanteSolutions)
                writer.WriteValue("$merchant_esolutions");

            if (paymentGateway == PaymentGateway.Mirjeh)
                writer.WriteValue("$mirjeh");

            if (paymentGateway == PaymentGateway.MoIP)
                writer.WriteValue("$moip");

            if (paymentGateway == PaymentGateway.Mollie)
                writer.WriteValue("$mollie");

            if (paymentGateway == PaymentGateway.MonerisSolutions)
                writer.WriteValue("$moneris_solutions");

            if (paymentGateway == PaymentGateway.NMI)
                writer.WriteValue("$nmi");

            if (paymentGateway == PaymentGateway.Ogon)
                writer.WriteValue("$ogon");

            if (paymentGateway == PaymentGateway.Omise)
                writer.WriteValue("$omise");

            if (paymentGateway == PaymentGateway.Openpaymx)
                writer.WriteValue("$openpaymx");

            if (paymentGateway == PaymentGateway.OptimalPayments)
                writer.WriteValue("$optimal_payments");

            if (paymentGateway == PaymentGateway.PayFast)
                writer.WriteValue("$payfast");

            if (paymentGateway == PaymentGateway.PayGate)
                writer.WriteValue("$paygate");

            if (paymentGateway == PaymentGateway.PaymentExpress)
                writer.WriteValue("$payment_express");

            if (paymentGateway == PaymentGateway.PAYMILL)
                writer.WriteValue("$paymill");

            if (paymentGateway == PaymentGateway.PayOne)
                writer.WriteValue("$payone");

            if (paymentGateway == PaymentGateway.PayPal)
                writer.WriteValue("$paypal");

            if (paymentGateway == PaymentGateway.Paystation)
                writer.WriteValue("$paystation");

            if (paymentGateway == PaymentGateway.PayTrace)
                writer.WriteValue("$paytrace");

            if (paymentGateway == PaymentGateway.Paytrail)
                writer.WriteValue("$paytrail");

            if (paymentGateway == PaymentGateway.Payture)
                writer.WriteValue("$payture");

            if (paymentGateway == PaymentGateway.PayU)
                writer.WriteValue("$payu");

            if (paymentGateway == PaymentGateway.PayULatam)
                writer.WriteValue("$payulatam");

            if (paymentGateway == PaymentGateway.Payza)
                writer.WriteValue("$payza");

            if (paymentGateway == PaymentGateway.PinPayments)
                writer.WriteValue("$pinpayments");

            if (paymentGateway == PaymentGateway.PivotalPayments)
                writer.WriteValue("$pivotal_payments");

            if (paymentGateway == PaymentGateway.PrincetonPaymentSolutions)
                writer.WriteValue("$princeton_payment_solutions");

            if (paymentGateway == PaymentGateway.PsiGate)
                writer.WriteValue("$psigate");

            if (paymentGateway == PaymentGateway.QIWI)
                writer.WriteValue("$qiwi");

            if (paymentGateway == PaymentGateway.QuickPay)
                writer.WriteValue("$quickpay");

            if (paymentGateway == PaymentGateway.Raberil)
                writer.WriteValue("$raberil");

            if (paymentGateway == PaymentGateway.Rede)
                writer.WriteValue("$rede");

            if (paymentGateway == PaymentGateway.Redpagos)
                writer.WriteValue("$redpagos");

            if (paymentGateway == PaymentGateway.Redsys)
                writer.WriteValue("$redsys");

            if (paymentGateway == PaymentGateway.RewardsPay)
                writer.WriteValue("$rewardspay");

            if (paymentGateway == PaymentGateway.RocketGate)
                writer.WriteValue("$rocketgate");

            if (paymentGateway == PaymentGateway.SagePay)
                writer.WriteValue("$sagepay");

            if (paymentGateway == PaymentGateway.Sermepa)
                writer.WriteValue("$sermepa");

            if (paymentGateway == PaymentGateway.SimplifyCommerce)
                writer.WriteValue("$simplify_commerce");

            if (paymentGateway == PaymentGateway.Skrill)
                writer.WriteValue("$skrill");

            if (paymentGateway == PaymentGateway.SmartCoin)
                writer.WriteValue("$smartcoin");

            if (paymentGateway == PaymentGateway.Sofort)
                writer.WriteValue("$sofort");

            if (paymentGateway == PaymentGateway.SPSDecidir)
                writer.WriteValue("$sps_decidir");

            if (paymentGateway == PaymentGateway.Stripe)
                writer.WriteValue("$stripe");

            if (paymentGateway == PaymentGateway.SynapsePay)
                writer.WriteValue("$synapsepay");

            if (paymentGateway == PaymentGateway.TeleRecargas)
                writer.WriteValue("$telerecargas");

            if (paymentGateway == PaymentGateway.Towah)
                writer.WriteValue("$towah");

            if (paymentGateway == PaymentGateway.TNSPay)
                writer.WriteValue("$tnspay");

            if (paymentGateway == PaymentGateway.TwoCheckout)
                writer.WriteValue("$twocheckout");

            if (paymentGateway == PaymentGateway.UnionPay)
                writer.WriteValue("$unionpay");

            if (paymentGateway == PaymentGateway.USAePay)
                writer.WriteValue("$usa_epay");

            if (paymentGateway == PaymentGateway.Vantiv)
                writer.WriteValue("$vantiv");

            if (paymentGateway == PaymentGateway.Veritrans)
                writer.WriteValue("$veritrans");

            if (paymentGateway == PaymentGateway.Venmo)
                writer.WriteValue("$venmo");

            if (paymentGateway == PaymentGateway.Vindicia)
                writer.WriteValue("$vindicia");

            if (paymentGateway == PaymentGateway.VirtualCardServices)
                writer.WriteValue("$virtual_card_services");

            if (paymentGateway == PaymentGateway.VME)
                writer.WriteValue("$vme");

            if (paymentGateway == PaymentGateway.WebpayOneclick)
                writer.WriteValue("$webpay_oneclick");

            if (paymentGateway == PaymentGateway.Wirecard)
                writer.WriteValue("$wirecard");

            if (paymentGateway == PaymentGateway.Worldpay)
                writer.WriteValue("$worldpay");
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
