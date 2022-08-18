namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            foreach (var element in this)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return top.Value;
        }

        public T Pop()
        {
            EnsureNotEmpty();

            var element = top.Value;

            var newTop = top.Next;

            top = newTop;

            Count--;

            return element;
        }

        public void Push(T item)
        {
            var newTop = new Node<T>(item, top);

            top = newTop;

            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentTop = top;

            while (currentTop != null)
            {
                yield return currentTop.Value;
                currentTop = currentTop.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void EnsureNotEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
        }
    }
}