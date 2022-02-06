using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] bottles = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int wasted = 0;
            int queueElement = 0;

            var queue = new Queue<int>();
            var stack = new Stack<int>();

            foreach (var item in cups)
                queue.Enqueue(item);
            foreach (var item in bottles)
                stack.Push(item);

            while (queue.Count > 0 && stack.Count > 0)
            {
                queueElement = queue.Peek();
                while (queueElement > 0 && stack.Count > 0)
                {
                    if (queueElement - stack.Peek() <= 0)
                    {
                        wasted += stack.Peek() - queueElement;
                        queueElement = queueElement - stack.Peek();
                        queue.Dequeue();
                        stack.Pop();
                    }
                    else
                    {
                        queueElement = queueElement - stack.Peek();
                        stack.Pop();
                    }
                }
            }

            if (queue.Count > 0)
            {
                Console.Write("Cups:");
                foreach (var item in queue)
                    Console.Write(" " + item);
                Console.WriteLine();
            }

            else if (stack.Count > 0)
            {
                Console.Write("Bottles:");
                foreach (var item in stack)
                    Console.Write(" " + item);
                Console.WriteLine();
            }
            Console.WriteLine($"Wasted litters of water: {wasted}");
        }
    }
}
