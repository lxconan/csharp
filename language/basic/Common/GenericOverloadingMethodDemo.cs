using System.Diagnostics.CodeAnalysis;

namespace basic.Common
{
    [SuppressMessage("ReSharper", "UnusedParameter.Global")]
    public class GenericOverloadingMethodDemo
    {
        public class Animal {}
        public class Giraffe {}

        public string Call(Animal animal) => "Call(Animal)";
        public string Call<T>(T animal) => "Call(T)";
    }
}