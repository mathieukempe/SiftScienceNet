using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiftScienceNet
{
    public class Globals
    {
        public const string Authority = "https://api.siftscience.com";
        public const string EventsEndpoint = Authority + "/v204/events";
        public const string EventsWithScoreEndpoint = EventsEndpoint + "?return_action=true";
        public const string LabelsEndpoint = Authority + "/v204/users/{0}/labels";
        public const string ScoresEndpoint = Authority + "/v204/score/{0}/?api_key={1}";
    }    
}
