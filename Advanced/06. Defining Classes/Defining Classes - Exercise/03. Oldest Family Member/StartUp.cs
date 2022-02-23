using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine().Split();
                family.AddMember(new Person(person[0], int.Parse(person[1])));
            }

            Console.WriteLine(family.GetOldestMember().Name + " " + family.GetOldestMember().Age);
        }
    }
}