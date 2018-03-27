using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace HandleObject
{
    /* 
     * Description
     * ===========
     * 
     * This test will try invoke instance's member via reflection.
     * 
     * Difficulty: Medium
     * 
     * Knowledge Point
     * ===============
     * 
     * - MethodInfo.Invoke()
     * - PropertyInfo.GetValue() / SetValue()
     * 
     * Requirement
     * ===========
     * 
     * - All the operations should be accomplished by reflection.
     */
    public class InvokeMemberReflectively
    {
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "It will be called via reflection.")]
        class ReflectionSample
        {
            public string Say(string name)
            {
                return $"Hello {name}!";
            }

            public string Id { get; set; }
            public string Readonly { get; private set; }
            public string AnotherReadonly => "Hello";
            public string ThrowsProperty => throw new NotSupportedException();
        }

        #region Please modifies the code to pass the test
        
        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static object InvokeMethod(object instance, string methodName, params object[] args)
        {
            throw new NotImplementedException();
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static void SetProperty(object instance, string propertyName, object value)
        {
            throw new NotImplementedException();
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static object GetProperty(object instance, string propertyName)
        {
            throw new NotImplementedException();
        }

        #endregion

        [Fact]
        public void should_throw_if_instance_is_null()
        {
            Assert.Throws<ArgumentNullException>(
                "instance", 
                () => InvokeMethod(null, "MethodName"));
        }

        [Fact]
        public void should_throw_if_methodName_is_null()
        {
            Assert.Throws<ArgumentNullException>(
                "methodName",
                () => InvokeMethod(new ReflectionSample(), null));
        }

        [Fact]
        public void should_throw_if_method_not_found()
        {
            Assert.Throws<InvalidOperationException>(
                () => InvokeMethod(new ReflectionSample(), "NotExistedMethod"));
        }

        [Fact]
        public void should_invoke_method()
        {
            object result = InvokeMethod(new ReflectionSample(), "Say", "the name");

            Assert.Equal("Hello the name!", result);
        }

        [Fact]
        public void should_throw_if_instance_is_null_when_set_property()
        {
            Assert.Throws<ArgumentNullException>(
                "instance",
                () => SetProperty(null, "Id", "value"));
        }

        [Fact]
        public void should_throw_if_propertyName_is_null_when_set_property()
        {
            Assert.Throws<ArgumentNullException>(
                "propertyName",
                () => SetProperty(new ReflectionSample(), null, "value"));
        }

        [Fact]
        public void should_throw_if_propertyName_not_exist()
        {
            Assert.Throws<InvalidOperationException>(
                () => SetProperty(new ReflectionSample(), "NotExistedProp", "value"));
        }

        [Theory]
        [InlineData("Readonly")]
        [InlineData("AnotherReadonly")]
        public void should_throw_if_property_has_no_public_setter(string readonlyPropName)
        {
            Assert.Throws<InvalidOperationException>(
                () => SetProperty(new ReflectionSample(), readonlyPropName, "value"));
        }

        [Fact]
        public void should_set_and_get_property()
        {
            var instance = new ReflectionSample();
            const string expectedId = "SuperCoolId";

            SetProperty(instance, "Id", expectedId);
            Assert.Equal(expectedId, GetProperty(instance, "Id"));
        }

        [Fact]
        public void should_get_original_exception()
        {
            var instance = new ReflectionSample();
            Assert.Throws<NotSupportedException>(() => GetProperty(instance, "ThrowsProperty"));
        }
    }
}