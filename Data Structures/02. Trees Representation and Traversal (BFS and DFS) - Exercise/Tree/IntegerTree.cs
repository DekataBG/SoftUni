namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var paths = new List<IEnumerable<int>>();
            
            var leaves = BfsTraverseNodes()
                .Where(n => n.Children.Count == 0);

            foreach (var leaf in leaves)
            {
                var leafSum = GetSumOfPathOfLeaf(leaf);

                if (leafSum == sum)
                {
                    paths.Add(GetPathOfLeaf(leaf));
                }
            }

            return paths;
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            var trees = new List<Tree<int>>();

            var nodes = BfsTraverseNodes();

            foreach (var node in nodes)
            {
                if (GetSumOfTree(node) == sum)
                {
                    trees.Add(node);
                }
            }

            return trees;
        }

        private int GetSumOfPathOfLeaf(Tree<int> leaf)
        {
            int sum = 0;

            var currentNode = leaf;

            while (currentNode != null)
            {
                sum += currentNode.Key;

                currentNode = currentNode.Parent;
            }

            return sum;
        }

        private IEnumerable<int> GetPathOfLeaf(Tree<int> leaf)
        {
            var stack = new Stack<int>();

            var currentNode = leaf;

            while (currentNode != null)
            {
                stack.Push(currentNode.Key);

                currentNode = currentNode.Parent;
            }

            return stack;
        }

        private int GetSumOfTree(Tree<int> node)
        {
            var nodes = node.BfsTraverseNodes();

            var sum = nodes.Sum(n => n.Key);

            return sum;
        }

    }
}
