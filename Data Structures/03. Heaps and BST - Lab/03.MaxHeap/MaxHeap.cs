namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            elements = new List<T>();
        }

        public int Size => elements.Count;

        public void Add(T element)
        {
            elements.Add(element);

            Heapify(Size - 1);
        }

        public T ExtractMax()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }

            var maxElement = elements[0];

            elements.RemoveAt(0);

            return maxElement;
        }

        public T Peek()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }

            return elements[0];
        }

        private void Heapify(int index)
        {
            if (index == 0)
            {
                return;
            }

            var parentIndex = GetParentIndex(index);

            if (elements[parentIndex].CompareTo(elements[index]) < 0)
            {
                SwapElements(index, parentIndex);
                Heapify(parentIndex);
            }
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private void SwapElements(int index1, int index2)
        {
            var element1 = elements[index1];
            var element2 = elements[index2];

            elements[index1] = element2;
            elements[index2] = element1;
        }
    }
}
