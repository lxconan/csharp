using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace EnumeratorDistinct
{
    static class RunOnceExtension
    {
        public static IEnumerable<T> RunOnce<T>(this IEnumerable<T> source) =>
            source == null ? null : (source as IList<T>)?.RunOnce() ?? new RunOnceEnumerable<T>(source);

        public static IEnumerable<T> RunOnce<T>(this IList<T> source)
            => source == null ? null : new RunOnceList<T>(source);

        class RunOnceEnumerable<T> : IEnumerable<T>
        {
            readonly IEnumerable<T> source;
            bool called;

            public RunOnceEnumerable(IEnumerable<T> source)
            {
                this.source = source;
            }

            public IEnumerator<T> GetEnumerator()
            {
                Assert.False(called);
                called = true;
                return source.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        class RunOnceList<T> : IList<T>
        {
            readonly IList<T> source;
            readonly HashSet<int> called = new HashSet<int>();

            void AssertAll()
            {
                Assert.Empty(called);
                called.Add(-1);
            }

            void AssertIndex(int index)
            {
                Assert.False(called.Contains(-1));
                Assert.True(called.Add(index));
            }

            public RunOnceList(IList<T> source)
            {
                this.source = source;
            }

            public IEnumerator<T> GetEnumerator()
            {
                AssertAll();
                return source.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public void Add(T item)
            {
                throw new NotSupportedException();
            }

            public void Clear()
            {
                throw new NotSupportedException();
            }

            public bool Contains(T item)
            {
                AssertAll();
                return source.Contains(item);
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                AssertAll();
                source.CopyTo(array, arrayIndex);
            }

            public bool Remove(T item)
            {
                throw new NotSupportedException();
            }

            public int Count => source.Count;

            public bool IsReadOnly => true;

            public int IndexOf(T item)
            {
                AssertAll();
                return source.IndexOf(item);
            }

            public void Insert(int index, T item)
            {
                throw new NotSupportedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotSupportedException();
            }

            public T this[int index]
            {
                get
                {
                    AssertIndex(index);
                    return source[index];
                }
                set => throw new NotSupportedException();
            }
        }
    }
}