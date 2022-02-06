using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine().Split();
                people.Add(new Person(person[0], int.Parse(person[1])));
            }

            people = people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();

            foreach (var p in people)
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }
        }
    }
}
