﻿using Formula1.Models.Contracts;
using Formula1.Models.Races;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    //internal instead of public and race instead of irace
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => models.AsReadOnly();

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IRace FindByName(string name)
        {
            return models.FirstOrDefault(m => m.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return models.Remove(model);
        }
    }
}
