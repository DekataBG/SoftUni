namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;

            if (leftChild != null)
            {
                LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var nodes = BfsTraverse(this);

            var firstNode = nodes
                .FirstOrDefault(n => n.Value.Equals(first) ||
                n.Value.Equals(second));

            if (firstNode == null)
            {
                throw new InvalidOperationException();
            }

            var secondNode = nodes
                .FirstOrDefault(n => (n.Value.Equals(first) ||
                n.Value.Equals(second)) && !n.Value.Equals(firstNode.Value));

            if (secondNode == null)
            {
                throw new InvalidOperationException();
            }

            var node = FindLowestCommonAncestor(firstNode, secondNode);

            return node.Value;
        }

        private IEnumerable<BinaryTree<T>> BfsTraverse(BinaryTree<T> root)
        {
            var result = new List<BinaryTree<T>>();

            var queue = new Queue<BinaryTree<T>>();

            queue.Enqueue(root);

            while (queue.Count() > 0)
            {
                var node = queue.Dequeue();

                if (node.LeftChild != null)
                {
                    queue.Enqueue(node.LeftChild);
                }

                if (node.RightChild != null)
                {
                    queue.Enqueue(node.RightChild);
                }

                result.Add(node);
            }

            return result;
        }

        private BinaryTree<T> FindLowestCommonAncestor(BinaryTree<T> first, BinaryTree<T> second)
        {
            var currentNode = first;

            while (currentNode != null)
            {
                if (BfsTraverse(currentNode).Contains(second))
                {
                    return currentNode;
                }

                currentNode = currentNode.Parent;
            }

            return null;
        }
    }
}
