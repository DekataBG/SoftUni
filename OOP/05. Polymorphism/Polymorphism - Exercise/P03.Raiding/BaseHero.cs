using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; set; }
        public int Power { get; set; }

        public virtual string CastAbility()
        {
            return $"{GetType().Name} - {Name} ";
        }
    }
}
