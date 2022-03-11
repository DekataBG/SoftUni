using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        List<Private> Privates { get; set; }
    }
}
