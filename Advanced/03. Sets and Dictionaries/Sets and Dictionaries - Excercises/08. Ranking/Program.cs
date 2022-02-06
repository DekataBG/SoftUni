using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var users = new Dictionary<string, Dictionary<string, int>>();
            var usersPoints = new List<Tuple<string, int>>();

            var command = Console.ReadLine().Split(':');

            //add contests
            while (command[0] != "end of contests")
            {
                contests.Add(command[0], command[1]);

                command = Console.ReadLine().Split(':');
            }


            command = Console.ReadLine().Split("=>");
            while (command[0] != "end of submissions")
            {
                string constest = command[0];
                string password = command[1];
                string username = command[2];
                int points = int.Parse(command[3]);

                if (contests.ContainsKey(constest))
                {
                    if (contests[constest] == password)
                    {
                        if (users.ContainsKey(username))
                        {
                            if (users[username].ContainsKey(constest))
                            {
                                if (users[username][constest] < points)
                                    users[username][constest] = points;
                            }
                            else
                            {
                                users[username].Add(constest, points);
                            }
                        }
                        else
                        {
                            var cont = new Dictionary<string, int>();
                            cont.Add(constest, points);
                            users.Add(username, cont);
                        }
                    }
                }

                command = Console.ReadLine().Split("=>");
            }

            foreach (var user in users.Keys)
            {
                int pts = 0;
                foreach (var contest in users[user])
                    pts += contest.Value;

                usersPoints.Add(new Tuple<string, int>(user, pts));
            }
            usersPoints = usersPoints.OrderByDescending(p => p.Item2).ToList();

            Console.WriteLine($"Best candidate is {usersPoints[0].Item1} with total {usersPoints[0].Item2} points.");
            Console.WriteLine("Ranking: ");

            users = users.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            while (users.Count > 0)
            {
                foreach (var user in users)
                {
                    users[user.Key] = user.Value.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
                    Console.WriteLine(user.Key);

                    foreach (var comp in users[user.Key])
                        Console.WriteLine($"#  {comp.Key} -> {comp.Value}");

                    users.Remove(user.Key);
                    break;
                }
            }

        }
    }
}
