using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | 
                    BindingFlags.NonPublic | BindingFlags.Static);

                foreach (var method in methods)
                {
                    var attribute = method.GetCustomAttribute<AuthorAttribute>();

                    if (attribute != null)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}.");
                    }
                }
            }
        }
    }
}
