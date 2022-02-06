using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Tuple<int, int>> list = new List<Tuple<int, int>>();
            for (int i = 0; i < n; i++)
            {
                int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                list.Add(new Tuple<int, int>(row[0], row[1]));
            }

            List<Tuple<int, int>> newList = new List<Tuple<int, int>>();


            for (int i = 0; i < n; i++)
            {
                newList = TransformList(list, i);

                if (CompleteCircle(ConvertToQueue(newList)))
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
        public static bool CompleteCircle(Queue<Tuple<int, int>> queue)
        {
            int fuel = 0, initialFuel = queue.Peek().Item1;
            while (queue.Count > 0)
            {
                fuel += queue.Peek().Item1;
                if (fuel < queue.Peek().Item2)
                    return false;
                else
                {
                    fuel -= queue.Peek().Item2;
                    queue.Dequeue();
                }
            }
            //if (fuel < initialFuel)
            //{
            //    return false;
            //}
            return true;
        }
        public static List<Tuple<int, int>> TransformList(List<Tuple<int, int>> list, int index)
        {
            List<Tuple<int, int>> newList = new List<Tuple<int, int>>();
            for (int i = index; i < list.Count + index; i++)
            {
                newList.Add(list[i % list.Count]);
            }

            return newList;
        }
        public static Queue<Tuple<int, int>> ConvertToQueue(List<Tuple<int, int>> list)
        {
            var queue = new Queue<Tuple<int, int>>();
            for (int i = 0; i < list.Count; i++)
                queue.Enqueue(list[i]);

            return queue;
        }
    }
}
