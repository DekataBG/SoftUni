using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.Telephony
{
    public class Smartphone : IBrowsing, ICalling
    {
        public void Browse(string website)
        {
            if(website.Any(char.IsDigit))
                Console.WriteLine("Invalid URL!");
            else
                Console.WriteLine($"Browsing: {website}!");
        }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
