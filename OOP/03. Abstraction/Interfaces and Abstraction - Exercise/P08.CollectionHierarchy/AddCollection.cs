using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CollectionHierarchy
{
    public class AddCollection<T> : IAddable<T>
    {
        public List<T> Items { get; set; } = new List<T>();

        public int Add(T item)
        {
            Items.Add(item);

            return Items.Count - 1;
        }
    }
}
