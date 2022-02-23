using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    /*
      void ForEach(Action&lt;int&gt; action) – Goes through each of the elements in the queue
     */
    public class MyQueue<T>
    {
        public MyQueue()
        {
            Items = new T[1];
            Count = 0;
        }
        public T[] Items { get; set; }
        public int Count { get; private set; }
        public void Enqueue(T element)
        {
            if(Count == Items.Length)
            {
                var newArr = new T[Items.Length * 2];
                Items.CopyTo(newArr, 0);
                Items = newArr;
            }

            Items[Count] = element;
            Count++;
        }
        public T Dequeue()
        {
            var element = Items[0];

            for (int i = 0; i < Count; i++)
                Items[i] = Items[i + 1];

            Count--;

            return element;
        }
        public T Peek()
        {
            return Items[0];
        }
        public void Clear()
        {
            Items = new T[1];
        }
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
                action(Items[i]);
        }
    }
}
