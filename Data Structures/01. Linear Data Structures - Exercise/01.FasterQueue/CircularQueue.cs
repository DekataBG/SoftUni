namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private const int DefaultArrayCapacity = 4;

        private T[] elements;

        private int startIndex, endIndex;

        public CircularQueue(int capacity = DefaultArrayCapacity)
        {
            elements = new T[capacity];
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            EnsureNotEmpty();

            var deletedElement = elements[startIndex];

            elements[startIndex] = default;

            startIndex = (startIndex + 1) % elements.Length;

            Count--;

            return deletedElement;
        }

     

        public void Enqueue(T item)
        {
            GrowIfNecessary();

            elements[endIndex] = item;

            endIndex = (endIndex + 1) % elements.Length;

            Count++;
        }
        

        public T Peek()
        {
            EnsureNotEmpty();

            return elements[startIndex];
        }

      
        
        public T[] ToArray()
        {
            var newArray = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                newArray[i] = elements[(startIndex + i) % Count];
            }

            return newArray;
        }

       

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                var index = (startIndex + i) % elements.Length;
                yield return elements[index];
            }
        }

      
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

     
        
        private void EnsureNotEmpty()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException("The array is empty.");
            }
        }

    
        
        private void Grow()
        {
            var newArray = new T[2 * elements.Length];

            Array.Copy(elements, newArray, elements.Length);

            elements = newArray;

            startIndex = 0;
            endIndex = Count;
        }

        private void GrowIfNecessary()
        {
            if (Count == elements.Length)
            {
                Grow();
            }
        }
    }

}
