using SiftScienceNet.Events;

namespace SiftScienceNet
{
    public class ResponseStatus
    {
        public bool Success { get; set; }

        public Error Error { get; set; }

        public int StatusCode { get; set; }
    }
}
