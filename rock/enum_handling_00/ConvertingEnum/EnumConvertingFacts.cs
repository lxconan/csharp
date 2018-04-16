using System;
using Xunit;

namespace ConvertingEnum
{
    public class EnumConvertingFacts
    {
        enum SByteEnum : sbyte
        {
            Default = 12
        }

        enum ULongEnum : ulong
        {
            Default = ulong.MaxValue
        }
        
        [Fact]
        public void should_only_support_integeral_type()
        {
            Assert.Throws<NotSupportedException>(() =>
                EnumConverter.GetIntegerValue<DateTime>(SByteEnum.Default));
        }
        
        [Fact]
        public void should_convert_any_enum_to_integer()
        {
            var value = EnumConverter.GetIntegerValue<sbyte>(SByteEnum.Default);
            
            Assert.Equal(12, value);
        }

        [Fact]
        public void should_convert_any_enum_to_integer_2()
        {
            var value = EnumConverter.GetIntegerValue<ulong>(ULongEnum.Default);
            
            Assert.Equal(ulong.MaxValue, value);
        }

        [Fact]
        public void should_convert_to_compatible_integer()
        {
            var value = EnumConverter.GetIntegerValue<long>(SByteEnum.Default);
            
            Assert.Equal(12, value);   
        }

        [Fact]
        public void should_throw_if_overflow_happens()
        {
            Assert.Throws<OverflowException>(() =>
                EnumConverter.GetIntegerValue<sbyte>(ULongEnum.Default));
        }
    }
}