using P07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps 
        {
            get => corps;
            set
            {
                if (value == "Airforces" || value == "Marines")
                    corps = value;
                else
                    corps = null;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCorps: {Corps}";
        }
    }
}
