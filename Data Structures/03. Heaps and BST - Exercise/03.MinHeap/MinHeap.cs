using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            elements = new List<T>();
        }

        public int Count => elements.Count;

        public int Size => Count;

        public void Add(T element)
        {
            if (Count == 0)
            {
                elements.Add(element);
                return;
            }

            elements.Add(element);
            var childIndex = Count - 1;
            var parentIndex = (childIndex - 1) / 2;

            var child = elements[childIndex];
            var parent = elements[parentIndex];

            while (parent.CompareTo(child) > 0)
            {
                if (parentIndex < 0)
                {
                    break;
                }

                child = elements[parentIndex];
                parent = elements[childIndex];

                elements[parentIndex] = parent;
                elements[childIndex] = child;

                childIndex = parentIndex;
                parentIndex = (childIndex - 1) / 2;

                child = elements[childIndex];
                parent = elements[parentIndex];
            }

        }

        public T ExtractMin()
        {
            EnsureNotEmpty();

            var result = elements[0];

            Swap(0, Count - 1);

            elements.RemoveAt(Count - 1);

            HeapifyDown(0);

            return result;
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return elements[0];
        }

        private void EnsureNotEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private void Swap(int index1, int index2)
        {
            var element1 = elements[index1];

            elements[index1] = elements[index2];
            elements[index2] = element1;
        }

        public void HeapifyDown(int index)
        {
            if (2 * index + 1 >= Count)
            {
                return;
            }

            var current = elements[index];

            var smallerChild = GetSmallerChild(index);
            var indexOfSmallerChild = elements.IndexOf(smallerChild);

            while (current.CompareTo(smallerChild) > 0)
            {
                Swap(index, indexOfSmallerChild);
                index = indexOfSmallerChild;

                if (IndexIsInRange(index))
                {
                    current = elements[index];

                    smallerChild = GetSmallerChild(index);
                    indexOfSmallerChild = elements.IndexOf(smallerChild);
                }
                else
                {
                    break;
                }
            }
        }

        private T GetSmallerChild(int index)
        {
            if (2 * index + 2 == Count)
            {
                return elements[2 * index + 1];
            }

            var child1 = elements[2 * index + 1];
            var child2 = elements[2 * index + 2];

            return child1.CompareTo(child2) > 0 ? child2 : child1;
        }

        private bool IndexIsInRange(int index)
        {
            return 2 * index + 2 < Count;
        }
    }
}
