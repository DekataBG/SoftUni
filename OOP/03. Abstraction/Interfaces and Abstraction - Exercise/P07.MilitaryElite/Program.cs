using P07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace P07.MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");


            var soldiers = new List<ISoldier>();

            var command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                var id = command[1];
                var firstName = command[2];
                var lastName = command[3];
                var salary = decimal.Parse(command[4]);

                switch (command[0])
                {
                    case "Private":
                        soldiers.Add(new Private(id, firstName, lastName, salary));
                        break;
                    case "LieutenantGeneral":
                        var newLieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                        for (int i = 5; i < command.Length; i++)
                            newLieutenantGeneral.Privates.Add(
                                (Private)soldiers.Where(s => s.Id == command[i]).FirstOrDefault());

                        soldiers.Add(newLieutenantGeneral);
                        break;
                    case "Engineer":
                        var eCorps = command[5];

                        var newEngineer = new Engineer(id, firstName, lastName, salary, eCorps);
                        if (newEngineer.Corps != null)
                        {
                            for (int i = 6; i < command.Length; i += 2)
                                newEngineer.Repairs.Add(new Repair(command[i], int.Parse(command[i + 1])));

                            soldiers.Add(newEngineer);
                        }
                        break;
                    case "Commando":
                        var cCorps = command[5];

                        var newCommando = new Commando(id, firstName, lastName, salary, cCorps);
                        if (newCommando.Corps != null)
                        {
                            for (int i = 6; i < command.Length; i += 2)
                            {
                                var mCodeName = command[i];
                                var mState = command[i + 1];

                                var newMission = new Mission(mCodeName, mState);
                                if(newMission.State != null)
                                    newCommando.Missions.Add(new Mission(mCodeName, mState));
                            }

                            soldiers.Add(newCommando);
                        }
                        break;
                    case "Spy":
                        var sNumber = int.Parse(command[4]);

                        soldiers.Add(new Spy(id, firstName, lastName, sNumber));
                        break;
                }

                command = Console.ReadLine().Split();
            }

            foreach (var soldier in soldiers)
                Console.WriteLine(soldier.ToString());
        }

    }
}
