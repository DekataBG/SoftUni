using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        List<Mission> Missions { get; set; }
    }
}
