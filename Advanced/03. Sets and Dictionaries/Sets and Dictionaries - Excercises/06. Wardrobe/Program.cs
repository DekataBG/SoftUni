using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" -> ");
                string color = command[0];
                string[] clothes = command[1].Split(',');

                dict = AddColor(color, clothes, dict);
            }

            string[] lastCommand = Console.ReadLine().Split();

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} clothes: ");
                foreach (var cloth in dict[item.Key])
                {
                    if(item.Key == lastCommand[0] && cloth.Key == lastCommand[1])
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!) ");
                    else
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} ");
                }
            }
        }

        private static Dictionary<string, Dictionary<string, int>> AddColor(string color, 
            string[] clothes, Dictionary<string, Dictionary<string, int>> dict)
        {
            if (dict.ContainsKey(color))
                dict[color] = AddCloth(clothes, dict[color]);
            else
            {
                var newDict = new Dictionary<string, int>();
                newDict = AddCloth(clothes, newDict);

                dict.Add(color, newDict);
            }

            return dict;
        }

        private static Dictionary<string, int> AddCloth(string[] clothes, Dictionary<string, int> dictionary)
        {
            foreach (var cloth in clothes)
            {
                if (dictionary.ContainsKey(cloth))
                    dictionary[cloth]++;
                else
                    dictionary[cloth] = 1;
            }

            return dictionary;
        }
    }
}
