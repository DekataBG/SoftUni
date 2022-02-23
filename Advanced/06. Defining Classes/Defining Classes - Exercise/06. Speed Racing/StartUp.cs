using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();

                cars.Add(new Car
                {
                    Model = carInfo[0],
                    FuelAmount = double.Parse(carInfo[1]),
                    FuelConsumptionPerKilometer = double.Parse(carInfo[2]),
                });
            }

            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                Car car = cars.Find(c => c.Model == command[1]);

                if (car.CanMove(double.Parse(command[2])))
                {
                    car.FuelAmount -= double.Parse(command[2]) * car.FuelConsumptionPerKilometer;
                    car.TravelledDistance += double.Parse(command[2]);
                }
                else
                    Console.WriteLine("Insufficient fuel for the drive");

                command = Console.ReadLine().Split();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
