namespace FeatureToggle.Lib
{
    class ExperimentalFeature : IFeature
    {
        public string DoSomethingInteresting()
        {
            return "Something really cool while not stable.";
        }
    }
}