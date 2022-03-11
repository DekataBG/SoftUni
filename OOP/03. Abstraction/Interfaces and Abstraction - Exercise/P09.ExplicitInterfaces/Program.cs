using System;
using System.Collections.Generic;

namespace P09.ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            var citizens = new List<Citizen>();

            string[] command;

            while ((command = Console.ReadLine().Split())[0] != "End")
                citizens.Add(new Citizen(command[0], command[1], int.Parse(command[2])));

            foreach (var citizen in citizens)
            {
                IPerson person = citizen;
                Console.WriteLine(person.GetName());

                IResident resident = citizen;
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
