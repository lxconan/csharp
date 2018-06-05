using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace HandleObject
{
    /* 
    * Description
    * ===========
    * 
    * This test will try create instance using reflection.
    * 
    * Difficulty: Super Easy
    * 
    * Knowledge Point
    * ===============
    * 
    * - Activator
    * 
    * Requirement
    * ===========
    * 
    * - You should create object using reflection. No "new" keyword is allowd.
    */
    public class CreateInstanceReflectively
    {
        [SuppressMessage("ReSharper", "ClassNeverInstantiated.Local", Justification = "It will be created reflectively")]
        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        class ReflectionSample
        {
            public string Message { get; }

            public ReflectionSample()
            {
                Message = "Default constructor";
            }

            public ReflectionSample(string name)
            {
                Message = $"Constructor with parameter: {name}";
            }
        }

        #region Please modifies the code to pass the test

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static ReflectionSample InvokeConstructor(string type, params object[] arguments)
        {
            throw new NotImplementedException();
        }

        #endregion

        [Fact]
        public void should_throws_if_type_is_null()
        {
            Assert.Throws<ArgumentNullException>("type", () => InvokeConstructor(null));
        }

        [Fact]
        public void should_invoke_public_default_ctor()
        {
            ReflectionSample instance = InvokeConstructor(typeof(ReflectionSample).FullName);
            Assert.Equal("Default constructor", instance.Message);
        }

        [Fact]
        public void should_invoke_public_ctor()
        {
            ReflectionSample instance = InvokeConstructor(typeof(ReflectionSample).FullName, "the name");
            Assert.Equal("Constructor with parameter: the name", instance.Message);
        }
    }
}