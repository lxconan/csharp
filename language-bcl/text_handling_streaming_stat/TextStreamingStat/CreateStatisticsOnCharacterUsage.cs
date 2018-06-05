using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using TextStreamingStat.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace TextStreamingStat
{
    /* 
     * Description
     * ===========
     * 
     * This test will show the basic usage of text stream. In this test, you should create
     * a function `StatCharacterUsage` which accept an UTF-8 encoded text stream. The
     * function should returns a histogram containing the statistics of English character
     * usage (case insensitive). All non-English character will be ignored.
     * 
     * Difficulty: Super Hard
     * 
     * Knowledge Point
     * ===============
     * 
     * - Use `TextReader` to decode text content from binary stream.
     * - How to handle large stream using restricted memory block.
     * 
     * Requirement
     * ===========
     * 
     * - The memory efficiency should be O(1).
     * - This function should handle 128 MB of text within 12 seconds.
     */
    public class CreateStatisticsOnCharacterUsage
    {
        readonly ITestOutputHelper output;

        public CreateStatisticsOnCharacterUsage(ITestOutputHelper output)
        {
            this.output = output;
        }

        static Stream CreateStringStream(string text)
        {
            var stream = new MemoryStream();
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            stream.Write(textBytes, 0, textBytes.Length);
            stream.Flush();

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        #region Please modifies the code to pass the test

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static Dictionary<char, int> StatCharacterUsage(Stream stream)
        {
            throw new NotImplementedException();
        }

        #endregion

        [Fact]
        public void should_create_statistics_on_character_usage()
        {
            Stream textFileStream = CreateStringStream("A quick brown fox jumps over a lazy dog.");
            Dictionary<char, int> histogram = StatCharacterUsage(textFileStream);

            Assert.Equal(3, histogram['a']);
            Assert.Equal(1, histogram['q']);
            Assert.Equal(2, histogram['u']);
            Assert.Equal(1, histogram['i']);
            Assert.Equal(1, histogram['c']);
            Assert.Equal(1, histogram['k']);
            Assert.Equal(1, histogram['b']);
            Assert.Equal(2, histogram['r']);
            Assert.Equal(4, histogram['o']);
            Assert.Equal(1, histogram['w']);
            Assert.Equal(1, histogram['n']);
            Assert.Equal(1, histogram['f']);
            Assert.Equal(1, histogram['x']);
            Assert.Equal(1, histogram['j']);
            Assert.Equal(1, histogram['m']);
            Assert.Equal(1, histogram['p']);
            Assert.Equal(1, histogram['s']);
            Assert.Equal(1, histogram['v']);
            Assert.Equal(1, histogram['e']);
            Assert.Equal(1, histogram['l']);
            Assert.Equal(1, histogram['z']);
            Assert.Equal(1, histogram['y']);
            Assert.Equal(1, histogram['d']);
            Assert.Equal(1, histogram['g']);
        }

        [Fact]
        public void should_be_able_to_handle_very_large_stream()
        {
            const long length = 128 * 1024 * 1024;
            using (var stream = new Utf8RandomTextStream(length))
            {
                var watch = Stopwatch.StartNew();
                StatCharacterUsage(stream);
                watch.Stop();
                output.WriteLine($"Time used to handle {length / 1024 / 1024} MB of text: {watch.Elapsed:g}");
                Assert.True(watch.Elapsed < TimeSpan.FromSeconds(12), "Oh, too slow!");
            }
        }

        [Fact]
        public void should_not_dispose_input_stream()
        {
            using (var stream = new Utf8RandomTextStream(10))
            {
                StatCharacterUsage(stream);
                Assert.False(stream.Disposed);
            }
        }
    }
}