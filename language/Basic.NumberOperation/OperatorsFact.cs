using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Basic.NumberOperation
{
    public class OperatorsFact
    {
        [Fact]
        [SuppressMessage("ReSharper", "RedundantAssignment")]
        public void should_return_original_value_using_suffix_incremental()
        {
            int numberToIncrement = 1;
            int suffixIncrementalReturnValue = numberToIncrement++;

            #region edit area

            // change "default(int)" to correct value.
            const int expectedResult = default (int);

            #endregion

            Assert.Equal(expectedResult, suffixIncrementalReturnValue);
        }

        [Fact]
        public void should_return_incremented_value_using_prefix_incremental()
        {
            int numberToIncrement = 1;
            int prefixIncrementalReturnValue = ++numberToIncrement;

            #region edit area

            // change "default(int)" to correct value.
            const int expectedResult = default(int);

            #endregion

            Assert.Equal(expectedResult, prefixIncrementalReturnValue);
        }

        [Fact]
        public void should_throw_exception_if_integer_divided_by_zero()
        {
            int numerator = 1;
            int denominator = 0;

            #region edit area

            // change "typeof(ArgumentException)" to correct exception type.
            Type desiredExceptionType = typeof(ArgumentException);

            #endregion

            Assert.NotEqual(typeof(ArithmeticException), desiredExceptionType);
            Assert.NotEqual(typeof(SystemException), desiredExceptionType);
            Assert.NotEqual(typeof(Exception), desiredExceptionType);
            Assert.Throws(desiredExceptionType, () => numerator / denominator);
        }

        [Fact]
        public void should_overflow_silently_for_integer_operation()
        {
            var minimumValue = int.MinValue;
            --minimumValue;

            #region edit area

            // change "default(int)" to correct value.
            const int expectedResult = default(int);

            #endregion

            Assert.Equal(expectedResult, minimumValue);
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotAccessedVariable")]
        public void should_throw_on_checked_overflow()
        {
            var minimumValue = int.MinValue;

            #region edit area

            // change "typeof(ArgumentException)" to correct exception type.
            Type desiredExceptionType = typeof(ArgumentException);

            #endregion

            Assert.NotEqual(typeof(ArithmeticException), desiredExceptionType);
            Assert.NotEqual(typeof(SystemException), desiredExceptionType);
            Assert.NotEqual(typeof(Exception), desiredExceptionType);

            Assert.Throws(desiredExceptionType, () => { checked { --minimumValue; } });
        }

        [Fact]
        public void should_do_complement_operation()
        {
            #region edit area

            // change "default(int)" to correct value. You should use Hex representation.
            const int expectedResult = default (int);

            #endregion

            Assert.Equal(expectedResult, ~0xf);
        }

        [Fact]
        public void should_do_and_operation()
        {
            #region edit area

            // change "default(int)" to correct value. You should use Hex representation.
            const int expectedResult = default(int);

            #endregion

            Assert.Equal(expectedResult, (0xf0 & 0x33));
        }

        [Fact]
        public void should_do_or_operation()
        {
            #region edit area

            // change "default(int)" to correct value. You should use Hex representation.
            const int expectedResult = default(int);

            #endregion

            Assert.Equal(expectedResult, (0xf0 | 0x33));
        }

        [Fact]
        public void should_do_exclusive_or_operation()
        {
            #region edit area

            // change "default(int)" to correct value. You should use Hex representation.
            const int expectedResult = default(int);

            #endregion

            Assert.Equal(expectedResult, (0xff00 ^ 0x0ff0));
        }

        [Fact]
        public void should_do_shift_left_operation()
        {
            #region edit area

            // change "default(int)" to correct value. You should use Hex representation.
            const int expectedResult = default(int);

            #endregion

            Assert.Equal(expectedResult, (0x20 << 2));
        }

        [Fact]
        public void should_do_shift_right_operation()
        {
            #region edit area

            // change "default(int)" to correct value. You should use Hex representation.
            const int expectedResult = default(int);

            #endregion

            Assert.Equal(expectedResult, (0x20 >> 1));
        }

        [Fact]
        public void should_change_type_for_8_and_16_bit_number_arithmetic_operators()
        {
            const short shortNumber = 1;
            const short anotherShortNumber = 1;
            Type arithmeticOperatorResultType = (shortNumber + anotherShortNumber).GetType();

            #region edit area

            // change "typeof(short)" to correct type.
            Type expectedResult = typeof(short);

            #endregion

            Assert.Equal(expectedResult, arithmeticOperatorResultType);
        }

        [Fact]
        public void should_get_infinite_value_when_divide_by_zero_for_floating_point_number()
        {
            const double numerator = 1.0;
            const double denominator = 0.0;

            #region edit area

            // change "default(double)" to correct value.
            const double expectedResult = default(double);

            #endregion

            Assert.Equal(expectedResult, (numerator / denominator));
        }

        [Fact]
        public void should_get_nan_when_doing_certain_operation_for_floating_point_number()
        {
            const double numerator = 0;
            const double denominator = 0;

            #region edit area

            // change "default(double)" to correct value.
            const double expectedResult = default(double);

            #endregion

            Assert.Equal(expectedResult, (numerator / denominator));
        }
    }
}