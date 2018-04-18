using System;
using System.IO;

namespace ConsoleRedirector
{
    class HugeConsoleWriter
    {
        readonly int lines;
        readonly TextWriter writer;

        public HugeConsoleWriter(int lines, TextWriter writer)
        {
            this.lines = lines;
            this.writer = writer;
        }

        public void Write()
        {
            TextWriter old = Console.Out;
            try
            {
                Console.SetOut(writer);
                int end = lines - 1;
                for (int i = 0; i < end; ++i)
                {
                    Console.WriteLine(new string('c', 1024 * 100));
                }
            }
            finally
            {
                Console.SetOut(old);
            }
        }
    }
}