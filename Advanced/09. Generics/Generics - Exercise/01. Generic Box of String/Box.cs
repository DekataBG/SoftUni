using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Generic_Box_of_String
{
    public class Box<T>
    {
<<<<<<< HEAD
        private T value;

        public Box(T value)
        {
            this.value = value;
=======
        private List<T> values;

        public Box()
        {
            values = new List<T>();
        }
        public void Add(T item)
        {
            values.Add(item);
>>>>>>> 3a7e7de65173b2e497fa9c76a2f3d311452c0991
        }

        public override string ToString()
        {
<<<<<<< HEAD
            return $"{value.GetType().FullName}: {value}";
=======
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in values)
                stringBuilder.AppendLine($"{typeof(T)}: {item}");

            return stringBuilder.ToString().TrimEnd();
>>>>>>> 3a7e7de65173b2e497fa9c76a2f3d311452c0991
        }
    }
}
