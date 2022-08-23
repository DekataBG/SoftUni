namespace _02.BinarySearchTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Xml.Linq;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }

        private Node root;

        public BinarySearchTree() { }

        private BinarySearchTree(Node node)
        {
            CopyPreOrder(node);
        }

        public bool Contains(T element)
        {
            var nodes = new List<T>();

            EachInOrder(n => nodes.Add(n));

            foreach (var node in nodes)
            {
                if (node.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(action, root);
        }

        public void Insert(T element)
        {
            if (root is null)
            {
                root = new Node(element);
                return;
            }

            Insert(element, root);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = FindNode(element);

            if (node is null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node is null)
            {
                return;
            }

            EachInOrder(action, node.Left);

            action(node.Value);

            EachInOrder(action, node.Right);
        }

        private void Insert(T element, Node node)
        {
            if (element.CompareTo(node.Value) > 0)
            {
                if (node.Right is null)
                {
                    node.Right = new Node(element);
                }
                else
                {
                    Insert(element, node.Right);
                }
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                if (node.Left is null)
                {
                    node.Left = new Node(element);
                }
                else
                {
                    Insert(element, node.Left);
                }
            }
        }

        private IEnumerable<Node> GetNodesPreOrder(ICollection<Node> result, Node node)
        {
            if (node is null)
            {
                return result;
            }

            result.Add(node);

            GetNodesPreOrder(result, node.Left);

            GetNodesPreOrder(result, node.Right);

            return result;
        }

        private Node FindNode(T element)
        {
            var node = GetNodesPreOrder(new Collection<Node>(), root)
                .FirstOrDefault(n => n.Value.Equals(element));
            return node;
        }

        private void CopyPreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            Insert(node.Value);
            CopyPreOrder(node.Left);
            CopyPreOrder(node.Right);
        }
    }
}
