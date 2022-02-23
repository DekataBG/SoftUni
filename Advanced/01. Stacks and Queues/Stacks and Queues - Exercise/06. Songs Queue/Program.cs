using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(new string[1] { ", " }, StringSplitOptions.None).ToArray();
            var queue = new Queue<string>();

            foreach (var item in songs)
                queue.Enqueue(item);

            while (queue.Count() > 0)  //add me
            {
                string command = Console.ReadLine();
                string switchh = command;
                if (command.Contains(' '))
                {
                    switchh = command.Substring(0, command.IndexOf(' '));
                }
                switch (switchh)
                {
                    case "Add":
                        if (queue.Contains(command.Substring(4)))
                            Console.WriteLine($"{command.Substring(4)} is already contained!");
                        else
                            queue.Enqueue(command.Substring(4));
                        break;
                    case "Play":
                        queue.Dequeue();
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ", queue));
                        break;
                }

            }
            Console.WriteLine("No more songs!");
        }
    }
}
