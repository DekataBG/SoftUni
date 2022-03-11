using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity, 1.4)
        {
            
        }

        public void DriveEmpty(double distance)
        {
            if (FuelQuantity >= (FuelConsumptionPerKm - 1.4) * distance)
            {
                FuelQuantity -= (FuelConsumptionPerKm - 1.4) * distance;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

    }
}
