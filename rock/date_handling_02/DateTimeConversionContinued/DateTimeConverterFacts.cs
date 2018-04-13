using System;
using Xunit;

namespace DateTimeConversionContinued
{
    public class DateTimeConverterFacts
    {
        [Fact]
        public void should_conver_to_universal()
        {
            const string dateTimeString = "1990-02-01T22:30:49+08:00";
            DateTime dateTime = DateTimeConverter.ToUniversalDateTime(dateTimeString);

            Assert.Equal(DateTimeKind.Utc, dateTime.Kind);
            Assert.Equal(1990, dateTime.Year);
            Assert.Equal(02, dateTime.Month);
            Assert.Equal(01, dateTime.Day);
            Assert.Equal(14, dateTime.Hour);
            Assert.Equal(30, dateTime.Minute);
            Assert.Equal(49, dateTime.Second);
        }

        [Fact]
        public void should_treat_unspecified_time_zone_as_universal()
        {
            const string dateTimeString = "1990-02-01T22:30:49";
            DateTime dateTime = DateTimeConverter.ToUniversalDateTime(dateTimeString);

            Assert.Equal(DateTimeKind.Utc, dateTime.Kind);
            Assert.Equal(1990, dateTime.Year);
            Assert.Equal(02, dateTime.Month);
            Assert.Equal(01, dateTime.Day);
            Assert.Equal(22, dateTime.Hour);
            Assert.Equal(30, dateTime.Minute);
            Assert.Equal(49, dateTime.Second);
        }

        [Fact]
        public void should_throw_for_other_date_time_formats()
        {
            const string dateTimeString = "03/02/2001 20:21:22";
            Assert.Throws<FormatException>(() => DateTimeConverter.ToUniversalDateTime(dateTimeString));
        }
    }
}
