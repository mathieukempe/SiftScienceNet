using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiftScienceNet.Events
{
    public class Content
    {
        [JsonProperty("$user_id")]
        public string UserId { get; set; }

        [JsonProperty("$session_id")]
        public string SessionId { get; set; }

        [JsonProperty("$contact_email")]
        public string ContactEmail { get; set; }

        [JsonProperty("$contact_phone")]
        public string ContactPhone { get; set; }

        [JsonProperty("$content_id")]
        public string ContentId { get; set; }

        [JsonProperty("$subject")]
        public string Subject { get; set; }

        [JsonProperty("$content")]
        public string Content1 { get; set; }

        [JsonProperty("$amount")]
        public long? Amount { get; set; }

        [JsonProperty("$currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("$categories")]
        public IEnumerable<string> Categories { get; set; }

        [JsonProperty("$locations")]
        public IEnumerable<Address> Locations { get; set; }

        [JsonProperty("$image_hashes")]
        public IEnumerable<string> ImageHashes { get; set; }

        [JsonProperty("$expiration_time")]
        public int? ExpirationTime { get; set; }

        [JsonProperty("$status")]
        public ContentStatus? Status { get; set; }

        [JsonProperty("$time")]
        public int? Time { get; set; }
    }

    [JsonConverter(typeof(ContentStatusConverter))]
    public enum ContentStatus
    {
        Draft,
        Pending,
        Active,
        Paused,
        DeletedByUser,
        DeletedByCompany
    }

    public class ContentStatusConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var method = (ContentStatus)value;

            if (method == ContentStatus.Draft)
                writer.WriteValue("$draft");

            if (method == ContentStatus.Pending)
                writer.WriteValue("$pending");

            if (method == ContentStatus.Active)
                writer.WriteValue("$active");

            if (method == ContentStatus.Paused)
                writer.WriteValue("$paused");

            if (method == ContentStatus.DeletedByUser)
                writer.WriteValue("$deleted_by_user");

            if (method == ContentStatus.DeletedByCompany)
                writer.WriteValue("$deleted_by_company");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ContentStatus);
        }
    }
}
