﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Telephony
{
    public class StationaryPhone : ICalling
    {
        public void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
