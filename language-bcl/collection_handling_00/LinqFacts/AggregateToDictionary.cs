using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using Xunit;

namespace LinqFacts
{
    /* 
     * Description
     * ===========
     * 
     * This test will try create dictionary from source data. 
     * 
     * Difficulty: Medium
     * 
     * Knowledge Point
     * ===============
     * 
     * - LINQ Query: Aggregate, 
     * - IEqualityComparer<T>
     * 
     * Requirement
     * ===========
     * 
     * - No `for`, `foreach` or other loop keywords are allowed to use.
     */
    static class AggregateToDictionaryExtension
    {
        #region Please modifies the code to pass the test

        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        public static IDictionary<TKey, TValue> AggregateToDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TValue> valueSelector,
            IEqualityComparer<TKey> comparer = null,
            bool overwriteDuplicated = false)
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }

    public class AggregateToDictionary
    {
        [Fact]
        public void should_aggregate_to_dictionary()
        {
            IEnumerable<int> source = new[] {1, 2, 1};
            IDictionary<int, string> result = source.AggregateToDictionary(
                item => item,
                item => item.ToString("D", CultureInfo.InvariantCulture));

            Assert.Equal(
                new Dictionary<int, string>
                {
                    {1, "1"},
                    {2, "2"}
                },
                result);
        }

        [Fact]
        public void should_not_overwrite_on_duplicated()
        {
            IEnumerable<KeyValuePair<int, string>> source = new[]
            {
                new KeyValuePair<int, string>(1, "hello"),
                new KeyValuePair<int, string>(1, "world")
            };

            IDictionary<int, string> dictionary = source.AggregateToDictionary(
                item => item.Key,
                item => item.Value);

            Assert.Equal(
                new KeyValuePair<int, string>(1, "hello"), 
                dictionary.Single());
        }

        [Fact]
        public void should_overwrite_on_duplicated()
        {
            IEnumerable<KeyValuePair<int, string>> source = new[]
            {
                new KeyValuePair<int, string>(1, "hello"),
                new KeyValuePair<int, string>(1, "world")
            };

            IDictionary<int, string> dictionary = source.AggregateToDictionary(
                item => item.Key,
                item => item.Value,
                null,
                true);

            Assert.Equal(
                new KeyValuePair<int, string>(1, "world"),
                dictionary.Single());
        }

        [Fact]
        public void should_throw_if_source_is_null()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    ((IEnumerable<int>) null).AggregateToDictionary(
                        item => item,
                        item => item));
        }

        [Fact]
        public void should_throw_if_key_selector_is_null()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    new [] {1, 2, 3}.AggregateToDictionary(
                        (Func<int, int>)null,
                        item => item));
        }

        [Fact]
        public void should_apply_comparer()
        {
            IEnumerable<string> source = new[] {"Nancy", "nAnCy"};
            IEqualityComparer<string> comparer = StringComparer.OrdinalIgnoreCase;
            KeyValuePair<string, string> left = source.AggregateToDictionary(
                item => item,
                item => item,
                StringComparer.OrdinalIgnoreCase,
                true).Single();

            Assert.Equal(new KeyValuePair<string, string>("Nancy", "nAnCy"), left);
        }
    }
}