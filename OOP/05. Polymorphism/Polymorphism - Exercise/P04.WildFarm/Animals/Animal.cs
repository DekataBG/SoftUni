using P04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.WildFarm.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight, int foodEaten, double addedWeight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
            AddedWeight = addedWeight;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public double AddedWeight { get; set; }

        public abstract string ProduceSound();

        public abstract void Eat(Food food);
    }
}
