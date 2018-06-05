using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using Xunit;

namespace FormatTextTable
{
    /* 
     * Description
     * ===========
     * 
     * This test will practice how to padding string and format object using IFormatProvider.
     * 
     * Difficulty: Medium
     * 
     * Knowledge Point
     * ===============
     * 
     * - string.PadLeft(), string.PadRight()
     * - A `IFormatProvider` can be passed to `ToString()` method if the object implements
     *   `IFormattable` interface. The `CultureInfo` class implements the `IFormatProvider`
     *   interface.
     */
    public class TableFormatter
    {
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
        struct CellFormatRule
        {
            public CellFormatRule(bool rightAligned, short cellCharacterLength)
            {
                RightAligned = rightAligned;
                CellCharacterLength = cellCharacterLength;
            }

            public bool RightAligned { get; }
            public short CellCharacterLength { get; }
        }

        #region Please modifies the code to pass the test

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static IEnumerable<string> FormatTable(
            IEnumerable<IEnumerable<object>> data,
            CellFormatRule[] rules,
            IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        #endregion

        [Fact]
        public void should_format_table_correctly()
        {
            var rules = new[]
            {
                new CellFormatRule(false, 20),
                new CellFormatRule(false, 20),
                new CellFormatRule(true, 5)
            };

            IEnumerable<IEnumerable<object>> data = new[]
            {
                new object[] {"Name", "Company", "Id"},
                new object[] {"Edogawa Conan", "Tokyo", 1.1},
                new object[] {"Furugawa Nagisa", "Kyoto Animation", 1.1},
                new object[] {"Kirigaya Katsuto", "A1 Pictures", 1.1}
            };

            IEnumerable<string> table = FormatTable(data, rules, new CultureInfo("af-ZA"));

            Assert.Equal(
                new[]
                {
                    "Name                Company                Id",
                    "Edogawa Conan       Tokyo                 1,1",
                    "Furugawa Nagisa     Kyoto Animation       1,1",
                    "Kirigaya Katsuto    A1 Pictures           1,1"
                },
                table);
        }

        [Fact]
        public void should_throw_if_cell_count_is_not_equal_with_actual_data()
        {
            var rules = new[]
            {
                new CellFormatRule(false, 20),
                new CellFormatRule(false, 20),
                new CellFormatRule(true, 5)
            };

            Assert.Throws<ArgumentException>(
                () => FormatTable(
                        new[] {new[] {"c1", "c2", "c3", "c4"}},
                        rules,
                        CultureInfo.InvariantCulture)
                    .ToArray());
        }

        [Fact]
        public void should_handle_null_object_to_empty_string()
        {
            var rules = new[]
            {
                new CellFormatRule(true, 10)
            };

            IEnumerable<string> table = FormatTable(
                new []{new []{default(object)}}, rules,
                CultureInfo.InvariantCulture);

            Assert.Equal(new[] {"          "}, table);
        }

        [Fact]
        public void should_not_return_in_memory_collection()
        {
            var rules = new[]
            {
                new CellFormatRule(true, 10)
            };

            IEnumerable<string> table = FormatTable(
                new[] { new[] { "hello" } }, rules,
                CultureInfo.InvariantCulture);

            Assert.False(table is ICollection<string>, "I will give you 10GB of data to crash the app");
        }
    }
}