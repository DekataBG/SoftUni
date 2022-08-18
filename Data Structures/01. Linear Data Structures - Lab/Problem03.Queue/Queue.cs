namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> head;

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

        public T Dequeue()
        {
            EnsureNotEmpty();

            var element = head.Value;

            var newHead = head.Next;

            head = newHead;

            Count--;

            return element;
        }

        public void Enqueue(T item)
        {
            if (Count == 0)
            {
                head = new Node<T>(item, null);

                Count++;

                return;
            }

            var currentNode = head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = new Node<T>(item, null);

            Count++;
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentHead = head;

            while (currentHead != null)
            {
                yield return currentHead.Value;
                currentHead = currentHead.Next;
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