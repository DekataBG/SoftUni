using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class MyStack<T>
    {
        public MyStack()
        {
            Count = 0;
            Items = new T[1];
        }
        public T[] Items { get; set; }
        public int Count { get; private set; }
        public void Push(T element)
        {
            if (Count == Items.Length)
            {
                var newArr = new T[Items.Length * 2];
                Items.CopyTo(newArr, 0);
                newArr[Count] = element;
                Items = newArr;
                Count++;
            }
            else
            {
                Items[Count] = element;
                Count++;
            }
        }
        public T Pop()
        {
            var element = Items[Count - 1];

            Count--;

            return element;
        }
        public T Peek()
        {
            return Items[Count - 1];
        }
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
                action(Items[i]);
        }
        public void Shrink()
        {
            var newArr = new T[Count];

            for (int i = 0; i < Count; i++)
                newArr[i] = Items[i];

            Items = newArr;
        }

    }
}
