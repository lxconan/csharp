using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SumPractice
{
    static class TextStreamFactory
    {
        static readonly char[] AlphaBet = {'a', 'b', 'c', 'd', 'e'};

        static string CreateRandomWord()
        {
            const int maxLength = 10;
            const int minLength = 2;
            var rand = new Random();
            int length = rand.Next(minLength, maxLength + 1);
            return Enumerable
                .Range(0, length)
                .Aggregate(new StringBuilder(), (builder, index) => builder.Append(AlphaBet[index % AlphaBet.Length]))
                .ToString();
        }

        public static Stream Create(int wordCount)
        {
            if (wordCount < 0) { throw new ArgumentOutOfRangeException(nameof(wordCount));}
            string content = Enumerable
                .Repeat(0, wordCount)
                .Aggregate(new StringBuilder(), (builder, _) => builder.Append(CreateRandomWord()).Append(' '))
                .ToString();
            return new MemoryStream(Encoding.UTF8.GetBytes(content));
        }
    }
}