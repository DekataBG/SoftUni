using System;
using System.Globalization;
using System.Threading;

namespace P01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            var command1 = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(command1[1]), double.Parse(command1[2]));
            var command2 = Console.ReadLine().Split();
            Vehicle truck = new Truck(double.Parse(command2[1]), double.Parse(command2[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();

                if(command[0] == "Drive")
                {
                    if(command[1] == "Car")
                    {
                        car.Drive(double.Parse(command[2]));
                    }
                    else
                    {
                        truck.Drive(double.Parse(command[2]));
                    }
                }
                else
                {
                    if (command[1] == "Car")
                    {
                        car.Refuel(double.Parse(command[2]));
                    }
                    else
                    {
                        truck.Refuel(double.Parse(command[2]));
                    }
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
