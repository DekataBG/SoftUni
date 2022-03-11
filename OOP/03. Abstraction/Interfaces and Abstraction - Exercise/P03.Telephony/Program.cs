using System;
using System.Linq;

namespace P03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();
            var websites = Console.ReadLine().Split();

            var smartPhone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                if (!number.All(char.IsDigit))
                    Console.WriteLine("Invalid number!");
                else if (number.Length == 10)
                    smartPhone.Call(number);
                else
                    stationaryPhone.Call(number);
            }

            foreach (var website in websites)
            {
                smartPhone.Browse(website);
            }
        }
    }
}
