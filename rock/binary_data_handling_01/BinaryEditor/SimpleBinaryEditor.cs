using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace BinaryEditor
{
    class SimpleBinaryEditor
    {
        [SuppressMessage("ReSharper", "NotAccessedField.Local")] 
        readonly Stream stream;

        public SimpleBinaryEditor(Stream stream)
        {
            if (stream == null) { throw new ArgumentNullException(nameof(stream)); }

            if (!stream.CanRead || !stream.CanSeek)
            {
                throw new InvalidOperationException("The stream either not readble, or not seekable");
            }

            this.stream = stream;
        }

        public string GetView(int offset, int length)
        {
            #region Please implement the method to pass the test

            /*
             * A binary editor is a useful tool to directly manipulate binary content.
             * New we would like to create a binary editor. First things first we would
             * like to display binary content as string.
             *
             * The content has a header, and the content will be aligned with the header.
             * As follows:
             *
             * 00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F
             *          AB CD EF 12 34 56 78 9A BC DE F1 23 45
             * 67 89 AB CD EF 01 23 45 67 89
             *
             * The I/O operation is expensive, so we would like to read bytes as few as
             * possible.
             */

            throw new NotImplementedException();

            #endregion
        }
    }
}