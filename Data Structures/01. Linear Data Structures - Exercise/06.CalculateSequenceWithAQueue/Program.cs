using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Problem06.CalculateSequenceWithAQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstElement = int.Parse(Console.ReadLine());

            var elements = CalculateSequence(firstElement);

            Console.WriteLine(String.Join(" ", elements));
        }

        static List<int> CalculateSequence(int firstElement)
        {
            var elements = new List<int>();

            var queue = new Queue<int>();

            queue.Enqueue(firstElement);

            while (elements.Count < 50)
            {
                queue.Enqueue(queue.Peek() + 1);
                queue.Enqueue(2 * queue.Peek() + 1);
                queue.Enqueue(queue.Peek() + 2);

                elements.Add(queue.Dequeue());
            }

            return elements;
        }
    }
}
