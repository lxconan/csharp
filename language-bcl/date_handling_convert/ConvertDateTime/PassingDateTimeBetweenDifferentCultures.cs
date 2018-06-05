using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Xunit;

namespace ConvertDateTime
{
    /* 
     * Description
     * ===========
     * 
     * This test will try passing date time between the boundary (e.g. via HTTP).
     * And the culture information at each site is different. You have to pass
     * the date time accurately.
     * 
     * Difficulty: Super Easy
     * 
     * Knowledge Point
     * ===============
     * 
     * - DateTime.ParseExtact / DateTime.Parse
     * - DateTime.ToString(string, IFormatProvider)
     */
    public class PassingDateTimeBetweenDifferentCultures
    {
        class CultureContext : IDisposable
        {
            readonly CultureInfo old;

            public CultureContext(CultureInfo culture)
            {
                old = CultureInfo.CurrentCulture;
                CultureInfo.CurrentCulture = culture;
            }

            public void Dispose()
            {
                CultureInfo.CurrentCulture = old;
            }
        }

        #region Please modifies the code to pass the test

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static DateTime DeserializeDateTimeFromTargetSite(string serialized)
        {
            throw new NotImplementedException();
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static string SerializeDateTimeFromCallerSite(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        #endregion

        [Theory]
        [MemberData(nameof(GetDateTimeForDifferentCultures))]
        public void should_pass_date_time_correctly_between_different_cultures(
            DateTime expected,
            CultureInfo from,
            CultureInfo to)
        {
            string serialized;

            using (new CultureContext(from))
            {
                serialized = SerializeDateTimeFromCallerSite(expected);
            }

            using (new CultureContext(to))
            {
                DateTime deserialized = DeserializeDateTimeFromTargetSite(serialized);
                Assert.Equal(expected.ToUniversalTime(), deserialized.ToUniversalTime());
            }
        }

        static IEnumerable<object[]> GetDateTimeForDifferentCultures()
        {
            return new[]
            {
                new object[] {new DateTime(2012, 8, 1, 0, 0, 0, DateTimeKind.Utc), new CultureInfo("zh-CN"), new CultureInfo("tr-TR")},
                new object[] {new DateTime(2012, 8, 1, 0, 0, 0, DateTimeKind.Utc), new CultureInfo("ja-JP"), new CultureInfo("en-US")}
            };
        }
    }
}