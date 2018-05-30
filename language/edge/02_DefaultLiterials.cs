using Xunit;

namespace edge
{
    public class DefaultLiterialsFacts
    {
        [Fact]
        public void should_use_default_literial_as_default_of_op()
        {
            // Please correct the following statement to pass the test.
            const string expectedResult = "";
            
            Assert.Equal(expectedResult, MethodWithSomeParameter(default, default));
        }

        [Fact]
        public void default_literial_can_be_used_in_condition_test()
        {
            int integer = 0;

            if (integer == default)
            {
                integer = 1;
            }

            // Please correct the following statement to pass the test.
            const int expected = 0;
            
            Assert.Equal(expected, integer);
        }

        private string MethodWithSomeParameter(int integerValue, string stringValue)
        {
            return $"The integerValue is {integerValue} and stringValue is {stringValue ?? "(null)"}";
        }
    }
}