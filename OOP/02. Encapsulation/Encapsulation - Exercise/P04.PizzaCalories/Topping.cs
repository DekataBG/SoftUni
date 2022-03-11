using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private int weigh;

        public Topping(string toppingType, int weigh)
        {
            ToppingType = toppingType;
            Weigh = weigh;
        }

        public string ToppingType
        {
            get => toppingType;
            set
            {
                if (value.ToLower() == "meat" || value.ToLower() == "veggies" 
                    || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                    toppingType = value;
                else
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }
        public int Weigh
        {
            get => weigh;
            set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
                else
                    weigh = value;
            }
        }
        public decimal Calories
        {
            get
            {
                decimal toppingValue;
                if(toppingType.ToLower() == "meat")
                    toppingValue = 1.2m;
                else if (toppingType.ToLower() == "veggies")
                    toppingValue = 0.8m;
                else if (toppingType.ToLower() == "cheese")
                    toppingValue = 1.1m;
                else
                    toppingValue = 0.9m;

                return 2 * toppingValue * weigh;
            }
        }
    }
}
