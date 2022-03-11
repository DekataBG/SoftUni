using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm + 1.6;
        }

        public override void Drive(double distance)
        {
            if (FuelQuantity >= FuelConsumptionPerKm * distance)
            {
                FuelQuantity -= FuelConsumptionPerKm * distance;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double fuel)
        {
            FuelQuantity += fuel * 95 / 100;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
