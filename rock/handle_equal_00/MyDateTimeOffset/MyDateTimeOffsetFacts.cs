using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace MyDateTimeOffset
{
    public class MyDateTimeOffsetFacts
    {
        [Fact]
        public void should_compare_with_null()
        {
            var date = new AwesomeDateTimeOffset(DateTime.UtcNow, TimeSpan.FromHours(8));
            
            Assert.False(date.Equals(null));
            Assert.False(date == null);
            Assert.True(date != null);
        }

        [Fact]
        [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
        public void should_compare_with_other_type()
        {
            var date = new AwesomeDateTimeOffset(DateTime.UtcNow, TimeSpan.FromHours(8));
            
            Assert.False(date.Equals("hello"));
        }

        [Fact]
        public void should_compare_two_null_values()
        {
            AwesomeDateTimeOffset nullDate = null;
            
            Assert.True(nullDate == null);
            Assert.False(nullDate != null);
        }

        [Fact]
        public void should_compare_dates()
        {
            var time = new AwesomeDateTimeOffset(
                new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(8, 0, 0));
            var sameTime = new AwesomeDateTimeOffset(
                new DateTime(1999, 12, 31, 16, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 0, 0));
            
            Assert.True(time.Equals(sameTime));
            Assert.True(time == sameTime);
            Assert.False(time != sameTime);
        }
        
        
        [Fact]
        public void should_compare_dates_2()
        {
            var time = new AwesomeDateTimeOffset(
                new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(8, 0, 0));
            var differentTime = new AwesomeDateTimeOffset(
                new DateTime(1999, 12, 30, 16, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 0, 0));
            
            Assert.False(time == differentTime);
            Assert.True(time != differentTime);
            Assert.False(time.Equals(differentTime));
        }

        [Fact]
        public void should_get_same_hashcode_on_same_time()
        {
            var time = new AwesomeDateTimeOffset(
                new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(8, 0, 0));
            var sameTime = new AwesomeDateTimeOffset(
                new DateTime(1999, 12, 31, 16, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 0, 0));
            
            Assert.Equal(time.GetHashCode(), sameTime.GetHashCode());
        }

        [Fact]
        public void should_at_least_get_different_hash_code_on_below_times()
        {
            var time = new AwesomeDateTimeOffset(
                new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(8, 0, 0));
            var different = new AwesomeDateTimeOffset(
                new DateTime(1999, 12, 30, 16, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 0, 0));
            
            Assert.NotEqual(time.GetHashCode(), different.GetHashCode());
        }

        [Fact]
        public void should_force_to_minutes_for_offset()
        {
            Assert.Throws<ArgumentException>(() =>
                new AwesomeDateTimeOffset(DateTime.UtcNow, new TimeSpan(1, 2, 3)));
        }

        [Fact]
        public void should_modify_offset()
        {
            var time = new AwesomeDateTimeOffset(
                new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(8, 0, 0));
            var sameTime = new AwesomeDateTimeOffset(
                new DateTime(1999, 12, 31, 16, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 0, 0));

            sameTime.SetOffset(new TimeSpan(2, 0, 0));
            
            Assert.True(time.Equals(sameTime));
            Assert.True(time == sameTime);
            Assert.False(time != sameTime);
            Assert.Equal(time.GetHashCode(), sameTime.GetHashCode());
        }
    }
}