using System;

namespace P01.ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var box = new Box(length, width, height);
            var area = box.SurfaceArea();
            var lateralArea = box.LateralSurfaceArea();
            var volume = box.Volume();

            if (area > 0 || lateralArea > 0 || volume > 0)
            {
                Console.WriteLine("Surface Area - {0:f2}", area);
                Console.WriteLine("Lateral Surface Area - {0:f2}", lateralArea);
                Console.WriteLine("Volume - {0:f2}", volume);
            }
        }
    }
}
