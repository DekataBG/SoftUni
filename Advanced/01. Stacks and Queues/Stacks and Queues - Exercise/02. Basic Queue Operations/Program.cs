using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] c1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] queue = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numbers = new Queue<int>();

            for (int i = 0; i < c1[0]; i++)
            {
                numbers.Enqueue(queue[i]);
            }
            for (int i = 0; i < c1[1]; i++)
            {
                numbers.Dequeue();
            }
            if (numbers.Contains(c1[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Min());
                }
                else
                    Console.WriteLine(0);
            }
        }
    }
}
