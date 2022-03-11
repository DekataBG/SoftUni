using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.PizzaCalories
{
    public class Dough
    {
        private string flourType, bakingTechnique;
        private int weigh;

        public Dough(string flourType, string bakingTechnique, int weigh)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weigh = weigh;
        }

        public string FlourType 
        {
            get => flourType;
            set
            {
                if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                    flourType = value;
                else
                    throw new ArgumentException("Invalid type of dough.");
            }
        }
        public string BakingTechnique 
        {
            get => bakingTechnique;
            set
            {
                if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
                    bakingTechnique = value;
                else
                    throw new ArgumentException("Invalid type of dough.");
            }
        }
        public int Weigh 
        {
            get => weigh;
            set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                else
                    weigh = value;
            }
        }
        public decimal Calories 
        {
            get
            {
                decimal flourValue, bakingValue;

                if (flourType.ToLower() == "white")
                    flourValue = 1.5m;
                else
                    flourValue = 1.0m;

                if (bakingTechnique.ToLower() == "crispy")
                    bakingValue = 0.9m;
                else if (bakingTechnique.ToLower() == "chewy")
                    bakingValue = 1.1m;
                else
                    bakingValue = 1.0m;

                return 2 * Weigh * flourValue * bakingValue;
            }
        }
    }
}
