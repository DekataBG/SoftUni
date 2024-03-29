﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> People { get; set; } = new List<Person>();
        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember()
        {
            var oldest = People[0];
            foreach (var person in People)
            {
                if (person.Age > oldest.Age)
                    oldest = person;
            }

            return oldest;
        }
    }
}
