using System;
using System.Collections.Generic;

namespace P03.Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            var heroes = new List<BaseHero>();

            var n = int.Parse(Console.ReadLine());

            while(heroes.Count < n)
            {
                var name = Console.ReadLine();
                var type = Console.ReadLine();

                var hero = HeroCreator(type, name);

                if (hero != null)
                {
                    heroes.Add(hero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            var bossPower = int.Parse(Console.ReadLine());

            var sum = 0;
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                sum += hero.Power;
            }

            if(sum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        static BaseHero HeroCreator(string type, string name)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    return null;
            }
        }
    }
}
