using System;
using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    public class Account
    {
        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$user_email")]
        public string UserEmail { get; set; }

        [JsonProperty("$session_id")]
        public string SessionId { get; set; }

        [JsonProperty("$name")]
        public string Name { get; set; }

        [JsonProperty("$phone")]
        public string Phone { get; set; }

        [JsonProperty("$referrer_user_id")]
        public string ReferrerUserId { get; set; }

        [JsonProperty("$billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("$social_sign_on_type")]
        public SocialSignOn? SocialSignOn { get; set; }

        [JsonProperty("$changed_password")]
        public bool? ChangedPassword { get; set; }

        [JsonProperty("$time")]
        public int? Time { get; set; }
    }

    [JsonConverter(typeof(SocialSignOnConverter))]
    public enum SocialSignOn
    {
        Facebook,
        Google,
        Yahoo,
        Twitter,
        Other
    }

    public class SocialSignOnConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            SocialSignOn social = (SocialSignOn)value;

            if(social == SocialSignOn.Facebook)
                writer.WriteValue("$facebook");

            if (social == SocialSignOn.Google)
                writer.WriteValue("$google");

            if (social == SocialSignOn.Yahoo)
                writer.WriteValue("$yahoo");

            if (social == SocialSignOn.Twitter)
                writer.WriteValue("$twitter");

            if (social == SocialSignOn.Other)
                writer.WriteValue("$other");            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SocialSignOn);
        }
    }

  
    


}