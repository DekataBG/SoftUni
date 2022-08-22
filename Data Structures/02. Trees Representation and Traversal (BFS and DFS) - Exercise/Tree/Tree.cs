namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.children.Add(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            return DfsTraverseString(this, new StringBuilder(), 0);
        }

        public IEnumerable<T> GetInternalKeys()
        {
            var nodes = BfsTraverseNodes()
                .Where(n => n.Parent != null
                    && n.Children.Count > 0)
                .Select(n => n.Key);

            return nodes;
        }

        public IEnumerable<T> GetLeafKeys()
        {
            var nodes = BfsTraverseNodes()
                .Where(n => n.children.Count == 0)
                .Select(n => n.Key);

            return nodes;
        }

        public T GetDeepestKey()
        {
            var nodes = BfsTraverseNodes();

            int maxDepth = 0;
            Tree<T> deepestElement = this;

            foreach (var node in nodes)
            {
                if (node.FindDepth() > maxDepth)
                {
                    maxDepth = node.FindDepth();
                    deepestElement = node;
                }
            }

            return deepestElement.Key;
        }

        public IEnumerable<T> GetLongestPath()
        {
            var deepestNode = BfsTraverseNodes()
                .Where(n => n.Key.Equals(GetDeepestKey()))
                .FirstOrDefault();


            var stack = new Stack<T>();

            var currentNode = deepestNode;

            while (currentNode != null)
            {
                stack.Push(currentNode.Key);

                currentNode = currentNode.Parent;
            }

            return stack;
        }

        public IEnumerable<Tree<T>> BfsTraverseNodes()
        {
            var nodes = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                nodes.Add(node);

                foreach (var child in node.children)
                {
                    queue.Enqueue(child);
                }
            }

            return nodes;
        }

        private string DfsTraverseString(Tree<T> node, StringBuilder result, int depth)
        {
            result.AppendLine(new string(' ', depth * 2) + node.Key);

            foreach (var child in node.children)
            {
                DfsTraverseString(child, result, depth + 1);
            }

            return result.ToString().TrimEnd();
        }

        private int FindDepth()
        {
            int depth = 0;

            var currentNode = this;

            while (currentNode.Parent != null)
            {
                currentNode = currentNode.Parent;
                depth++;
            }

            return depth;
        }
    }
}
