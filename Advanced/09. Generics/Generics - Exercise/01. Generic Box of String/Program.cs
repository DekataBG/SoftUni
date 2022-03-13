using System;

namespace _01._Generic_Box_of_String
{
    public class Program
    {
        public static void Main(string[] args)
        {
<<<<<<< HEAD
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());

                Console.WriteLine(box.ToString());
            }
=======
            Box<string> box = new Box<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
                box.Add(Console.ReadLine());

            Console.WriteLine(box.ToString());
>>>>>>> 3a7e7de65173b2e497fa9c76a2f3d311452c0991
        }
    }
}
