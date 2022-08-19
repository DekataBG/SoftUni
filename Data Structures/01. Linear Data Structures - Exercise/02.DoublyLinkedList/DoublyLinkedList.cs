namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head, tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newHead = new Node<T>(item);

            if (Count == 0)
            {
                head = newHead;
                tail = newHead;

                Count++;

                return;
            }

            newHead.Next = head;
            head.Previous = newHead;

            head = newHead;

            Count++;
        }

        public void AddLast(T item)
        {
            var newTail = new Node<T>(item);

            if (Count == 0)
            {
                head = newTail;
                tail = newTail;

                Count++;

                return;
            }

            tail.Next = newTail;
            newTail.Previous = tail;

            tail = newTail;

            Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();

            return head.Value;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            return tail.Value;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            var oldHead = head.Value;

            var newHead = head.Next;

            head = newHead;

            if (head != null)
            {
                head.Previous = null;
            }

            Count--;

            return oldHead;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            var oldTail = tail.Value;

            var newTail = tail.Previous;

            tail = newTail;

            if (tail != null)
            {
                tail.Next = null;
            }

            Count--;

            return oldTail;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = head;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
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
                throw new InvalidOperationException();
            }
        }
    }
}