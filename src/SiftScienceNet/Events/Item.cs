using System.Collections.Generic;
using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    public class Item
    {
        [JsonProperty("$item_id")]
        public string ItemId { get; set; }        

        [JsonProperty("$product_title")]
        public string ProductTitle { get; set; }

        [JsonProperty("$price")]
        public int Price { get; set; }

        [JsonProperty("$currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("$upc")]
        public string Upc { get; set; }

        [JsonProperty("$sku")]
        public string Sku { get; set; }

        [JsonProperty("$isbn")]
        public string Isbn { get; set; }

        [JsonProperty("$brand")]
        public string Brand { get; set; }

        [JsonProperty("$manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("$category")]
        public string Category { get; set; }

        [JsonProperty("$tags")]
        public IEnumerable<string> Tags { get; set; }

        [JsonProperty("$color")]
        public string Color { get; set; }

        [JsonProperty("$size")]
        public string Size { get; set; }

        [JsonProperty("$quantity")]
        public int? Quantity { get; set; }
    }
}