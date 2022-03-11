using P07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite
{
    public class Mission : IMission
    {
        private string state;

        public Mission(string name, string state)
        {
            Name = name;
            State = state;
        }

        public string Name { get; set; }
        public string State 
        {
            get => state;
            set
            {
                if (value == "inProgress" || value == "Finished")
                    state = value;
                else
                    state = null;
            }
        }

        public override string ToString()
        {
            return $"  Code Name: {Name} State: {State}";
        }
    }
}
