using System;
using Xunit;
using Xunit.Abstractions;

namespace edge
{
    public class InParameters
    {
        struct ValueConstruct
        {
        }
        
        readonly ITestOutputHelper output;

        public InParameters(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void you_should_know_the_behavior_of_passing_by_value()
        {
            var value = new ValueConstruct();
            IntPtr argumentAddress = GetAddressOfValueField(value);
            
            unsafe
            {
                ValueConstruct* pointerToValue = &value;
                IntPtr valueAddress = (IntPtr)pointerToValue;

                // Please correct this line to pass the test.
                bool? areEqual = null;
                
                Assert.Equal(areEqual, argumentAddress == valueAddress);
                
                // Output some information to make you feel better
                output.WriteLine($"The value address is    0x{valueAddress.ToInt64():x}");
                output.WriteLine($"The argument address is 0x{argumentAddress.ToInt64():x}");
            }
        }

        [Fact]
        public void then_you_can_guess_what_in_parameter_behaves()
        {
            var value = new ValueConstruct();
            IntPtr argumentAddress = GetAddressOfValueField(in value);

            unsafe
            {
                ValueConstruct* pointerToValue = &value;
                var valueAddress = (IntPtr) pointerToValue;
                
                // Please correct this line to pass the test.
                bool? areEqual = null;
                
                Assert.Equal(areEqual, valueAddress == argumentAddress);
                
                // Output some information to make you feel better
                output.WriteLine($"The value address is    0x{valueAddress.ToInt64():x}");
                output.WriteLine($"The argument address is 0x{argumentAddress.ToInt64():x}");
            }
        }
        
        [Fact]
        public void do_you_think_if_the_in_parameter_be_changed()
        {
            int value = 5;
            TryModifyReadonlyRef(in value);

            // Please change the following line to pass the test.
            const int expect = default;
            
            Assert.Equal(expect, value);
        }

        static IntPtr GetAddressOfValueField(ValueConstruct parameter)
        {
            unsafe
            {
                ValueConstruct* pointer = &parameter;
                return (IntPtr) pointer;
            }
        }

        static IntPtr GetAddressOfValueField(in ValueConstruct parameter)
        {
            unsafe
            {
                // This is not an syntax error in C# 7.2
                fixed (ValueConstruct* ptr = &parameter)
                {   
                    return (IntPtr) ptr;
                }
            }
        }

        static void TryModifyReadonlyRef(in int value)
        {
            unsafe
            {
                fixed (int* ptr = &value)
                {
                    *ptr = 2;
                }
            }
        }
    }
}