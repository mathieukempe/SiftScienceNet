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
        public const string EventsEndpoint = Authority + "/v203/events";
        public const string LabelsEndpoint = Authority + "/v203/users/{0}/labels";
        public const string ScoresEndpoint = Authority + "/v203/score/{0}/?api_key={1}";
    }    
}
