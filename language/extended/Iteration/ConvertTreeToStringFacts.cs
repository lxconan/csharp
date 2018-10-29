using System;
using Xunit;

namespace extended.Iteration
{
    public class ConvertTreeToStringFacts
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void should_throw_if_name_is_null_or_empty_string(string nullOrEmpty)
        {
            Assert.Throws<ArgumentException>(() => new TreeNode(nullOrEmpty));
        }
        
        [Fact]
        public void should_convert_single_tree_node_to_string()
        {
            var tree = new TreeNode("Root Node");
            
            Assert.Equal("Root Node\n", tree.ToString());
        }

        [Fact]
        public void should_convert_child_node_to_string()
        {
            var tree = new TreeNode("Root Node",
                new TreeNode("Child"));
            
            Assert.Equal("Root Node\n  Child\n", tree.ToString());
        }
        
        [Fact]
        public void should_convert_to_string()
        {
            var tree = new TreeNode(
                "Root Node",
                new TreeNode("Child-Left"),
                new TreeNode("Child-Middle",
                    new TreeNode("Grand-Child")),
                new TreeNode("Child-Right"));
            
            Assert.Equal(
                "Root Node\n" +
                "  Child-Left\n" +
                "  Child-Middle\n" +
                "    Grand-Child\n" +
                "  Child-Right\n",
                tree.ToString());
        }
    }
}