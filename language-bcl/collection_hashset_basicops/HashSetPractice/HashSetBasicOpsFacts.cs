using System;
using System.Collections.Generic;
using Xunit;

namespace HashSetPractice
{
    public class HashSetBasicOpsFacts
    {
        [Fact]
        public void should_intersect()
        {
            var letters = new HashSet<char> ("the quick brown fox");
            letters.IntersectWith ("aeiou");

            // TODO: Do not run the test. Please write down your answer first then use test as a feedback.
            char[] expected = Array.Empty<char>();
            
            Assert.True(letters.SetEquals(expected));
        }

        [Fact]
        public void should_except()
        {
            var letters = new HashSet<char> ("the quick brown fox"); 
            letters.ExceptWith ("aeiou");
            
            // TODO: Do not run the test. Please write down your answer first then use test as a feedback.
            char[] expected = Array.Empty<char>();
            
            Assert.True(letters.SetEquals(expected));
        }

        [Fact]
        public void should_symmetric_except()
        {
            var letters = new HashSet<char> ("the quick brown fox");
            letters.SymmetricExceptWith ("the lazy brown fox");
            
            // TODO: Do not run the test. Please write down your answer first then use test as a feedback.
            char[] expected = Array.Empty<char>();
            
            Assert.True(letters.SetEquals(expected));
        }

        [Fact]
        public void should_get_sorted_result()
        {
            var letters = new SortedSet<char> ("the quick brown fox");
            
            // TODO: Do not run the test. Please write down your answer first then use test as a feedback.
            char[] expected = Array.Empty<char>();
            
            Assert.Equal(expected, letters);
        }

        [Fact]
        public void should_get_view_between()
        {
            var letters = new SortedSet<char> ("the quick brown fox");
            SortedSet<char> view = letters.GetViewBetween('f', 'j');
            
            // TODO: Do not run the test. Please write down your answer first then use test as a feedback.
            char[] expected = Array.Empty<char>();
            
            Assert.Equal(expected, view);
        }
    }
}
