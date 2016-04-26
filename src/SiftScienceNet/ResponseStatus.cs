using SiftScienceNet.Events;
using SiftScienceNet.Scores;

namespace SiftScienceNet
{
    public class ResponseStatus
    {
        public bool Success { get; set; }

        public SiftResponse SiftResponse { get; set; }

        public int StatusCode { get; set; }
    }
}
