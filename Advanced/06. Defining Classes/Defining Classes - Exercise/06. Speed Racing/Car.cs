using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; } = 0;
        public bool CanMove(double distance)
        {
            return FuelAmount >= distance * FuelConsumptionPerKilometer;
        }
    }
}
