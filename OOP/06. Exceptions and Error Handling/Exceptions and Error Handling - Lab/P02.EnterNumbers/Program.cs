using System;
using System.Collections.Generic;

namespace P02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();

            while (list.Count < 10)
            {
                try
                {
                    if (list.Count == 0)
                        list.Add(ReadNumber(1, 100));
                    else
                        list.Add(ReadNumber(list[list.Count - 1], 100));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(", ", list));
        }

        static int ReadNumber(int start, int end)
        {
            var number = Console.ReadLine();
            int intNumber;

            if (int.TryParse(number, out intNumber))
            {
                if(intNumber > start && intNumber < end)
                {
                    return intNumber;
                }
                else
                {
                    throw new Exception($"Your number is not in range {start} - 100!");
                }
            }
            else
            {
                throw new Exception("Invalid Number!");
            }
        }
    }
}
