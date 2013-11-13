using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiftScienceNet.Scores
{
    public class ScoreResponse
    {
        public int StatusCode { get; set; }

        public SiftScore SiftScore { get; set; }
    }
}
