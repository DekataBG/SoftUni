using P07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = new List<Repair>();
        }

        public List<Repair> Repairs { get; set; }

        public override string ToString()
        {
            var output = base.ToString();
            output += "\nRepairs:";

            foreach (var item in Repairs)
                output += $"\n{item.ToString()}";

            return output.TrimEnd();
        }
    }
}
