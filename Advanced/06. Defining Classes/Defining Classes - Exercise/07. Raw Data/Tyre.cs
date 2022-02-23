using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tyre
    {
        public Tyre(decimal pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }
        public int Age { get; set; }
        public decimal Pressure { get; set; }
    }
}
