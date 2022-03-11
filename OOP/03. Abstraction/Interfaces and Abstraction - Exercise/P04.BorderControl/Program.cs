using System;
using System.Collections.Generic;

namespace P04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            var peopleAndRobots = new List<IIdentifiable>();

            var command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                if(command.Length == 2)
                    peopleAndRobots.Add(new Robot(command[0], command[1]));
                else
                    peopleAndRobots.Add(new Citizen(command[0], int.Parse(command[1]), command[2]));


                command = Console.ReadLine().Split();
            }

            var number = Console.ReadLine();

            foreach (var entity in peopleAndRobots)
                if(CheckId(entity.Id, number))
                    Console.WriteLine(entity.Id);

        }

        static bool CheckId(string id, string number)
            => id.Substring(id.Length - number.Length) == number;
    }
}
