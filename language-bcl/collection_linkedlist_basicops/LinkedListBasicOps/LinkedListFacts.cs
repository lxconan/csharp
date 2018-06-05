using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace LinkedListBasicOps
{
    public class LinkedListFacts
    {
        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void should_know_the_result_of_linked_list_ops()
        {
            // In this test, we will do a batch of basic list operations. You should never run
            // the test before write down your answer. The test is actually a feedback for you.
            //
            // TODO: Please modify the following line to pass the test
            var expect = new string[0];
            
            var tune = new LinkedList<string>();
            tune.AddFirst("do");
            tune.AddLast("so");
            tune.AddAfter(tune.First, "re");
            tune.AddAfter(tune.First.Next, "mi");
            tune.AddBefore(tune.Last, "fa");
            
            Assert.Equal(expect, tune);
        }
        
        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void should_know_the_result_of_linked_list_ops_continued()
        {
            // In this test, we will do a batch of basic list operations. You should never run
            // the test before write down your answer. The test is actually a feedback for you.
            //
            // TODO: Please modify the following line to pass the test
            var expect = new string[0];
            
            var tune = new LinkedList<string>();
            tune.AddFirst("do");
            tune.AddLast("so");
            tune.AddAfter(tune.First, "re");
            tune.AddAfter(tune.First.Next, "mi");
            tune.AddBefore(tune.Last, "fa");
            
            tune.RemoveFirst();
            tune.RemoveLast();
            LinkedListNode<string> miNode = tune.Find("mi");
            tune.Remove(miNode);
            tune.AddFirst(miNode);

            Assert.Equal(expect, tune);
        }
    }
}