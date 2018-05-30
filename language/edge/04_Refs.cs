using Xunit;

namespace edge
{
    public class RefsFacts
    {
        static ref int GetElementAt(int[] array, int index)
        {
            return ref array[index];;
        }
        
        [Fact]
        public void should_return_element_reference()
        {
            int[] numbers = {1, 2, 3, 4, 5, 6};

            int thirdElement = GetElementAt(numbers, 2);
            ref int thirdElementRef = ref GetElementAt(numbers, 2);
            thirdElementRef = 100;

            // Please correct the following 3 statements to pass the test.
            const int firstExpectation = default;
            const int secondExpectation = default;
            int[] thirdExpectation = { };
            
            Assert.Equal(firstExpectation, numbers[2]);
            Assert.Equal(secondExpectation, thirdElement);
            Assert.Equal(thirdExpectation, numbers);
        }

        [Fact]
        public void should_treat_lvalue_as_ref_return()
        {
            int[] numbers = {1, 2, 3, 4, 5, 6};
            GetElementAt(numbers, 2) = 100;
            
            // Please correct the following line to pass the test.
            int[] expect = { };
            
            Assert.Equal(expect, numbers);
        }
    }
}