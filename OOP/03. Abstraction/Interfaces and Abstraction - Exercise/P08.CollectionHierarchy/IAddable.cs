using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CollectionHierarchy
{
    public interface IAddable<T>
    {
        List<T> Items { get; set; }
        int Add(T item);
    }
}
