using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace VariantFacts
{
    public class ItMayViolatePolymorphsim
    {
        class BaseClass { }
        class DerivedClassA : BaseClass { }
        class DerivedClassB : BaseClass { }

        [SuppressMessage("ReSharper", "CoVariantArrayConversion")]
        static BaseClass[] ToBaseClassArray(DerivedClassA[] subclassArray)
        {
            #region Please modify the code below to pass the test
            
            // In this test, you will the historical reason for the dangerous usage of array. And
            // You will get the concept of co-variance and contra-variance. This test is not hard
            // to pass, but it is very hard to explain.
            //
            // Difficulty: Easy
            //
            // Knowledge Point: co-variance / contra-variance.
            
            return subclassArray;
            
            #endregion
        }
        
        [Fact]
        public void should_not_violate_ploymorphism()
        {
            DerivedClassA[] subClassArray = {new DerivedClassA()};
            BaseClass[] baseClassArray = ToBaseClassArray(subClassArray);

            var derivedClassB = new DerivedClassB();
            
            baseClassArray[0] = derivedClassB;
            
            Assert.Same(derivedClassB, baseClassArray[0]);
        }
    }
}