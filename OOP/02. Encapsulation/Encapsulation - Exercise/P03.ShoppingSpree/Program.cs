using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var people = new List<Person>();
            var products = new List<Product>();

            try
            {
                var line1 = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in line1)
                {
                    var subcommand = item.Split('=');

                    people.Add(new Person(subcommand[0], decimal.Parse(subcommand[1])));

                }

                var line2 = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in line2)
                {
                    var subcommand = item.Split('=');

                    products.Add(new Product(subcommand[0], decimal.Parse(subcommand[1])));

                }


                var command = Console.ReadLine().Split();

                while (command[0] != "END")
                {
                    var person = people.Where(p => p.Name == command[0]).FirstOrDefault();
                    var product = products.Where(p => p.Name == command[1]).FirstOrDefault();

                    if (person.Money >= product.Cost)
                    {
                        person.Money -= product.Cost;
                        person.Products.Add(product);
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }

                    command = Console.ReadLine().Split();
                }

                foreach (var person in people)
                {
                    var names = new List<string>();
                    foreach (var product in person.Products)
                    {
                        names.Add(product.Name);
                    }

                    if (names.Count > 0)
                        Console.WriteLine($"{person.Name} - {String.Join(", ", names)}");
                    else
                        Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
