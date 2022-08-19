namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.Http.Headers;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newHead = new Node<T>(item, head);

            head = newHead;

            Count++;
        }

        public void AddLast(T item)
        {
            if (Count == 0)
            {
                head = new Node<T>(item);
            }            
            else
            {
                var currentNode = head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = new Node<T>(item);
            }

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

            var currentNode = head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Value;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            var oldHead = head;

            head = head.Next;

            Count--;

            return oldHead.Value;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            T oldHead;

            if (Count == 1)
            {
                oldHead = head.Value;
                head = null;
            }
            else
            {
                var currentHead = head;

                while (currentHead.Next.Next != null)
                {
                    currentHead = currentHead.Next;
                }

                oldHead = currentHead.Next.Value;
                currentHead.Next = null;
            }

            Count--;

            return oldHead;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = head;

            while (currentNode.Next != null)
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
                throw new InvalidOperationException("The list is empty.");
            }
        }
    }
}