using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation
{
    class Program
    {
        static Func<string, string, bool> startsWith = (w, s) => { return w.StartsWith(s); };
        static Func<string, string, bool> endsWith = (w, e) => { return w.EndsWith(e); };
        static Func<string, string, bool> isShorter = (w, l) => { return w.Length <= int.Parse(l); };
        static Func<string, string, bool> contains = (w, s) => { return w.Contains(s); };

        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            string[] commands = Console.ReadLine().Split(';');

            var filters = new Dictionary<string, Func<string, string, bool>>();
            filters = ManageFilters(commands, filters);

            foreach (var pair in filters)
            {
                people.RemoveAll(x => pair.Value(x, pair.Key[pair.Key.Length - 1].ToString() ));
            }

            Console.WriteLine(String.Join(" ", people));
        }

        static Dictionary<string, Func<string, string, bool>> ManageFilters
            (string[] commands, Dictionary<string, Func<string, string, bool>> filters)
        {
            switch (commands[0])
            {
                case "Print":
                    return filters;
                case "Add filter":
                    filters = AddFilter(commands, filters);
                    break;
                case "Remove filter":
                    filters = RemoveFilter(commands, filters);
                    break;
            }

            ManageFilters(Console.ReadLine().Split(';'), filters);
            return filters;
        }

        static Dictionary<string, Func<string, string, bool>> AddFilter
            (string[] commands, Dictionary<string, Func<string, string, bool>> filters)
        {
            switch (commands[1])
            {
                case "Starts with":
                    filters.Add(commands[1] + commands[2], startsWith);
                    break;
                case "Ends with":
                    filters.Add(commands[1] + commands[2], endsWith);
                    break;
                case "Length":
                    filters.Add(commands[1] + commands[2], isShorter);
                    break;
                case "Contains":
                    filters.Add(commands[1] + commands[2], contains);
                    break;
            }

            return filters;
        }

        static Dictionary<string, Func<string, string, bool>> RemoveFilter
            (string[] commands, Dictionary<string, Func<string, string, bool>> filters)
        {
            switch (commands[1])
            {
                case "Starts with":
                    filters.Remove(commands[1] + commands[2]);
                    break;
                case "Ends with":
                    filters.Remove(commands[1] + commands[2]);
                    break;
                case "Length":
                    filters.Remove(commands[1] + commands[2]);
                    break;
                case "Contains":
                    filters.Remove(commands[1] + commands[2]);
                    break;
            }

            return filters;
        }
    }
}
