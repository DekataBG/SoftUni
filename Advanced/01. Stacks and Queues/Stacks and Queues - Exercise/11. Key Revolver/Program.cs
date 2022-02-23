using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bullet = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());
            int shots = 0;

            var stack = new Stack<int>();
            foreach (var item in bullets)
                stack.Push(item);

            var queue = new Queue<int>();
            foreach (var item in locks)
                queue.Enqueue(item);


            while (stack.Count > 0 && queue.Count > 0)
            {
                if (stack.Pop() <= queue.Peek())
                {
                    queue.Dequeue();
                    shots++;
                    Console.WriteLine("Bang!");
                }
                else
                {
                    shots++;
                    Console.WriteLine("Ping!");
                }
                if (shots % gunBarrel == 0 && stack.Count > 0)
                    Console.WriteLine("Reloading!");
            }
            if (queue.Count > 0)
                Console.WriteLine($"Couldn't get through. Locks left: {queue.Count}");
            else
                Console.WriteLine($"{stack.Count} bullets left. Earned ${intelligence - shots * bullet}");
        }
    }
}
