namespace Animals
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animal = Console.ReadLine();

            while (animal != "Beast!")
            {
                var feautures = Console.ReadLine().Split();

                Animal newAnimal = default;

                switch (animal)
                {

                    case "Dog":
                        newAnimal = new Dog(feautures[0], int.Parse(feautures[1]), feautures[2]);
                        break;
                    case "Cat":
                        newAnimal = new Cat(feautures[0], int.Parse(feautures[1]), feautures[2]);
                        break;
                    case "Frog":
                        newAnimal = new Frog(feautures[0], int.Parse(feautures[1]), feautures[2]);
                        break;
                    case "Kitten":
                        newAnimal = new Kitten(feautures[0], int.Parse(feautures[1]));
                        break;
                    case "Tomcat":
                        newAnimal = new Tomcat(feautures[0], int.Parse(feautures[1]));
                        break;
                }

                if (String.IsNullOrWhiteSpace(newAnimal.Name) || String.IsNullOrWhiteSpace(newAnimal.Age.ToString()) ||
                String.IsNullOrWhiteSpace(newAnimal.Gender) || newAnimal.Age < 0)
                    Console.WriteLine("Invalid input!");
                else
                {
                    Console.WriteLine(newAnimal.GetType().Name);
                    Console.WriteLine($"{newAnimal.Name} {newAnimal.Age} {newAnimal.Gender}");
                    Console.WriteLine(newAnimal.ProduceSound());
                }

                animal = Console.ReadLine();
            }

        }
    }
}
