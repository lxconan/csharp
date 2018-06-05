using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace EnumeratorDistinct
{
    /* 
     * Description
     * ===========
     * 
     * Please reinvent MyDistict<T> extension method. Please note that in this practice, 
     * you have to pay attention to memory usage efficiency. For example. You have a 
     * huge collection with 1MB of data, but what we only need is just some of the
     * MyDistinct result. The test are introduced from dotnet core framework.
     * 
     * Difficulty: Medium
     * 
     * Requirement
     * ===========
     * 
     * - No LINQ method is allowed to use.
     * - You can add helper method within region. But you cannot modify code outside the
     *   region.
     */
    static class ReinventingLinq
    {
        class DistinctEnumerable<TSource> : IEnumerable<TSource>
        {
            readonly IEnumerable<TSource> source;
            readonly IEqualityComparer<TSource> comparer;

            public DistinctEnumerable(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
            {
                this.source = source;
                this.comparer = comparer;
            }

            public IEnumerator<TSource> GetEnumerator()
            {
                return new DistinctEnumerator<TSource>(source, comparer);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public static IEnumerable<TSource> MyDistinct<TSource>(this IEnumerable<TSource> source)
        {
            return MyDistinct(source, null);
        }

        public static IEnumerable<TSource> MyDistinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return new DistinctEnumerable<TSource>(source, comparer);
        }

        #region Please modifies the code to pass the test

        class DistinctEnumerator<TSource> : IEnumerator<TSource>
        {
            [SuppressMessage("ReSharper", "UnusedParameter.Local")]
            public DistinctEnumerator(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public TSource Current => throw new NotImplementedException();

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }

    public class ReinventingDistinct
    {
        [Fact]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void SameResultsRepeatCallsIntQuery()
        {
            IEnumerable<int> q = from x in new[] { 0, 9999, 0, 888, -1, 66, -1, -777, 1, 2, -12345, 66, 66, -1, -1 }
                where x > int.MinValue
                select x;

            Assert.Equal(q.MyDistinct(), q.MyDistinct());
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void SameResultsRepeatCallsStringQuery()
        {
            IEnumerable<string> q = from x in new[] { "!@#$%^", "C", "AAA", "Calling Twice", "SoS" }
                where string.IsNullOrEmpty(x)
                select x;


            Assert.Equal(q.MyDistinct(), q.MyDistinct());
        }

        [Fact]
        public void EmptySource()
        {
            int[] source = { };
            Assert.Empty(source.MyDistinct());
        }

        [Fact]
        public void EmptySourceRunOnce()
        {
            int[] source = { };
            Assert.Empty(source.RunOnce().MyDistinct());
        }

        [Fact]
        public void SingleNullElementExplicitlyUseDefaultComparer()
        {
            string[] source = { null };
            string[] expected = { null };

            Assert.Equal(expected, source.MyDistinct(EqualityComparer<string>.Default));
        }

        [Fact]
        public void EmptyStringDistinctFromNull()
        {
            string[] source = { null, null, string.Empty };
            string[] expected = { null, string.Empty };

            Assert.Equal(expected, source.MyDistinct(EqualityComparer<string>.Default));
        }

        [Fact]
        public void CollapsDuplicateNulls()
        {
            string[] source = { null, null };
            string[] expected = { null };

            Assert.Equal(expected, source.MyDistinct(EqualityComparer<string>.Default));
        }

        [Fact]
        public void SourceAllDuplicates()
        {
            int[] source = { 5, 5, 5, 5, 5, 5 };
            int[] expected = { 5 };

            Assert.Equal(expected, source.MyDistinct());
        }

        [Fact]
        public void AllUnique()
        {
            int[] source = { 2, -5, 0, 6, 10, 9 };

            Assert.Equal(source, source.MyDistinct());
        }

        [Fact]
        public void SomeDuplicatesIncludingNulls()
        {
            int?[] source = { 1, 1, 1, 2, 2, 2, null, null };
            int?[] expected = { 1, 2, null };

            Assert.Equal(expected, source.MyDistinct());
        }

        [Fact]
        public void SomeDuplicatesIncludingNullsRunOnce()
        {
            int?[] source = { 1, 1, 1, 2, 2, 2, null, null };
            int?[] expected = { 1, 2, null };

            Assert.Equal(expected, source.RunOnce().MyDistinct());
        }

        [Fact]
        public void LastSameAsFirst()
        {
            int[] source = { 1, 2, 3, 4, 5, 1 };
            int[] expected = { 1, 2, 3, 4, 5 };

            Assert.Equal(expected, source.MyDistinct());
        }

        // Multiple elements repeat non-consecutively
        [Fact]
        public void RepeatsNonConsecutive()
        {
            int[] source = { 1, 1, 2, 2, 4, 3, 1, 3, 2 };
            int[] expected = { 1, 2, 4, 3 };

            Assert.Equal(expected, source.MyDistinct());
        }

        [Fact]
        public void RepeatsNonConsecutiveRunOnce()
        {
            int[] source = { 1, 1, 2, 2, 4, 3, 1, 3, 2 };
            int[] expected = { 1, 2, 4, 3 };

            Assert.Equal(expected, source.RunOnce().MyDistinct());
        }

        [Fact]
        public void NullComparer()
        {
            string[] source = { "Bob", "Tim", "bBo", "miT", "Robert", "iTm" };
            string[] expected = { "Bob", "Tim", "bBo", "miT", "Robert", "iTm" };

            Assert.Equal(expected, source.MyDistinct());
        }

        [Fact]
        public void NullSource()
        {
            string[] source = null;

            Assert.Throws<ArgumentNullException>(() => source.MyDistinct());
        }

        [Fact]
        public void NullSourceCustomComparer()
        {
            string[] source = null;

            Assert.Throws<ArgumentNullException>(() => source.MyDistinct(StringComparer.Ordinal));
        }

        [Fact]
        public void CustomEqualityComparer()
        {
            string[] source = { "Bob", "Tim", "bBo", "miT", "Robert", "iTm" };
            string[] expected = { "Bob", "Tim", "Robert" };

            Assert.Equal(expected, source.MyDistinct(new AnagramEqualityComparer()), new AnagramEqualityComparer());
        }

        [Fact]
        public void CustomEqualityComparerRunOnce()
        {
            string[] source = { "Bob", "Tim", "bBo", "miT", "Robert", "iTm" };
            string[] expected = { "Bob", "Tim", "Robert" };

            Assert.Equal(expected, source.RunOnce().MyDistinct(new AnagramEqualityComparer()), new AnagramEqualityComparer());
        }

        [Theory, MemberData(nameof(SequencesWithDuplicates))]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void FindDistinctAndValidate<T>(T unusedArgumentToForceTypeInference, IEnumerable<T> original)
        {
            // Convert to list to avoid repeated enumerations of the enumerables.
            List<T> originalList = original.ToList();
            List<T> distinctList = originalList.MyDistinct().ToList();

            // Ensure the result doesn't contain duplicates.
            HashSet<T> hashSet = new HashSet<T>();
            foreach (T i in distinctList)
                Assert.True(hashSet.Add(i));

            HashSet<T> originalSet = new HashSet<T>(original);
            Assert.Superset(originalSet, hashSet);
            Assert.Subset(originalSet, hashSet);
        }

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static IEnumerable<object[]> SequencesWithDuplicates()
        {
            // Validate an array of different numeric data types.
            yield return new object[] { 0, new[] { 1, 1, 1, 2, 3, 5, 5, 6, 6, 10 } };
            yield return new object[] { 0L, new long[] { 1, 1, 1, 2, 3, 5, 5, 6, 6, 10 } };
            yield return new object[] { 0F, new float[] { 1, 1, 1, 2, 3, 5, 5, 6, 6, 10 } };
            yield return new object[] { 0.0, new double[] { 1, 1, 1, 2, 3, 5, 5, 6, 6, 10 } };
            yield return new object[] { 0M, new decimal[] { 1, 1, 1, 2, 3, 5, 5, 6, 6, 10 } };
            // Try strings
            yield return new object[] { "", new []
                {
                    "add",
                    "add",
                    "subtract",
                    "multiply",
                    "divide",
                    "divide2",
                    "subtract",
                    "add",
                    "power",
                    "exponent",
                    "hello",
                    "class",
                    "namespace",
                    "namespace",
                    "namespace",
                }
            };
        }
        
        [Fact]
        public void ToArray()
        {
            int?[] source = { 1, 1, 1, 2, 2, 2, null, null };
            int?[] expected = { 1, 2, null };

            Assert.Equal(expected, source.MyDistinct().ToArray());
        }

        [Fact]
        public void ToList()
        {
            int?[] source = { 1, 1, 1, 2, 2, 2, null, null };
            int?[] expected = { 1, 2, null };

            Assert.Equal(expected, source.MyDistinct().ToList());
        }

        [Fact]
        public void Count()
        {
            int?[] source = { 1, 1, 1, 2, 2, 2, null, null };
            Assert.Equal(3, source.MyDistinct().Count());
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void RepeatEnumerating()
        {
            int?[] source = { 1, 1, 1, 2, 2, 2, null, null };

            IEnumerable<int?> result = source.MyDistinct();

            Assert.Equal(result, result);
        }
    }
}