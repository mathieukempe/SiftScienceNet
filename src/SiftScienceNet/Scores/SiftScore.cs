using System.Collections.Generic;
using Newtonsoft.Json;

namespace SiftScienceNet.Scores
{
    public class Details
    {
        [JsonProperty("users")]
        public string Users { get; set; }
    }

    public class ScoreReason
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("details")]
        public Details Details { get; set; }
    }

    public class LatestLabel
    {
        [JsonProperty("is_bad")]
        public bool IsBad { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }
    }

    public class SiftScore
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("reasons")]
        public List<ScoreReason> Reasons { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("latest_label")]
        public LatestLabel LatestLabel { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("actions")]
        public List<Action> Actions { get; set; }
    }

    public class Action
    {
        /// <summary>
        /// Unique id for this particular application of the action to this user. Used to reference our internal logs if needed
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Contains the id associated with the action. This is the ActionID generated when setting up the action in your console. 
        /// Unique id for this particular application of the action to this user. Used to reference internal logs if needed
        /// </summary>
        [JsonProperty("action")]
        public EntityWithId ActionId { get; set; }

        /// <summary>
        /// Contains the id of the entity the action was applied to (the user_id passed in the Score API call)
        /// </summary>
        [JsonProperty("entity")]
        public EntityWithId Entity { get; set; }

        /// <summary>
        /// The time the action was applied, as UNIX timestamp
        /// </summary>
        [JsonProperty("time")]
        public long Time { get; set; }

        /// <summary>
        /// A list of what triggered the application of this action to the user. For example, two Formulas and their ids
        /// </summary>
        [JsonProperty("triggers")]
        public List<TriggerType> Triggers { get; set; }
    }

    public class EntityWithId
    {
        [JsonProperty("id")]
        public string Id { get; set; }        
    }

    public class TriggerType
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("trigger")]
        public EntityWithId Trigger { get; set; }
    }
}