using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CollectionHierarchy
{
    public class MyList<T> : IAddable<T>, IRemovable<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int Used => Items.Count;

        public int Add(T item)
        {
            Items.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            var item = Items[0];
            Items.Remove(item);

            return item;
        }
    }
}
