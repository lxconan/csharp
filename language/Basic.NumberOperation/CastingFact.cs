using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Basic.NumberOperation
{
    public class CastingFact
    {
        [Fact]
        public void should_cast_between_numeric_types()
        {
            const int originNumber = 12345;
            const long longNumber = originNumber;

            #region edit area

            // change "default(long)" to correct value.
            const long expectedResult = default(long);

            #endregion

            Assert.Equal(expectedResult, longNumber);
        }

        [Fact]
        public void should_cast_between_numeric_types_safely()
        {
            const int originNumber = 12345;
            const short shortNumber = (short) originNumber;

            #region edit area

            // change "default(short)" to correct value.
            const short expectedResult = default(short);

            #endregion

            Assert.Equal(expectedResult, shortNumber);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ConvertToConstant.Local")]
        public void should_truncate_value_when_cast_overflow()
        {
            var originNumber = 0x1234;
            var byteNumber = (byte) originNumber;

            #region edit area

            // change "default(byte)" to correct value.
            const byte expectedResult = default(byte);

            #endregion

            Assert.Equal(expectedResult, byteNumber);
        }

        [Fact]
        public void should_never_count_on_integer_floating_number_casting()
        {
            const int originalNumber = 100000001;
            const float floatingPointNumber = originalNumber;
            const int castedBackNumber = (int) floatingPointNumber;

            #region edit area

            // change "default(int)" to correct value.
            const int expectedResult = default (int);

            #endregion

            Assert.Equal(expectedResult, castedBackNumber);
        }

        [Fact]
        public void should_use_fix_point_number_to_do_safe_casting_in_valid_range()
        {
            const int originalNumber = 100000001;
            const decimal decimalNumber = originalNumber;
            const int castedBackNumber = (int)decimalNumber;

            #region edit area

            // change "default(int)" to correct value.
            const int expectedResult = default(int);

            #endregion

            Assert.Equal(expectedResult, castedBackNumber);
        }
    }
}