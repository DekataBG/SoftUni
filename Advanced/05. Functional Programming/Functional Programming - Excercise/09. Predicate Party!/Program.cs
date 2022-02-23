using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    class Program
    {
        static Func<string, string, bool> startsWith = (w, s) => { return w.Substring(0, s.Length) == s; };
        static Func<string, string, bool> endsWith = (w, e) => { return w.Substring(w.Length - e.Length) == e; };
        static Func<string, int, bool> hasLength = (w, l) => { return w.Length == l; };
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            string[] command = Console.ReadLine().Split();

            people = Manager(command, people);

            if (people.Count > 0)
                Console.WriteLine(String.Join(", ", people) +
                " are going to the party!");
            else
                Console.WriteLine("Nobody is going to the party!");
        }

        static List<string> Manager(string[] command, List<string> guests)
        {
            if (command[0] == "Party!")
            {
                return guests;
            }

            else if (command[0] == "Remove")
            {
                switch (command[1])
                {
                    case "StartsWith":
                        guests.RemoveAll(g => startsWith(g, command[2]));
                        break;
                    case "EndsWith":
                        guests.RemoveAll(g => endsWith(g, command[2]));
                        break;
                    case "Length":
                        guests.RemoveAll(g => hasLength(g, int.Parse(command[2])));
                        break;
                }
            }

            else
            {
                List<string> namesToDouble = new List<string>();
                switch (command[1])
                {
                    case "StartsWith":
                        namesToDouble = guests.FindAll(g => startsWith(g, command[2]));
                        guests = DoubledList(guests, namesToDouble);
                        break;
                    case "EndsWith":
                        namesToDouble = guests.FindAll(g => endsWith(g, command[2]));
                        guests = DoubledList(guests, namesToDouble);
                        break;
                    case "Length":
                        namesToDouble = guests.FindAll(g => hasLength(g, int.Parse(command[2])));
                        guests = DoubledList(guests, namesToDouble);
                        break;
                }
            }

            Manager(Console.ReadLine().Split(), guests);
            return guests;
        }
        static List<string> DoubledList(List<string> guests, List<string> namesToDouble)
        {
            foreach (var name in namesToDouble)
            {
                guests.Insert(guests.IndexOf(name), name);
            }

            return guests;
        }

    }
}