using System;
using FeatureToggle.Lib;
using Xunit;

namespace FeatureToggle.Facts
{
    public class FeatureToggleFacts
    {
        public FeatureToggleFacts()
        {
            AppContext.SetSwitch("experimental", false);
            AppContext.SetSwitch("edge", false);
            AppContext.SetSwitch("legacy", false);
        }
        
        [Theory]
        [InlineData("experimental", "Something really cool while not stable.")]
        [InlineData("edge", "Cutting edge technology!")]
        [InlineData("legacy", "Somebody likes the good old days.")]
        public void should_apply_feature_toggle(string flag, string expect)
        {
            AppContext.SetSwitch(flag, true);
            IFeature feature = FeatureFactory.Create();
            
            Assert.Equal(expect, feature.DoSomethingInteresting());
        }

        [Fact]
        public void should_get_the_normal_one()
        {
            IFeature feature = FeatureFactory.Create();
            
            Assert.Equal("Oh, finally the normal one.", feature.DoSomethingInteresting());
        }
    }
}