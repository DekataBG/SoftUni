using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CollectionHierarchy
{
    public interface IRemovable<T> : IAddable<T>
    {
        T Remove();
    }
}
