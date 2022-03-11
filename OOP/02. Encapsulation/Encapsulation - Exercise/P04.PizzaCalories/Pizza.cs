using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.PizzaCalories
{
    public class Pizza
    {
        private string name;

        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
        }
        public string Name 
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                else
                    name = value;
            }
        }
        public Dough Dough { get; set; }
        public List<Topping> Toppings { get; set; }
        public decimal Calories 
        { 
            get
            {
                decimal calories = 0;

                if(Dough != null)
                    calories = Dough.Calories;

                foreach (var topping in Toppings)
                    calories += topping.Calories;

                return calories;
            }
        }

        public void AddToping(Topping topping)
        {
            if (Toppings.Count == 10)
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            else
                Toppings.Add(topping);
        }
    }
}
