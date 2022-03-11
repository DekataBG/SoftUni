using System;

namespace P04.PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var command = Console.ReadLine().Split();
            Pizza pizza;

            try
            {
                if (command[0] != "END")
                    pizza = new Pizza(command[1]);
                else
                    pizza = new Pizza("");

                command = Console.ReadLine().Split();

                if (command[0] != "END")
                    pizza.Dough = new Dough(command[1], command[2], int.Parse(command[3]));

                command = Console.ReadLine().Split();

                while (command[0] != "END")
                {
                    pizza.AddToping(new Topping(command[1], int.Parse(command[2])));

                    command = Console.ReadLine().Split();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
