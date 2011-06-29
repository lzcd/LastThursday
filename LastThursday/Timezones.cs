using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LastThursday
{
    public class Timezones
    {

        public static IEnumerable<TimeZoneInfo> GeneratePossibleMatches(int hour, int minute, DateTime serverUtcNow, int errorMarginMinutes = 14)
        {
            var errorSpan = new TimeSpan(0,errorMarginMinutes,0);
            var alternateHour = (hour + 12) % 24;

            return from timezone in TimeZoneInfo.GetSystemTimeZones()
                      let timezoneTime = serverUtcNow.Add(timezone.BaseUtcOffset)
                      let minimumTime = timezoneTime.Subtract(errorSpan)
                      let maximumTime = timezoneTime.Add(errorSpan)
                      where (hour >= minimumTime.Hour &&
                            minute >= minimumTime.Minute &&
                            hour <= maximumTime.Hour &&
                            minute <= maximumTime.Minute) ||
                            (alternateHour >= minimumTime.Hour &&
                            minute >= minimumTime.Minute &&
                            alternateHour <= maximumTime.Hour &&
                            minute <= maximumTime.Minute)
                      select timezone;
 
        }
    }
}
