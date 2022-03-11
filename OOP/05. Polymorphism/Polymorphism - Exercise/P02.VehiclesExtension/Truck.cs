using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity, 1.6)
        {
            
        }

        public override void Refuel(double fuel)
        {
            if (fuel > 0)
            {
                if (TankCapacity >= FuelQuantity + fuel)
                {
                    FuelQuantity += fuel * 95 / 100;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }

    }
}
