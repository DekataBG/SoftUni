using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                string model = command[0];
                int engineSpeed = int.Parse(command[1]);
                int enginePower = int.Parse(command[2]);
                int cargoWeight = int.Parse(command[3]);
                string cargoType = command[4];
                decimal tire1Pressure = decimal.Parse(command[5]);
                int tire1Age = int.Parse(command[6]);
                decimal tire2Pressure = decimal.Parse(command[7]);
                int tire2Age = int.Parse(command[8]);
                decimal tire3Pressure = decimal.Parse(command[9]);
                int tire3Age = int.Parse(command[10]);
                decimal tire4Pressure = decimal.Parse(command[11]);
                int tire4Age = int.Parse(command[12]);

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age,
                     tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);

                cars.Add(car);
            }

            if (Console.ReadLine() == "fragile")
            {
                cars = cars.Where(c => c.Cargo.Type == "fragile" 
                && (c.Tyres[0].Pressure < 1 || c.Tyres[1].Pressure < 1 || c.Tyres[2].Pressure < 1 || c.Tyres[3].Pressure < 1))
                    .ToList();
            }
            else
            {
                cars = cars.Where(c => c.Cargo.Type == "flammable"
                && c.Engine.Power > 250)
                    .ToList();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
