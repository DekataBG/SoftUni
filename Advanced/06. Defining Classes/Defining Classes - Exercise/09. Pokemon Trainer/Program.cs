using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Trainer>();
            string[] command1 = Console.ReadLine().Split();

            while (command1[0] != "Tournament")
            {
                Pokemon pokemon = new Pokemon(command1[1], command1[2], int.Parse(command1[3]));
                Trainer trainer = people.FirstOrDefault(p => p.Name == command1[0]);

                if (trainer == null)
                    people.Add(new Trainer(command1[0], pokemon));
                else
                    trainer.Pokemons.Add(pokemon);

                command1 = Console.ReadLine().Split();
            }

            string command2 = Console.ReadLine();

            while (command2 != "End")
            {
                foreach (var trainer in people)
                    trainer.CheckForElement(command2);

                command2 = Console.ReadLine();
            }

            foreach (var trainer in people)
            {
                trainer.Print();
            }
        }
    }
}
