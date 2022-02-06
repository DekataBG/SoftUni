using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            var queue = new Queue<char>();
            queue = Enqueue(snake);



            for (int i = 0; i < dimentions[0]; i++)
            {
                char[] arr = new char[dimentions[1]];

                if (i % 2 == 0)
                {
                    for (int p = 0; p < dimentions[1]; p++)
                    {
                        if (queue.Count == 0)
                            queue = Enqueue(snake);

                        arr[p] = queue.Dequeue();
                    }
                }
                else
                {
                    for (int p = dimentions[1] - 1; p >= 0; p--)
                    {
                        if (queue.Count == 0)
                            queue = Enqueue(snake);

                        arr[p] = queue.Dequeue();
                    }
                }

                Console.WriteLine(String.Join("", arr));
            }
        }

        static Queue<char> Enqueue(string snake)
        {
            var queue = new Queue<char>();

            foreach (var ch in snake)
            {
                queue.Enqueue(ch);
            }

            return queue;
        }
    }
}
