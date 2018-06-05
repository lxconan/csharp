using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace YieldPractice
{
    /* 
     * Description
     * ===========
     * 
     * This is the first test you have to complete to understand how to use "yield" keyword.
     * 
     * Difficulty: Super Easy
     * 
     * Knowledge Point
     * ===============
     * 
     * - We can implicitly implement IEnumerator<T> using `yield` keyword.
     * - You can use string constructor or `StringBuilder` to quickly create string with
     *   repeating characters.
     * 
     * Requirement
     * ===========
     * 
     * - No LINQ method is allowed to use in this test.
     */
    public class YieldReturnWillCreateStateMachine
    {
        #region Please modifies the code to pass the test 

        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        public IEnumerable<string> GetStringTriangle(char character, int count)
        {
            throw new NotImplementedException();
        }

        #endregion

        [Fact]
        public void should_get_skipped_sequences()
        {
            IEnumerable<string> enumerable = GetStringTriangle('*', 4);
            string[] expected =
            {
                "*",
                "**",
                "***",
                "****"
            };

            Assert.Equal(expected, enumerable);
        }

        [Fact]
        public void should_returns_enumerable_rather_than_collection()
        {
            IEnumerable<string> enumerable = GetStringTriangle('*', 2);
            Assert.False(enumerable is ICollection<string>);
        }
    }
}