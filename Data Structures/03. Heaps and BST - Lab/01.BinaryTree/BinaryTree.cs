namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            Value = element;
            LeftChild = left;
            RightChild = right;
        }

        public T Value  { get; }

        public IAbstractBinaryTree<T> LeftChild { get; }

        public IAbstractBinaryTree<T> RightChild { get; }

        public string AsIndentedPreOrder(int indent)
        {
            return DfsTraversePreOrderPrint(indent, new StringBuilder(), this);
        }

        public void ForEachInOrder(Action<T> action)
        {
            var nodes = DfsTraverseInOrder(new List<IAbstractBinaryTree<T>>(), this);

            foreach (var node in nodes)
            {
                action(node.Value);
            }
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            return DfsTraverseInOrder(new List<IAbstractBinaryTree<T>>(), this);
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            return DfsTraversePostOrder(new List<IAbstractBinaryTree<T>>(), this);
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            return DfsTraversePreOrder(new List<IAbstractBinaryTree<T>>(), this);
        }


        private IEnumerable<IAbstractBinaryTree<T>> DfsTraverseInOrder(List<IAbstractBinaryTree<T>> result, 
            IAbstractBinaryTree<T> currentNode)
        {
            if (currentNode is null)
            {
                return result;
            }

            DfsTraverseInOrder(result, currentNode.LeftChild);

            result.Add(currentNode);

            DfsTraverseInOrder(result, currentNode.RightChild);

            return result;
        }

        private IEnumerable<IAbstractBinaryTree<T>> DfsTraversePostOrder(List<IAbstractBinaryTree<T>> result,
            IAbstractBinaryTree<T> currentNode)
        {
            if (currentNode is null)
            {
                return result;
            }

            DfsTraversePostOrder(result, currentNode.LeftChild);

            DfsTraversePostOrder(result, currentNode.RightChild);

            result.Add(currentNode);

            return result;
        }

        private IEnumerable<IAbstractBinaryTree<T>> DfsTraversePreOrder(List<IAbstractBinaryTree<T>> result,
            IAbstractBinaryTree<T> currentNode)
        {
            if (currentNode is null)
            {
                return result;
            }

            result.Add(currentNode);

            DfsTraversePreOrder(result, currentNode.LeftChild);

            DfsTraversePreOrder(result, currentNode.RightChild);

            return result;
        }

        private string DfsTraversePreOrderPrint(int indent,StringBuilder result,
            IAbstractBinaryTree<T> currentNode)
        {
            if (currentNode is null)
            {
                return result.ToString().TrimEnd();
            }

            result.AppendLine(new string(' ', indent) + currentNode.Value);

            DfsTraversePreOrderPrint(indent + 2, result, currentNode.LeftChild);

            DfsTraversePreOrderPrint(indent + 2, result, currentNode.RightChild);

            return result.ToString().TrimEnd();
        }
    }
}
