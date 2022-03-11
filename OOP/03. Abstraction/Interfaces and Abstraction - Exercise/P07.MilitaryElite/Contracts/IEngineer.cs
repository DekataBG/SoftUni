using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        List<Repair> Repairs { get; set; }
    }
}
