using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace ConvertDateTime
{
    /* 
     * Description
     * ===========
     * 
     * This test will enumerate all datetime information in a text stream. Each line is 
     * represented as:
     * 
     * "{culture information abbr. / date time pattern string}|{formatted date time string}"
     * 
     * All datetimes are defined within UTC timezone. Please implement a function called
     * `EnumerateDateTimes` to get actual DateTime objects from the stream.
     * 
     * Difficulty: Medium
     * 
     * Knowledge Point
     * ===============
     * 
     * - DateTime.ParseExtact / DateTime.Parse
     * - How to get different culture info objects.
     */
    public class ConvertDateTimeFromString
    {
        static Stream CreateTextStreamWithDateTimes(string[] dateTimeStrings)
        {
            var stream = new MemoryStream();
            using (var writer = new StreamWriter(stream, Encoding.UTF8, 32 * 1024, true))
            {
                foreach (string dateTimeString in dateTimeStrings)
                {
                    writer.WriteLine(dateTimeString);
                }
                writer.Flush();
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        #region Please modifies the code to pass the test

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static IEnumerable<DateTime> EnumerateDateTimes(Stream stream)
        {
            throw new NotImplementedException();
        }

        #endregion

        [Fact]
        public void should_convert_datetime_string_correctly()
        {
            var stream = CreateTextStreamWithDateTimes(
                new[]
                {
                    "tr-TR|2.1.2013 00:00:00",
                    "zh-CN|2013/1/2 0:00:00",
                    "en-US|1/2/2013 12:00:00 AM",
                    "ja-JP|2013/01/02 0:00:00",
                    "yyyyMMdd hh:mm:ss|20130102 00:00:00"
                });

            IEnumerable<DateTime> dateTimes = EnumerateDateTimes(stream);

            Assert.True(dateTimes.All(dt => dt.ToUniversalTime().Equals(new DateTime(2013, 1, 2, 0, 0, 0, DateTimeKind.Utc))));
        }

        [Fact]
        public void should_not_load_all_information_into_memories()
        {
            var stream = CreateTextStreamWithDateTimes(
                new[]
                {
                    "tr-TR|2.1.2013 00:00:00",
                    "zh-CN|2013/1/2 0:00:00",
                    "en-US|1/2/2013 12:00:00 AM",
                    "ja-JP|2013/01/02 0:00:00",
                    "yyyyMMdd hh:mm:ss|20130102 00:00:00"
                });

            IEnumerable<DateTime> dateTimes = EnumerateDateTimes(stream);

            Assert.False(dateTimes is ICollection);
        }
    }
}