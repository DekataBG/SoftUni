using System;

namespace _01._Generic_Box_of_String
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());

                Console.WriteLine(box.ToString());
            }
        }
    }
}
