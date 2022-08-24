namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree() { }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = this.FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        //TODO: 
        public void Delete(T element)
        {
            if (root is null)
            {
                throw new InvalidOperationException();
            }

            Node searchedNodeParent = TraversePreOrder(root, new List<Node>())
                .FirstOrDefault(n => n.Left.Value.Equals(element)
                    || n.Right.Value.Equals(element));


            if (searchedNodeParent is null)
            {
                throw new InvalidOperationException();
            }

            Node searchedNode;

            if (searchedNodeParent.Left.Value.Equals(element))
            {
                searchedNode = searchedNodeParent.Left;
            }
            else
            {
                searchedNode = searchedNodeParent.Right;
            }


            var nodes = TraversePreOrder(searchedNode, new List<Node>());

            searchedNode = null;
            if (searchedNodeParent.Left.Value.Equals(element))
            {
                searchedNodeParent.Left = null;
            }
            else
            {
                searchedNodeParent.Right = null;
            }


            foreach (var node in nodes.Where(n => !n.Value.Equals(element)))
            {
                Insert(node.Value);
            }

        }

        public void DeleteMax()
        {
            throw new NotImplementedException();
        }

        public void DeleteMin()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return TraversePreOrder(root, new List<Node>()).Count();
        }

        public int Rank(T element)
        {
            var nodes = TraversePreOrder(root, new List<Node>())
                .Where(n => n.Value.CompareTo(element) < 0);

            return nodes.Count();
        }

        public T Select(int rank)
        {
            if (Count() == 0)
            {
                throw new InvalidOperationException();
            }

            var node = TraversePreOrder(root, new List<Node>())
                .Where(n => Rank(n.Value) == rank)
                .FirstOrDefault();

            if (node is null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        public T Ceiling(T element)
        {
            throw new NotImplementedException();
        }

        public T Floor(T element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            var nodes = TraversePreOrder(root, new List<Node>())
                .Where(n => n.Value.CompareTo(startRange) >= 0
                && n.Value.CompareTo(endRange) <= 0)
                .Select(n => n.Value)
                .OrderBy(n => n);

            return nodes;
        }


        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private IEnumerable<Node> TraversePreOrder(Node node, List<Node> result)
        {
            if (node is null)
            {
                return result;
            }

            result.Add(node);

            TraversePreOrder(node.Left, result);
            TraversePreOrder(node.Right, result);

            return result;
        }
    }
}
