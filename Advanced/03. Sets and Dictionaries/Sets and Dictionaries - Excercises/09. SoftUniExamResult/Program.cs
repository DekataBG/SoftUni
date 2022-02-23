using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUniExamResult
{
    class Program
    {
        static void Main(string[] args)
        {
            var userPoints = new Dictionary<string, Dictionary<string, int>>();
            var language = new Dictionary<string, int>();
            var banned = new HashSet<string>();

            string[] command = Console.ReadLine().Split('-');

            while (command[0] != "exam finished")
            {
                
                if (command[1] != "banned")
                {
                    string name = command[0];
                    string lang = command[1];
                    int pts = int.Parse(command[2]);

                    if (language.ContainsKey(lang))
                        language[lang]++;
                    else
                        language.Add(lang, 1);

                    if(userPoints.ContainsKey(name))
                    {
                        if (userPoints[name].ContainsKey(lang))
                        {
                            if (userPoints[name][lang] < pts)
                                userPoints[name][lang] = pts;
                        }
                        else
                        {
                            var newDict = new Dictionary<string, int>();
                            newDict.Add(lang, pts);
                            userPoints[name] = newDict;
                        }
                    }
                    else
                    {
                        var newDict = new Dictionary<string, int>();
                        newDict.Add(lang, pts);
                        userPoints.Add(name, newDict);
                    }
                }
                else
                {
                    banned.Add(command[0]);
                }    

                command = Console.ReadLine().Split('-');
            }

            var points = new Dictionary<string, int>();
            foreach (var user in userPoints.Keys)
            {
                int pts = 0;
                foreach (var lang in userPoints[user].Keys)
                    pts += userPoints[user][lang];

                points.Add(user, pts);

            }

            foreach (var person in banned)
                if (points.ContainsKey(person))
                    points.Remove(person);

            points = points.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            language = language.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine("Results: ");
            foreach (var person in points)
                Console.WriteLine($"{person.Key} | {person.Value} ");

            Console.WriteLine("Submissions: ");
            foreach (var lang in language)
                Console.WriteLine($"{lang.Key} - {lang.Value} ");


        }
    }
}
