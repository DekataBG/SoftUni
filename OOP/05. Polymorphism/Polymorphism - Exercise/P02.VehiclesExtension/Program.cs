using System;
using System.Globalization;
using System.Threading;

namespace P02.VehiclesExtension
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            var command1 = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(command1[1]), double.Parse(command1[2]), double.Parse(command1[3]));
            var command2 = Console.ReadLine().Split();
            Vehicle truck = new Truck(double.Parse(command2[1]), double.Parse(command2[2]), double.Parse(command2[3]));
            var command3 = Console.ReadLine().Split();
            Vehicle bus = new Bus(double.Parse(command3[1]), double.Parse(command3[2]), double.Parse(command3[3]));


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "Drive")
                {
                    if (command[1] == "Car")
                    {
                        car.Drive(double.Parse(command[2]));
                    }
                    else if(command[1] == "Truck")
                    {
                        truck.Drive(double.Parse(command[2]));
                    }
                    else
                    {
                        bus.Drive(double.Parse(command[2]));
                    }
                }
                else if(command[0] == "Refuel")
                {
                    if (command[1] == "Car")
                    {
                        car.Refuel(double.Parse(command[2]));
                    }
                    else if(command[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(command[2]));
                    }
                    else
                    {
                        bus.Refuel(double.Parse(command[2]));
                    }
                }
                else
                {
                    (bus as Bus).DriveEmpty(double.Parse(command[2]));
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
