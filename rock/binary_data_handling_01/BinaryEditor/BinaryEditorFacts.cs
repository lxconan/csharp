using System;
using System.IO;
using Xunit;

namespace BinaryEditor
{
    public class BinaryEditorFacts
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(2)]
        public void should_throw_if_view_offset_is_out_of_range(int startingPoint)
        {
            Stream stream = new MemoryStream(new byte[] { 0x00, 0x01 });

            var editor = new SimpleBinaryEditor(stream);

            Assert.Throws<ArgumentOutOfRangeException>(() => editor.GetView(startingPoint, 1));
        }

        [Fact]
        public void should_get_view()
        {
            Stream stream = new MemoryStream(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04 });
            var editor = new SimpleBinaryEditor(stream);

            string view = editor.GetView(1, 3);

            Assert.Equal(
                $"01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F {Environment.NewLine}" +
                "   01 02 03 ",
                view);
        }

        [Fact]
        public void should_get_view_cross_rows()
        {
            Stream stream = new MemoryStream(
                new byte[]
                {
                    0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                    0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F
                });
            var editor = new SimpleBinaryEditor(stream);

            string view = editor.GetView(5, 16);

            Assert.Equal(
                $"01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F {Environment.NewLine}" +
                $"               05 06 07 08 09 0A 0B 0C 0D 0E {Environment.NewLine}" +
                "0F 10 11 12 13 14 ",
                view);
        }

        [Fact]
        public void should_get_view_for_second_row()
        {
            Stream stream = new MemoryStream(
                new byte[]
                {
                    0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                    0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F
                });
            var editor = new SimpleBinaryEditor(stream);

            string view = editor.GetView(17, 3);

            Assert.Equal(
                $"01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F {Environment.NewLine}" +
                "   11 12 13 ",
                view);
        }
    }
}
