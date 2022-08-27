namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        private int coordinate;
        private Dictionary<int, BinaryTree<T>> nodes;

        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            Value = value;
            LeftChild = left;
            RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            return AddNodes()
                .Select(n => n.Value.Value)
                .ToList();
        }

        private List<BinaryTree<T>> BfsTraverse()
        {
            var result = new List<BinaryTree<T>>();

            var queue = new Queue<BinaryTree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.LeftChild != null)
                {
                    currentNode.LeftChild.coordinate = currentNode.coordinate - 1;
                    queue.Enqueue(currentNode.LeftChild);
                }

                if (currentNode.RightChild != null)
                {
                    currentNode.RightChild.coordinate = currentNode.coordinate + 1;
                    queue.Enqueue(currentNode.RightChild);
                }

                result.Add(currentNode);
            }

            return result;
        }

        private Dictionary<int, BinaryTree<T>> AddNodes()
        {
            nodes = new Dictionary<int, BinaryTree<T>>();

            var allNodes = BfsTraverse();

            foreach (var node in allNodes)
            {
                if (!nodes.ContainsKey(node.coordinate))
                {
                    nodes.Add(node.coordinate, node);
                }
            }

            return nodes;
        }
    }
}
