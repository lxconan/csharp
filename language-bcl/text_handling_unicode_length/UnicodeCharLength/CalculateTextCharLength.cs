using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace UnicodeCharLength
{
    /* 
     * Description
     * ===========
     * 
     * This test will introduce the concept of Codepoint and surrogate pair to you. But
     * for the most of the cases, the character can fit in 16-bit unicode character.
     * 
     * Please implement the function `GetCharacterLength` to calculate how many unicode
     * character are there in a string. But please note that the `string.Length` property
     * is the number of `char` instances in a string, which may not be the actual number
     * of unicode characters in that string.
     * 
     * Difficulty: Super Easy
     * 
     * Knowledge Point
     * ===============
     * 
     * - char.IsSurrogatePair
     * - dotnet `char` type represents a 16-bit UTF-16 encoded character for the most of
     *   the time. But there are exceptions called surrogate pair.
     * - [Unicode Wiki](https://en.wikipedia.org/wiki/Unicode).
     */
    public class CalculateTextCharLength
    {
        static IEnumerable<object[]> TestCases() =>
            new[]
            {
                new object[]{"", 0},
                new object[]{"12345", 5},
                new object[]{char.ConvertFromUtf32(0x2A601) + "1234", 5}
            };

        #region Please modifies the code to pass the test

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static int GetCharacterLength(string text)
        {
            throw new NotImplementedException();
        }

        #endregion

        [Theory]
        [MemberData(nameof(TestCases))]
        public void should_calculate_text_character_length(string testString, int expectedLength)
        {
            Assert.Equal(expectedLength, GetCharacterLength(testString));
        }

        [Fact]
        public void should_throw_if_input_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => GetCharacterLength(null));
        }
    }
}