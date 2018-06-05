using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace TimeZoneHandling
{
    /* 
     * Description
     * ===========
     * 
     * This test will create a timezone table. The input of the timezone table is a `DateTime`
     * object defined in UTC timezone, and a list of target timezones, the output of each row
     * is as follows:
     * 
     * - A string indicating the id of the timezone
     * - A time span indicating the offset for this timezone from UTC at the specified time.
     * - A bool value indicating whether the target timezone is in the daylight saving time at
     *   specified moment.
     * - A string indicating the date time at target timezone. The value should be in a 
     *   `yyyy/MM/dd hh:mm:ss` format.
     * 
     * 
     * Difficulty: Super Easy
     * 
     * Knowledge Point
     * ===============
     * 
     * - Time convert using TimeZoneInfo class.
     * - Please pay attention to daylight saving time when you are doing time related calculation.
     */
    public class HandleDateTimeForDifferentTimezones
    {
        #region Please modifies the code to pass the test

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static IEnumerable<(string, TimeSpan, bool, string)> CreateTimezoneTable(
            DateTime universalTime, IEnumerable<TimeZoneInfo> timezones)
        {
            throw new NotImplementedException();
        }

        #endregion

        [Fact]
        public void should_create_timezone_table()
        {
            var timezones = new[] {"Central Standard Time", "Eastern Standard Time", "China Standard Time"}
                .Select(TimeZoneInfo.FindSystemTimeZoneById)
                .ToArray();

            (string, TimeSpan, bool, string)[] timezoneTable = 
                CreateTimezoneTable(new DateTime(2017, 7, 1, 0, 0, 0, DateTimeKind.Utc), timezones)
                    .ToArray();

            var expected = new[]
            {
                ("Central Standard Time", TimeSpan.FromHours(-5), true, "2017/06/30 07:00:00"),
                ("Eastern Standard Time", TimeSpan.FromHours(-4), true, "2017/06/30 08:00:00"),
                ("China Standard Time", TimeSpan.FromHours(8), false, "2017/07/01 08:00:00")
            };

            Assert.Equal(expected, timezoneTable);
        }
    }
}