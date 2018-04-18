using System;
using System.Diagnostics;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace ConsoleRedirector
{
    public class ConsoleRedirectorFacts : IDisposable
    {
        readonly ITestOutputHelper output;
        readonly TextWriter oldWriter;

        public ConsoleRedirectorFacts(ITestOutputHelper output)
        {
            this.output = output;
            oldWriter = Console.Out;
        }

        [Fact]
        public void should_set_initial_lines()
        {
            var writer = new ConsoleStatWriter();
            
            Assert.Equal(0, writer.Lines);
        }
        
        [Fact]
        public void should_redirect_and_stat()
        {
            var writer = new ConsoleStatWriter();
            Console.SetOut(writer);
            
            Console.WriteLine("hello");
            Console.WriteLine("world");
            
            Assert.Equal(3, writer.Lines);
        }

        [Theory]
        [InlineData("line\r\n\r", 2)]
        [InlineData("line\r\n\r\r", 3)]
        [InlineData("line\r\n\r\rgood", 4)]
        [InlineData("line\n\n\n\ngood", 5)]
        [InlineData("line\r\r\n\rgood", 4)]
        public void should_handle_line_breaks(string text, int expectedLines)
        {
            var writer = new ConsoleStatWriter();
            Console.SetOut(writer);
            
            Console.Write(text);
            
            Assert.Equal(expectedLines, writer.Lines);
        }

        [Fact]
        public void should_handle_huge_amount_of_text_data()
        {
            var statWriter = new ConsoleStatWriter();
            int totalLines = ushort.MaxValue;
            var writer = new HugeConsoleWriter(totalLines, statWriter);

            Stopwatch watch = Stopwatch.StartNew();
            writer.Write();
            watch.Stop();
            
            output.WriteLine($"Elapsed Time: {watch.Elapsed:c}");
            
            Assert.Equal(totalLines, statWriter.Lines);
        }

        public void Dispose()
        {
            Console.SetOut(oldWriter);
        }
    }
}