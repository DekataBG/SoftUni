using System;

namespace P01.SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(SquareRoot(double.Parse(Console.ReadLine())));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        static double SquareRoot(double number)
        {
            if (number < 0)
                throw new ArgumentException("Invalid number.");
            else
                return Math.Sqrt(number);
        }
    }
}
