using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SiftScienceNet.Events;
using SiftScienceNet.Labels;
using SiftScienceNet.Scores;

namespace SiftScienceNet
{
    public interface ISiftScienceClient
    {
        Task<ResponseStatus> CustomEvent(string userId, string type, dynamic customFields = null, bool returnScore = false);
        Task<ResponseStatus> CreateOrder(Order order, dynamic customFields = null, bool returnScore = false);
        Task<ResponseStatus> UpdateOrder(Order order, dynamic customFields = null, bool returnScore = false);
        Task<ResponseStatus> Transaction(Transaction transaction, dynamic customFields = null, bool returnScore = false);
        Task<ResponseStatus> CreateAccount(Account account, dynamic customFields = null, bool returnScore = false);
        Task<ResponseStatus> UpdateAccount(Account account, dynamic customFields = null, bool returnScore = false);
        Task<ResponseStatus> AddItemToCart(string userId, Item item, string sessionId = "", bool returnScore = false);
        Task<ResponseStatus> RemoveItemToCart(string userId, Item item, int quantity, string sessionId = "", bool returnScore = false);
        Task<ResponseStatus> SubmitReview(Review review, dynamic customFields = null, bool returnScore = false);
        Task<ResponseStatus> CreateContent(Content content, dynamic customFields = null, bool returnScore = false);
        Task<ResponseStatus> UpdateContent(Content content, dynamic customFields = null, bool returnScore = false);
        Task<ResponseStatus> SendMessage(string userId, string recipientUserId, string subject = "", string content = "", int? time = null, bool returnScore = false);
        Task<ResponseStatus> Login(string userId, string sessionId, bool success, bool returnScore = false);
        Task<ResponseStatus> Logout(string userId, bool returnScore = false);
        Task<ResponseStatus> LinkSessionToUser(string userId, string sessionId, bool returnScore = false);
        Task<ResponseStatus> Label(string userId, bool isBad, IEnumerable<Labels.Reason> reasons = null, string description = "", string analyst = "", string source = "");
        Task<ScoreResponse> GetSiftScore(string userId);
    }

    /// <summary>
    /// see:https://siftscience.com/docs/rest-api
    /// </summary>
    public class SiftScienceClient : ISiftScienceClient
    {
        private static string _apiKey;
        
        public SiftScienceClient(string apiKey)
        {
            _apiKey = apiKey;                        
        }

        #region Events

        public async Task<ResponseStatus> CustomEvent(string userId, string type, dynamic customFields = null, bool returnScore = false)
        {
            JObject o = new JObject();

            if (customFields != null)
                o = JObject.Parse(JsonConvert.SerializeObject(customFields));

            o.Add("$api_key", _apiKey);
            o.Add("$type", type);
            o.Add("$user_id", userId);
            o.Add("$time", DateTime.UtcNow.ToUnixTimestamp());

            return await PostEvent(o.ToString(), returnScore).ConfigureAwait(false); ;
        }


        public async Task<ResponseStatus> CreateOrder(Order order, dynamic customFields = null, bool returnScore = false)
        {
            JObject json = JObject.Parse(JsonConvert.SerializeObject(order, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$create_order");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> UpdateOrder(Order order, dynamic customFields = null, bool returnScore = false)
        {
            JObject json = JObject.Parse(JsonConvert.SerializeObject(order, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$update_order");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> UpdateOrderStatus(UpdateOrderStatus order, dynamic customFields = null, bool returnScore = false)
        {
            JObject json = JObject.Parse(JsonConvert.SerializeObject(order, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$order_status");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        private void AddCustomFields(dynamic customFields, JObject json, bool returnScore = false)
        {
            if (customFields != null)
            {
                JObject o = JObject.Parse(JsonConvert.SerializeObject(customFields, Formatting.None,new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore}));
                foreach (var value in o.Properties())
                {
                    json.Add(value);
                }
            }
        }

        public async Task<ResponseStatus> Transaction(Transaction transaction, dynamic customFields = null, bool returnScore = false)
        {
            JObject json = JObject.Parse(JsonConvert.SerializeObject(transaction, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$transaction");
            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> CreateAccount(Account account, dynamic customFields = null, bool returnScore = false)
        {
            JObject json = JObject.Parse(JsonConvert.SerializeObject(account, Formatting.None, new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore}));
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$create_account");
            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> Chargeback(Chargeback chargeback, dynamic customFields = null, bool returnScore = false)
        {
            JObject json = JObject.Parse(JsonConvert.SerializeObject(chargeback, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$chargeback");
            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> UpdateAccount(Account account, dynamic customFields = null, bool returnScore = false)
        {
            JObject json = JObject.Parse(JsonConvert.SerializeObject(account, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$update_account");
            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> AddItemToCart(string userId, Item item, string sessionId = "", bool returnScore = false)
        {
            JObject json = new JObject();
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$add_item_to_cart");
            json.Add("$user_id", userId);
            json.Add("$session_id", sessionId);
            
            var jObjectItem = JObject.Parse(JsonConvert.SerializeObject(item, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            json.Add("$item", jObjectItem);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> RemoveItemToCart(string userId, Item item, int quantity, string sessionId = "", bool returnScore = false)
        {
            JObject json = new JObject();
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$remove_item_from_cart");
            json.Add("$user_id", userId);
            json.Add("$session_id", sessionId);
            json.Add("$quantity", quantity);
                    
            var jObjectItem = JObject.Parse(JsonConvert.SerializeObject(item, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            json.Add("$item", jObjectItem);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> SubmitReview(Review review, dynamic customFields = null, bool returnScore = false)
        {
            JObject json = JObject.Parse(JsonConvert.SerializeObject(review, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$submit_review");
          
            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> CreateContent(Content content, dynamic customFields = null, bool returnScore = false)
        {
            JObject json = JObject.Parse(JsonConvert.SerializeObject(content, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$create_content");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> UpdateContent(Content content, dynamic customFields = null, bool returnScore = false)
        {
            JObject json = JObject.Parse(JsonConvert.SerializeObject(content, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            json.Add("$api_key", _apiKey);
            json.Add("$type", "$update_content");

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> FlagContent(string userId, string contentId, string flagedBy, dynamic customFields = null, bool returnScore = false)
        {
            var json = new JObject();

            json.Add("$type", "$flag_content");
            json.Add("$api_key", _apiKey);
            json.Add("$user_id", userId);
            json.Add("$content_id", contentId);
            json.Add("$flagged_by", flagedBy);

            AddCustomFields(customFields, json);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> SendMessage(string userId, string recipientUserId, string subject = "", string content = "", int? time = null, bool returnScore = false)
        {
            JObject json = new JObject();

            json.Add("$api_key", _apiKey);
            json.Add("$type", "$send_message");
            json.Add("$user_id", userId);
            json.Add("$recipient_user_id", recipientUserId);
            
            if(!String.IsNullOrEmpty(subject))
                json.Add("$subject", subject);

            if(!String.IsNullOrEmpty(content))
                json.Add("$content", content);

            if (time.HasValue)
                json.Add("$time", time.Value);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> Login(string userId, string sessionId, bool success, bool returnScore = false)
        {
            JObject json = new JObject();

            json.Add("$api_key", _apiKey);
            json.Add("$type", "$login");
            json.Add("$user_id", userId);
            json.Add("$session_id", sessionId);
            json.Add("$login_status", success ? "$success" : "$failure");

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> Logout(string userId, bool returnScore = false)
        {
            JObject json = new JObject();

            json.Add("$api_key", _apiKey);
            json.Add("$type", "$logout");
            json.Add("$user_id", userId);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> LinkSessionToUser(string userId, string sessionId, bool returnScore = false)
        {
            JObject json = new JObject();

            json.Add("$api_key", _apiKey);
            json.Add("$type", "$link_session_to_user");
            json.Add("$user_id", userId);
            json.Add("$session_id", sessionId);

            return await PostEvent(json.ToString(), returnScore).ConfigureAwait(false);
        }

        private async Task<ResponseStatus> PostEvent(string jsonContent, bool returnScore)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsync(returnScore ? Globals.EventsWithScoreEndpoint : Globals.EventsEndpoint, new StringContent(jsonContent, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            var siftResponse = JsonConvert.DeserializeObject<SiftResponse>(response.Content.ReadAsStringAsync().Result);

            return new ResponseStatus { Success = response.IsSuccessStatusCode, SiftResponse = siftResponse, StatusCode = (int)response.StatusCode };           
        }

        #endregion

        #region Labels

        public async Task<ResponseStatus> Label(string userId, bool isBad, IEnumerable<Labels.Reason> reasons = null, string description = "", string analyst = "", string source = "")
        {
            JObject json = new JObject();

            json.Add("$api_key", _apiKey);
            json.Add("$is_bad", isBad);
            json.Add("$user_id", Uri.EscapeDataString(userId));
            
            if(!string.IsNullOrEmpty(analyst))
                json.Add("$analyst", analyst);
            
            
            var reasonsForBad = new List<string>();
            if (reasons != null)
            {
                foreach (var reason in reasons)
                {
                    switch (reason)
                    {
                        case Labels.Reason.Chargeback:
                            reasonsForBad.Add("$chargeback");
                            break;
                        case Labels.Reason.DuplicateAccount:
                            reasonsForBad.Add("$duplicate_account");
                            break;
                        case Labels.Reason.Spam:
                            reasonsForBad.Add("$spam");
                            break;
                        case Labels.Reason.Fake:
                            reasonsForBad.Add("$fake");
                            break;
                        case Labels.Reason.Referral:
                            reasonsForBad.Add("$referral");
                            break;
                        case Labels.Reason.Funneling:
                            reasonsForBad.Add("$funneling");
                            break;
                    }
                }

                json.Add("$reasons", new JArray(reasonsForBad));
                json.Add("$source", source);                
            }
            
            if (!String.IsNullOrEmpty(description))
            {
                json.Add("$description", description);
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsync(string.Format(Globals.LabelsEndpoint, Uri.EscapeDataString(userId)), new StringContent(json.ToString(), Encoding.UTF8, "application/json")).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return new ResponseStatus { Success = true, StatusCode = (int) HttpStatusCode.OK};
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = JsonConvert.DeserializeObject<SiftResponse>(response.Content.ReadAsStringAsync().Result);

                return new ResponseStatus { Success = false, SiftResponse = error, StatusCode = (int)HttpStatusCode.BadRequest};
            }

            
            return new ResponseStatus { Success = false, StatusCode = (int)response.StatusCode};                        
        }

        #endregion

        #region Scores

        public async Task<ScoreResponse> GetSiftScore(string userId)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(string.Format(Globals.ScoresEndpoint, Uri.EscapeDataString(userId), _apiKey)).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;

                return new ScoreResponse { StatusCode = (int)response.StatusCode, SiftScore = JsonConvert.DeserializeObject<SiftScore>(json) }; 
            }
            
            return new ScoreResponse{StatusCode = (int)response.StatusCode};            
        }

        #endregion
               
    }
}