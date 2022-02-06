using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                dict = AddNumber(number, dict);
            }
            Console.WriteLine(dict.Keys.FirstOrDefault(d => dict[d]  % 2 == 0));
        }

        private static Dictionary<int, int> AddNumber(int number, Dictionary<int, int> dict)
        {
            if (dict.ContainsKey(number))
                dict[number]++;
            else
                dict.Add(number, 1);

            return dict;
        }

    }
}
