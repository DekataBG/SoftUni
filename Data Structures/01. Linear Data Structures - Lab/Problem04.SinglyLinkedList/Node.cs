namespace Problem04.SinglyLinkedList
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> next) : this(value)
        {
            Next = next;    
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }
    }
}