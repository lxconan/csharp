using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace edge
{
    public class DiscardsFacts
    {
        [Fact]
        [SuppressMessage("ReSharper", "ConvertToConstant.Local")]
        public void a_crazy_discard_test_you_will_like()
        {
            int _ = 0xABCD;
            int value = 0xCDEF;
            if (int.TryParse("2345", out var _))
            {
                value = _;
            }

            // Please correct the following line to pass the test.
            const int expected = default;
            
            Assert.Equal(expected, value);
        }
    }
}