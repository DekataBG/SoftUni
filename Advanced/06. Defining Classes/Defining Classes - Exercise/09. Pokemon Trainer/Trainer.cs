using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Pokemon_Trainer
{
    public class Trainer
    {
        public Trainer(string name, Pokemon pokemon)
        {
            Name = name;
            Pokemons.Add(pokemon);
        }
        public string Name { get; set; }
        public int Badges { get; set; } = 0;
        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
        public void CheckForElement(string element)
        {
            if (Pokemons.Where(p => p.Element == element).ToList().Count > 0)
                Badges++;
            else
                foreach (var pokemon in Pokemons)
                    pokemon.Health -= 10;

            Pokemons = Pokemons.Where(p => p.Health > 0).ToList();
            
        }
        public void Print()
        {
            Console.WriteLine($"{Name} {Badges} {Pokemons.Count}");
        }
    }
}
