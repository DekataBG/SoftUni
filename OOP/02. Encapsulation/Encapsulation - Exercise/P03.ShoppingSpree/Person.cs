using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");

                name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return money;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");

                money = value;
            }
        }
        public List<Product> Products { get; set; }
    }
}
