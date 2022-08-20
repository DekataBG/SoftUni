namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
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
            for (int i = 0; i < Count; i++)
            {
                var index = Count - 1 - i;

                if (items[index].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            GrowIfNecessary();

            index = Count - 1 - index;

            var newArr = new T[Count + 1];

            for (int i = Count - 1; i > index; i--)
            {
                newArr[i + 1] = items[i];
            }

            newArr[index + 1] = item;

            for (int i = index; i >= 0; i--)
            {
                newArr[i] = items[i];
            }

            items = newArr;

            Count++;
        }

        public bool Remove(T item)
        {
            EnsureNotEmpty();

            if (Contains(item))
            {
                RemoveAt(IndexOf(item));
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            EnsureNotEmpty();

            index = Count - 1 - index;

            ValidateIndex(index);

            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count - 1] = default;
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