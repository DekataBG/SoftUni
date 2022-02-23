using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new HashSet<string>();
            var followers = new Dictionary<string, int>();
            var followed = new Dictionary<string, int>();

            //follower -> followed 
            var relations = new HashSet<Tuple<string, string>>();

            //adding the vloggers to the log
            string[] command = Console.ReadLine().Split();
            while (command[0] != "Statistics")
            {

                switch (command[1])
                {
                    case "joined":
                        string name = command[0];

                        if (!vloggers.Contains(name))
                        {
                            vloggers.Add(name);
                            followers.Add(name, 0);
                            followed.Add(name, 0);
                        }

                        break;
                    case "followed":
                        string name1 = command[0];
                        string name2 = command[2];

                        if (vloggers.Contains(name1) && vloggers.Contains(name2) && name1 != name2 &&
                            !relations.Contains(new Tuple<string, string>(name1, name2)))
                        {
                            followers[name2]++;
                            followed[name1]++;
                            relations.Add(new Tuple<string, string>(name1, name2));
                        }

                        break;
                }

                command = Console.ReadLine().Split();
            }
            var allVloggers = vloggers.OrderByDescending(v => followers[v]).ThenBy(v => followed[v]).ToList();
            var firstRelations = relations.Where(r => r.Item2 == allVloggers[0]).ToList();
           
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            Console.WriteLine($"1. {allVloggers[0]} : {followers[allVloggers[0]]} followers," +
                $" {followed[allVloggers[0]]} following");
            foreach (var item in firstRelations.OrderBy(l => l.Item1))
                Console.WriteLine($"*  {item.Item1}");

            for (int i = 1; i < allVloggers.Count; i++)
            {
                Console.WriteLine($"{i+1}. {allVloggers[i]} : {followers[allVloggers[i]]} followers," +
                    $" {followed[allVloggers[i]]} following");
            }

        }

    }
}
