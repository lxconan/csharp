using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using basic.Common;
using Xunit;

namespace basic
{
    public class StringAndCharOperations
    {
        [Fact]
        public void should_concat_string()
        {
            const string title = "Mr. ";
            const string name = "Hall";

            // change "default(string)" to correct value.
            const string expectedResult = "Mr. Hall";

            Assert.Equal(expectedResult, (title + name));
        }

        #pragma warning disable CS0219
        
        [Fact]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void should_using_stringbuilder_to_concat_string_efficiently()
        {
            const string title = "Mr. ";
            const string name = "Hall";

            var builder = new StringBuilder();
            // add at most 2 lines of code here concating variable "title" and "name".
            builder.AppendJoin("", title, name);

            Assert.Equal("Mr. Hall", builder.ToString());
        }
        
        #pragma warning restore CS0219

        [Fact]
        public void should_create_a_new_string_for_replace_operation()
        {
            string originalString = "Original String";
            string replacement = originalString.Replace("Str", "W");

            // change "" in the following 2 lines to correct values.
            const string expectedOrignalString = "Original String";
            const string expectedReplacement = "Original Wing";
            
            Assert.Equal(expectedOrignalString, originalString);
            Assert.Equal(expectedReplacement, replacement);
        }

        [Fact]
        public void should_use_string_builder_for_inplace_string_replacement()
        {
            var builder = new StringBuilder("Original String");
            builder.Replace("Str", "W");

            // change "" in the following line to correct value.
            const string expectedResult = "Original Wing";

            Assert.Equal(expectedResult, builder.ToString());
        }

        [Fact]
        public void should_locate_certain_character_using_indexer()
        {
            const string originalString = "Original String";
            char characterAtIndex2 = originalString[2];

            // change "default(char)" to correct value.
            const char expectedResult = 'i';

            Assert.Equal(expectedResult, characterAtIndex2);
        }

        [Fact]
        public void should_compare_string_value()
        {
            const string str = "Original String";
            string equivalent = "Original" + " String";
            //str=new String("Original String"), equivalent="Original String"?referenceOf("Original String"):new String("Original String")
            // change "default(bool)" to correct value.
            const bool expectedResult = true;

            Assert.Equal(expectedResult, (str == equivalent));
        }

        [Fact]
        public void should_use_equal_method_to_test_equaility_in_a_more_flexible_way()
        {
            const string originalString = "Original String";
            const string inDifferentCase = "oRiginal String";

            // change the variable values in the following 2 lines.
            var caseSensitiveComparison = StringComparison.Ordinal;
            var caseInsensitiveComparison = StringComparison.OrdinalIgnoreCase;

            Assert.False(originalString.Equals(inDifferentCase, caseSensitiveComparison));
            Assert.True(originalString.Equals(inDifferentCase, caseInsensitiveComparison));
        }

        [Fact]
        public void should_return_one_row_when_start_equals_end()
        {
            int start = 1;
            int end = 1;
            string expectedString = "1 * 1 = 1 " + Environment.NewLine;

            Assert.Equal(expectedString, Mutiplication.MutiplicationTable(start, end));
        }

        [Fact]
        public void should_return_more_rows_when_start_less_than_end()
        {
            int start = 2;
            int end = 5;
            string expectedString =
                "2 * 2 = 4  " + Environment.NewLine +
                "2 * 3 = 6  3 * 3 = 9  " + Environment.NewLine +
                "2 * 4 = 8  3 * 4 = 12 4 * 4 = 16 " + Environment.NewLine +
                "2 * 5 = 10 3 * 5 = 15 4 * 5 = 20 5 * 5 = 25 " + Environment.NewLine;

            Assert.Equal(expectedString, Mutiplication.MutiplicationTable(start, end));
        }

        [Fact]
        public void should_return_empty_string_when_start_bigger_than_end()
        {
            int start = 2;
            int end = 1;
            string expectedString = "";

            Assert.Equal(expectedString, Mutiplication.MutiplicationTable(start, end));
        }

        [Fact]
        public void should_return_correct_value_for_very_large_number()
        {
            int start = int.MaxValue;
            int end = int.MaxValue;
            string expectedString = $"{start} * {end} = 4611686014132420609 " + Environment.NewLine;

            Assert.Equal(expectedString, Mutiplication.MutiplicationTable(start, end));
        }

    }
}