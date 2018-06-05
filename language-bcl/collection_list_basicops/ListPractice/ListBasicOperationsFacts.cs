using System;
using System.Collections.Generic;
using Xunit;

namespace ListPractice
{
    public class ListBasicOperationsFacts
    {
        [Fact]
        public void should_know_the_result_of_the_list_ops()
        {
            // In this test, we will do a batch of basic list operations. You should never run
            // the test before write down your answer. The test is actually a feedback for you.
            //
            // TODO: Please modify the following line to pass the test 
            var expected = new List<string>();
            
            var words = new List<string>();
            words.Add("melon");
            words.Add("avocado");
            words.AddRange(new[] {"banana", "plum"});
            words.Insert(0, "lemon");
            words.InsertRange(0, new [] {"peach", "nashi"});
            
            Assert.Equal(expected, words);
        }
        
        [Fact]
        public void should_know_the_result_of_the_list_ops_continued()
        {
            // In this test, we will do a batch of basic list operations. You should never run
            // the test before write down your answer. The test is actually a feedback for you.
            //
            // TODO: Please modify the following line to pass the test
            var expected = new List<string>();
            
            var words = new List<string>();
            words.Add("melon");
            words.Add("avocado");
            words.AddRange(new[] {"banana", "plum"});
            words.Insert(0, "lemon");
            words.InsertRange(0, new [] {"peach", "nashi"});

            words.Remove("melon");
            words.RemoveAt(3);
            words.RemoveRange(0, 2);

            words.RemoveAll(s => s.StartsWith("n"));
            
            Assert.Equal(expected, words);
        }
    }
}