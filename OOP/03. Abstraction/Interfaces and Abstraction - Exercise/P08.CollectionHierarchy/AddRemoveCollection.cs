using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CollectionHierarchy
{
    public class AddRemoveCollection<T> : IAddable<T>, IRemovable<T>
    {
        public List<T> Items { get; set; } = new List<T>();

        public int Add(T item)
        {
            Items.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            var item = Items[Items.Count - 1];
            Items.RemoveAt(Items.Count - 1);

            return item;
        }
    }
}
