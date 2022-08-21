namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design.Serialization;
    using System.Linq;
    using System.Xml.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private Tree<T> parent;
        private List<Tree<T>> children;

        public Tree(T value)
        {
            this.value = value;
            children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var node = FindNodeBfs(parentKey);

            node.children.Add(child);
            child.parent = node;
        }

        public void RemoveNode(T nodeKey)
        {
            var node = FindNodeBfs(nodeKey);

            if (node.parent == null)
            {
                throw new ArgumentException();
            }

            node.parent.children.Remove(node);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var node1 = FindNodeBfs(firstKey);
            var node2 = FindNodeBfs(secondKey);

            if (IsRoot(node1) || IsRoot(node2))
            {
                throw new ArgumentException();
            }

            var firstParent = node1.parent;
            var secondParent = node2.parent;

            var firstIndex = firstParent.children.IndexOf(node1);
            var secondIndex = secondParent.children.IndexOf(node2);

            firstParent.children[firstIndex] = node2;
            node1.parent = secondParent;

            node2.parent.children[secondIndex] = node1;
            node2.parent = firstParent;
        }

        public IEnumerable<T> OrderBfs()
        {
            var result = new List<T>();

            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                foreach (var child in currentNode.children)
                {
                    queue.Enqueue(child);
                }

                result.Add(currentNode.value);
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            var result = new Stack<T>();

            var stack = new Stack<Tree<T>>();

            stack.Push(this);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();

                foreach (var child in currentNode.children)
                {
                    stack.Push(child);
                }

                result.Push(currentNode.value);
            }

            return result;
        }

        public void OrderDfsByRecursion(Tree<T> root)
        {
            Console.Write(root.value + " ");

            if (root.children.Count == 0)
            {
                return;
            }

            root.children.Reverse();

            foreach (var child in root.children)
            {
                OrderDfsByRecursion(child);
            }
        }

        private Tree<T> FindNodeBfs(T value)
        {
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.value.Equals(value))
                {
                    return currentNode;
                }

                foreach (var child in currentNode.children)
                {
                    queue.Enqueue(child);
                }
            }

            throw new ArgumentNullException();
        }

        private bool IsRoot(Tree<T> node)
        {
            return node.parent == null;
        }

        private bool HaveSameParent(Tree<T> node1, Tree<T> node2)
        {
            return node1.parent.Equals(node2.parent);
        }

        private int FindIndex(Tree<T> node, IEnumerable<T> values)
        {
            return values.ToList().IndexOf(node.value);
        }

        private bool IsChildOf(Tree<T> parent, Tree<T> child)
        {
            return parent.children
                .FirstOrDefault(c => c.Equals(child.value)) != null;

        }

        private bool AreNotRelated(Tree<T> node1, Tree<T> node2)
        {
            return !IsChildOf(node1, node2) && !IsChildOf(node2, node1);
        }

        private bool IsLeaf(Tree<T> node)
        {
            return node.children.Count == 0;
        }
    }
}
