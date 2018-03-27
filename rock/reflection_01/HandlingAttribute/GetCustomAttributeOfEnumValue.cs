using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace HandlingAttribute
{
    /* 
     * Description
     * ===========
     * 
     * This test will try get metadata information on MemberInfo. The Attribute class
     * can be used on different senarios, which is specified by `AttributeUsage`.
     * Since it is metadata, it could be annotated only on definition level, not runtime.
     * To get that metadata, you should first get correspond reflection strcuture.
     * e.g. Type, MemberInfo.
     * 
     * This test will create an attribute only applied to fields of Enum. You should
     * write an extension method to get description attached on metadata.
     * 
     * Difficulty: Medium
     * 
     * Knowledge Point
     * ===============
     * 
     * - Enum type.
     * - GetType(), GetMember().
     */
    static class EnumDescriptionExtension
    {
        #region Please modifies the code to pass the test

        public static string GetDescription<T>(this T value)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    [AttributeUsage(AttributeTargets.Field)]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    class MyEnumDescriptionAttribute : Attribute
    {
        public MyEnumDescriptionAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; }
    }

    public class GetCustomAttributeOfEnumValue
    {
        enum ForTest
        {
            [MyEnumDescription("Awesome name!")]
            ValueWithDescription,
            ValueWithoutDescription
        }

        [Fact]
        public void should_throw_if_null()
        {
            Assert.Throws<ArgumentNullException>(() => default(string).GetDescription());
        }

        [Fact]
        public void should_throw_if_not_enum()
        {
            Assert.Throws<NotSupportedException>(() => 1.GetDescription());
        }

        [Fact]
        public void should_get_custom_attribute()
        {
            Assert.Equal("Awesome name!", ForTest.ValueWithDescription.GetDescription());
        }

        [Fact]
        public void should_get_origin_value()
        {
            Assert.Equal("ValueWithoutDescription", ForTest.ValueWithoutDescription.GetDescription());
        }
    }
}