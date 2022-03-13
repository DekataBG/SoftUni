using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public abstract class Shape : IShape
    {
        public string ShapeInfo()
        {
            return $"I'm {GetType().Name}";
        }
    }
}
