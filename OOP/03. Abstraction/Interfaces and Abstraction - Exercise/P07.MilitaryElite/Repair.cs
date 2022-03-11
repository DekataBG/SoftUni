using P07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite
{
    public class Repair : IRepair
    {
        public Repair(string name, int hours)
        {
            Name = name;
            Hours = hours;
        }
        public string Name { get; set; }
        public int Hours { get; set; }

        public override string ToString()
        {
            return $"  Part Name: {Name} Hours Worked: {Hours}";
        }
    }
}
