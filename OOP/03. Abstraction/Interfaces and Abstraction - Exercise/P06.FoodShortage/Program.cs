using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            var buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();

                if (command.Length == 3)
                    buyers.Add(new Rebel(command[0], int.Parse(command[1]), command[2]));
                else
                    buyers.Add(new Citizen(command[0], int.Parse(command[1]), command[2], command[3]));
            }

            var buyer = Console.ReadLine();
            while (buyer != "End")
            {
                IBuyer person = buyers.Where(b => b.Name == buyer).FirstOrDefault();

                if (person != null)
                    person.BuyFood();

                buyer = Console.ReadLine();
            }

            var food = 0;
            foreach (var person in buyers)
                food += person.Food;

            Console.WriteLine(food);
        }
    }
}
