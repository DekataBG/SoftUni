using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class MyList<T>
    {
        public MyList()
        {
            Arr = new T[1];
            Count = 0;
        }
        public int Count { get; private set; }
        public T[] Arr { get; set; }
        public void Add(T element)
        {
            if(Count == Arr.Length)
            {
                var newArr = new T[Arr.Length * 2];
                Arr.CopyTo(newArr, 0);
                newArr[Count] = element;
                Arr = newArr;
                Count++;
            }
            else
            {
                Arr[Count] = element;
                Count++;
            }

        }
        public T RemoveAt(int index)
        {
            T element = Arr[index];

            for (int i = index; i < Count; i++)
                Arr[i] = Arr[i + 1];

            Count--;
            return element;
        }
        public bool Contains(T element)
        {
            for (int i = 0; i < Count; i++)
                if (Arr[i].Equals(element))
                    return true;

            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            var temp = Arr[firstIndex];
            Arr[firstIndex] = Arr[secondIndex];
            Arr[secondIndex] = temp;
        }
        public void Shrink()
        {
            var newArr = new T[Count];

            for (int i = 0; i < Count; i++)
                newArr[i] = Arr[i];

            Arr = newArr;
        }
    }
}
