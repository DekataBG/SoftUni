using P07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; set; }

        public override string ToString()
        {
            var output = base.ToString() + "\nMissions:";

            foreach (var item in Missions)
                output += $"\n{item.ToString()}";

            return output.TrimEnd();
        }
    }
}
