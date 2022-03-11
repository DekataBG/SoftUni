using System;

namespace P04.SumOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = 0;

            var input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    var output = int.Parse(input[i]);
                    sum += output;
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{input[i]}' is out of range!");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{input[i]}' is in wrong format!");
                }
                finally
                {
                    Console.WriteLine($"Element '{input[i]}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
