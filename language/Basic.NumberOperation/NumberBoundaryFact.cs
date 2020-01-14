using Xunit;

namespace Basic.NumberOperation
{
    public class NumberBoundaryFact
    {
        [Fact]
        public void should_get_minimum_value_of_a_number_type()
        {
            #region edit area
            
            // change "default(sbyte)" to correct value. You should not explicitly write -128.
            const sbyte minimum = default(sbyte);

            #endregion

            Assert.Equal(-128, minimum);
        }

        [Fact]
        public void should_get_maximum_value_of_a_number_type()
        {
            #region edit area
            
            // change "default(int)" to correct value. You should not explicitly write 2147483647.
            const int maximum = default(int);
            
            #endregion

            Assert.Equal(2147483647, maximum);
        }
    }
}