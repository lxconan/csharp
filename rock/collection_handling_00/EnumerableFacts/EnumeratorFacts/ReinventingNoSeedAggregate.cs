using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EnumerableFacts.Helpers;
using Xunit;

namespace EnumerableFacts.EnumeratorFacts
{
    /* 
     * Description
     * ===========
     * 
     * Please reinvent MyAggregate<T> extension method. Applies an accumulator function over a
     * sequence. This method works by calling func one time for each element in source except 
     * the first one. Each time func is called, MyAggregate<TSource>(IEnumerable<TSource>, 
     * Func<TSource, TSource, TSource>) passes both the element from the sequence and an 
     * aggregated value (as the first argument to func). The first element of source is used 
     * as the initial aggregate value. The result of func replaces the previous aggregated value. 
     * MyAggregate<TSource>(IEnumerable<TSource>, Func<TSource, TSource, TSource>) returns the 
     * final result of func. The test are introduced from dotnet core framework.
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
    static partial class ReinventingLinq
    {
        #region Please modifies the code to pass the test

        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        public static TSource MyAggregate<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, TSource> func)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ReinventingNoSeedAggregate
    {
        [Fact]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void SameResultsRepeatCallsIntQuery()
        {
            IEnumerable<int> q = from x in new[] { 9999, 0, 888, -1, 66, -777, 1, 2, -12345 }
                where x > int.MinValue
                select x;

            Assert.Equal(q.MyAggregate((x, y) => x + y), q.MyAggregate((x, y) => x + y));
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void SameResultsRepeatCallsStringQuery()
        {
            IEnumerable<string> q = from x in new[] { "!@#$%^", "C", "AAA", "", "Calling Twice", "SoS", string.Empty }
                where !string.IsNullOrEmpty(x)
                select x;

            Assert.Equal(q.MyAggregate((x, y) => x + y), q.MyAggregate((x, y) => x + y));
        }

        [Fact]
        public void EmptySource()
        {
            int[] source = { };

            Assert.Throws<InvalidOperationException>(() => source.RunOnce().MyAggregate((x, y) => x + y));
        }

        [Fact]
        public void SingleElement()
        {
            int[] source = { 5 };
            int expected = 5;

            Assert.Equal(expected, source.MyAggregate((x, y) => x + y));
        }

        [Fact]
        public void SingleElementRunOnce()
        {
            int[] source = { 5 };
            int expected = 5;

            Assert.Equal(expected, source.RunOnce().MyAggregate((x, y) => x + y));
        }

        [Fact]
        public void TwoElements()
        {
            int[] source = { 5, 6 };
            int expected = 11;

            Assert.Equal(expected, source.MyAggregate((x, y) => x + y));
        }

        [Fact]
        public void TwoElementsRefType()
        {
            int?[] source = {1, 2};
            int expected = 3;

            Assert.Equal(expected, source.MyAggregate((x, y) => x + y));
        }

        [Fact]
        public void MultipleElements()
        {
            int[] source = { 5, 6, 0, -4 };
            int expected = 7;

            Assert.Equal(expected, source.MyAggregate((x, y) => x + y));
        }

        [Fact]
        public void MultipleElementsRunOnce()
        {
            int[] source = { 5, 6, 0, -4 };
            int expected = 7;

            Assert.Equal(expected, source.RunOnce().MyAggregate((x, y) => x + y));
        }

        [Fact]
        public void NullSource()
        {
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<int>)null).MyAggregate((x, y) => x + y));
        }

        [Fact]
        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        public void NullFunc()
        {
            Func<int, int, int> func = null;
            Assert.Throws<ArgumentNullException>(() => Enumerable.Range(0, 3).MyAggregate(func));
        }
    }
}