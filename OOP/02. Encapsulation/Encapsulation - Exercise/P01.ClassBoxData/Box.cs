using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.ClassBoxData
{
    public class Box
    {
        private double length, width, height;
        private bool valid = true;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    valid = false;
                }
                else
                    this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    valid = false;
                }
                else
                    this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                    valid = false;
                }
                else
                    this.height = value;
            }
        }

        public double SurfaceArea()
        {
            if (valid)
                return 2 * height * (length + width) + 2 * length * width;
            else
                return 0;
        }

        public double LateralSurfaceArea()
        {
            if (valid)
                return 2 * height * (width + length);
            else
                return 0;
        }

        public double Volume()
        {
            if (valid)
                return length * width * height;
            else
                return 0;
        }
    }
}
