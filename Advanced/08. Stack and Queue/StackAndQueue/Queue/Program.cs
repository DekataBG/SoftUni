using System;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new MyQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.ForEach(e => Console.Write(e + " "));
            Console.WriteLine();

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Peek());

            queue.ForEach(e => Console.Write(e + " "));
            Console.WriteLine();

            queue.Clear();
            Console.WriteLine(queue.Count);
        }
    }
}
