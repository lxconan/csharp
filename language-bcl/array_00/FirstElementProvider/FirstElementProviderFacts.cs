using System;
using Xunit;

namespace FirstElementProvider
{
    public class FirstElementProviderFacts
    {
        [Fact]
        public void should_throw_if_array_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => ((Array) null).First());
        }

        [Fact]
        public void should_get_first_element_for_one_dim_array()
        {
            Assert.Equal(2, new [] {2,3,4}.First());
        }

        [Fact]
        public void should_get_first_element_for_multi_dims_array()
        {
            Assert.Equal(2, new[,]
            {
                {2, 3, 4},
                {3, 4, 5},
                {4, 5, 6}
            }.First());
        }
    }
}