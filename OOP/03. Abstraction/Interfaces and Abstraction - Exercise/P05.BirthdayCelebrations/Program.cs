using System;
using System.Collections.Generic;

namespace P05.BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            var peopleAndPets = new List<IBorn>();

            var command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                if (command[0] == "Citizen")
                    peopleAndPets.Add(new Citizen(command[1], int.Parse(command[2]), command[3], command[4]));
                else if (command[0] == "Pet")
                    peopleAndPets.Add(new Pet(command[1], command[2]));

                command = Console.ReadLine().Split();
            }

            var number = Console.ReadLine();
            var birthDates = new List<string>();

            foreach (var entity in peopleAndPets)
                if (CheckBirthDat(entity.BirthDate, number))
                    birthDates.Add(entity.BirthDate);

            birthDates.ForEach(bd => Console.WriteLine(bd));
        }

        static bool CheckBirthDat(string birthDate, string number)
            => birthDate.Substring(birthDate.Length - number.Length) == number;
    }
}
