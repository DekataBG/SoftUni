using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Contracts
{
    public interface IMission
    {
        string Name { get; set; }
        string State { get; set; }
    }
}
