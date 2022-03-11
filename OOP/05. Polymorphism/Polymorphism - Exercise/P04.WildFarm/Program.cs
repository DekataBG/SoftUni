using P04.WildFarm.Animals;
using P04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace P04.WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");


            var animals = new List<Animal>();

            var ctr = 0;
            var command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                if (ctr % 2 == 0)
                {
                    animals.Add(AnimalManager(command[0], command));
                }
                else
                {
                    var animal = animals[animals.Count - 1];
                    var food = FoodManager(command[0], int.Parse(command[1]));

                    Console.WriteLine(animal.ProduceSound());

                    animal.Eat(food);
                }

                ctr++;
                command = Console.ReadLine().Split();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        static Animal AnimalManager(string type, string[] command)
        {
            switch (type)
            {
                case "Cat":
                    return new Cat(command[1], double.Parse(command[2]), command[3], command[4]);

                case "Tiger":
                    return new Tiger(command[1], double.Parse(command[2]), command[3], command[4]);

                case "Owl":
                    return new Owl(command[1], double.Parse(command[2]), double.Parse(command[3]));

                case "Hen":
                    return new Hen(command[1], double.Parse(command[2]), double.Parse(command[3]));

                case "Mouse":
                    return new Mouse(command[1], double.Parse(command[2]), command[3]);

                default:
                    return new Dog(command[1], double.Parse(command[2]), command[3]);
            }
        }

        static Food FoodManager(string type, int quantity)
        {
            switch (type)
            {
                case "Fruit":
                    return new Fruit(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                default:
                    return new Vegetable(quantity);
            }
        }
    }
}
