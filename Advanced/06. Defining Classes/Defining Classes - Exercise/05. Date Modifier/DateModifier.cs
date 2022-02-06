using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public DateModifier(string date1, string date2)
        {
            Date1 = date1;
            Date2 = date2;
        }

        public string Date1 { get; }
        public string Date2 { get; }

        public int Difference()
        {
            DateTime dateTime1 = DateTime.Parse(Date1);
            DateTime dateTime2 = DateTime.Parse(Date2);

            return (int)Math.Abs((dateTime1.Date - dateTime2.Date).TotalDays);
        }
    }
}
