using System.Diagnostics.CodeAnalysis;
using basic.Common;
using Xunit;

namespace basic
{
    public class ImplicitAndExplicitConversions
    {
        [Fact]
        public void should_implicitly_convert_to_target_type()
        {
            Name name = "Bill Gates";

            // please update variable value to fix the test.
            const string expectedName = "";

            Assert.Equal(expectedName, name.ToString());
        }

        [Fact]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public void should_explicity_convert_to_target_type()
        {
            Name name = "Bill Gates";

            // please update variable value to fix the test.
            const string expectedName = "";

            Assert.Equal(expectedName, (string)name);            
        }
    }
}