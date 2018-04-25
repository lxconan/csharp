using System;
using System.IO;

namespace WordsCounter
{
    class HugeTextStream : TextReader
    {
        const string Word = " word ";
        int pos;
        int currentWord;
        readonly int totalWords;

        public HugeTextStream(int totalWords)
        {
            this.totalWords = totalWords < 0
                ? throw new ArgumentOutOfRangeException(nameof(totalWords))
                : totalWords;
        }

        public override int Read()
        {
            if (currentWord == totalWords) return -1;
            char c = Word[pos++];
            if (pos >= Word.Length)
            {
                pos = 0;
                ++currentWord;
            }

            return c;
        }

        public override int Peek()
        {
            if (currentWord == totalWords) return -1;
            return Word[pos];
        }
    }
}