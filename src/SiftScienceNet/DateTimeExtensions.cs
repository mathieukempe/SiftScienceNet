using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiftScienceNet
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts datetime to Unix Timestamp (ISO 8601)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToUnixTime(this DateTime value)
        {
            if (value.Kind != DateTimeKind.Utc) value = value.ToUniversalTime();

            var seconds = (long)(value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;

            return seconds;
        }
    }
}
