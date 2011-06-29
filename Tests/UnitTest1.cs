using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LastThursday;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var timezones = TimeZoneInfo.GetSystemTimeZones();
            var serverNow = new DateTime(2011, 5, 24, 21, 45, 0);
            var serverTimezone = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
            var serverUtcNow = serverNow.Subtract(serverTimezone.BaseUtcOffset);
          
            var possiblities = Timezones.GeneratePossibleMatches(9, 43, serverUtcNow);
        }
    }
}
