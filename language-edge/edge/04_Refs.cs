using Xunit;

namespace edge
{
    public class RefsFacts
    {
        static ref int GetElementAt(int[] array, int index)
        {
            return ref array[index];
        }
        
        [Fact]
        public void should_return_element_reference()
        {
            int[] numbers = {1, 2, 3, 4, 5, 6};

            ref int thirdElementRef = ref GetElementAt(numbers, 2);
            thirdElementRef = 100;

            // Please correct the following 2 statements to pass the test.
            const int firstExpectation = default;
            int[] secondExpectation = { };
            
            Assert.Equal(firstExpectation, numbers[2]);
            Assert.Equal(secondExpectation, numbers);
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

        [Fact]
        public void should_treat_as_normal_by_val_return_if_not_marked_explicitly()
        {
            int[] numbers = {1, 2, 3, 4, 5, 6};
            int value = GetElementAt(numbers, 2);

            // Please correct the following 2 lines to pass the test.
            const int firstExpectation = default;
            const int secondExpectation = default;
            
            Assert.Equal(firstExpectation, value);
            value = 100;
            Assert.Equal(secondExpectation, value);
        }
    }
}