using System;
using basic.Common;
using Xunit;

namespace basic
{
    public class NestedTypes
    {
        [Fact]
        public void should_connect_with_plus_sign_when_get_type_of_nested_class()
        {
            Type typeOfNestedType = typeof(NestedTypeDemoClass.NestedType.NestedNestedType);

            string fullName = typeOfNestedType.FullName;

            // correct the value of expectedFullName to fix the test.
            const string expectedFullName = "basic.Common.NestedTypeDemoClass+NestedType+NestedNestedType";

            Assert.Equal(expectedFullName, fullName);
        }
    }
}