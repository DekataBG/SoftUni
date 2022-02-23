using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Generic_Box_of_String
{
    public class Box<T>
    {
        private List<T> values;

        public Box()
        {
            values = new List<T>();
        }
        public void Add(T item)
        {
            values.Add(item);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in values)
                stringBuilder.AppendLine($"{typeof(T)}: {item}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
