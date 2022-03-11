using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle()
        {

        }

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity, double additionalFuelConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm + additionalFuelConsumption;
        }

        public double FuelQuantity 
        {
            get => fuelQuantity;
            set
            {
                if(value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumptionPerKm { get; set; }
        public double TankCapacity { get; set; }

        public virtual void Drive(double distance)
        {
            if (FuelQuantity >= FuelConsumptionPerKm * distance)
            {
                FuelQuantity -= FuelConsumptionPerKm * distance;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel > 0)
            {
                if (TankCapacity >= FuelQuantity + fuel)
                {
                    FuelQuantity += fuel;
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

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
