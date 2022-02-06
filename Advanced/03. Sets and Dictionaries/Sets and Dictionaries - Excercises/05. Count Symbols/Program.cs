using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var list = new List<char>(command);
            list.Sort();

            var dict = new Dictionary<char, int>();

            foreach (var letter in list)
                dict = AddLetter(letter, dict);

            foreach (var letter in dict)
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }

        private static Dictionary<char, int> AddLetter(char letter, Dictionary<char, int> dict)
        {
            if (dict.ContainsKey(letter))
                dict[letter]++;
            else
                dict.Add(letter, 1);

            return dict;
        }
    }
}
