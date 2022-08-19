namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[Count - 1 - index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            GrowIfNecessary();

            items[Count++] = item;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            int index = -1;

            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    index = Count - 1 - i;
                }
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            GrowIfNecessary();
            ValidateIndex(index);

            var newArr = new T[Count + 1];

            for (int i = 0; i < index; i++)
            {
                newArr[i] = items[i];
            }

            newArr[index] = item;

            //if (index + 1 < Count)
            {
                for (int i = index; i < Count; i++)
                {
                    newArr[i + 1] = items[i];
                }
            }

            items = newArr;

            Count++;
        }

        public bool Remove(T item)
        {
            EnsureNotEmpty();

            if (IndexOf(item) == -1)
            {
                return false;
            }

            RemoveAt(IndexOf(item));

            return true;
        }

        public void RemoveAt(int index)
        {
            EnsureNotEmpty();
            ValidateIndex(index);

            var newArr = new T[Count - 1];

            for (int i = 0; i < index; i++)
            {
                newArr[i] = items[i];
            }

            for (int i = index; i < Count - 1; i++)
            {
                newArr[i] = items[i + 1];
            }

            items = newArr; 

            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Grow()
        {
            var newArray = new T[2 * items.Length];
            Array.Copy(items, newArray, items.Length);

            items = newArray;

        }

        private void GrowIfNecessary()
        {
            if (Count == items.Length)
            {
                Grow();
            }
        }

        private void EnsureNotEmpty()
        {
            if (Count == 0) 
            {
                throw new NotImplementedException();
            }
        }
        
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}