using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Contracts
{
    public interface ISpy : ISoldier
    {
        int Number { get; set; }
    }
}
