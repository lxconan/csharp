using System;
using System.IO;

namespace TextHistogram
{
    class Utf8RandomTextStream : Stream
    {
        static readonly byte[] CharacterSet =
        {
            0x61, 0x62, 0x63, 0x64, 0x65, 0x66,
            0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C,
            0x6D, 0x6E, 0x6F, 0x70, 0x71, 0x72,
            0x73, 0x74, 0x75, 0x76, 0x77, 0x78,
            0x79, 0x7A
        };
        readonly Random random = new Random();
        long remainingLength;

        public Utf8RandomTextStream(long characterLength)
        {
            Length = characterLength;
            remainingLength = characterLength;
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null) { throw new ArgumentNullException(nameof(buffer)); }
            if (count < 0) { throw new ArgumentOutOfRangeException(nameof(count)); }
            if (offset < 0) { throw new ArgumentOutOfRangeException(nameof(offset)); }
            if (offset + count > buffer.Length) { throw new ArgumentException("The offset and count exceeds the buffer length."); }
            if (count == 0 || remainingLength <= 0) { return 0; }

            int actualCount = remainingLength > count ? count : (int)remainingLength;
            for (int index = offset; index < offset + actualCount; ++index)
            {
                buffer[index] = CharacterSet[random.Next(0, CharacterSet.Length)];
            }

            remainingLength -= actualCount;
            return actualCount;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException("This stream does not support seek.");
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException("This stream does not support set length.");
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException("This stream does not support write.");
        }

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length { get; }
        public override long Position { get; set; }
        public bool Disposed { get; private set; }

        protected override void Dispose(bool disposing)
        {
            Disposed = true;
            base.Dispose(disposing);
        }
    }
}