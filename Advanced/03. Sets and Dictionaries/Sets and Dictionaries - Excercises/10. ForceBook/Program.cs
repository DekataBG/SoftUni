using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var userSide = new Dictionary<string, string>();
            string command = Console.ReadLine();

            while (command != "Lumpawaroo")
            {
                //{forceSide} | {forceUser}
                if (command.Contains('|'))
                {
                    string[] subCommand = command.Split(" | ");

                    if (!userSide.ContainsKey(subCommand[1]))
                        userSide.Add(subCommand[1], subCommand[0]);
                }
                //{forceUser} -> {forceSide}
                else if (command.Contains('>'))
                {
                    string[] subCommand = command.Split(" -> ");

                    if (userSide.ContainsKey(subCommand[0]))
                        userSide.Remove(subCommand[0]);

                    userSide.Add(subCommand[0], subCommand[1]);
                    Console.WriteLine($"{subCommand[0]} joins the {subCommand[1]} side!");

                }

                command = Console.ReadLine();
            }

            var sides = new Dictionary<string, SortedSet<string>>();
            foreach (var user in userSide.Keys)
            {
                if(sides.ContainsKey(userSide[user]))
                    sides[userSide[user]].Add(user);

                else
                    sides.Add(userSide[user], new SortedSet<string>{ user });
            }

            sides = sides.OrderByDescending(s => s.Value.Count()).ThenBy(s => s.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var side in sides)
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var user in side.Value)
                    Console.WriteLine($"! {user} ");
            }
        }
    }
}
