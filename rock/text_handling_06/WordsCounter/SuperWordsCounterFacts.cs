using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace WordsCounter
{
    public class SuperWordsCounterFacts
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("   ", 0)]
        [InlineData("   \tw   ", 1)]
        [InlineData("   \tw1  w2 ", 2)]
        [InlineData("   \tw1  w2  w3  ", 3)]
        public void should_count_words(string text, int expected)
        {
            var counter = new SuperWordsCounter();

            using (TextReader reader = new StringReader(text))
            {
                Assert.Equal(expected, counter.Count(reader));
            }
        }

        [Fact]
        public void should_throw_if_argument_is_null()
        {
            var counter = new SuperWordsCounter();

            Assert.Throws<ArgumentNullException>(() => counter.Count(null));
        }

        [Fact]
        public void should_accept_huge_text_stream()
        {
            var counter = new SuperWordsCounter();
            const int expectedWordCount = 512 * 1024 * 1024;

            using (var reader = new HugeTextStream(expectedWordCount))
            {
                Assert.Equal(expectedWordCount, counter.Count(reader));
            }
        }
    }
}