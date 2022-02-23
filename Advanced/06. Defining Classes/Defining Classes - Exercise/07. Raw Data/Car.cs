using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType,
            decimal tire1Pressure, int tire1Age, decimal tire2Pressure, int tire2Age,
            decimal tire3Pressure, int tire3Age, decimal tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine.Speed = engineSpeed;
            Engine.Power = enginePower;
            Cargo.Weight = cargoWeight;
            Cargo.Type = cargoType;
            Tyres.Add(new Tyre(tire1Pressure, tire1Age));
            Tyres.Add(new Tyre(tire2Pressure, tire2Age));
            Tyres.Add(new Tyre(tire3Pressure, tire3Age));
            Tyres.Add(new Tyre(tire4Pressure, tire4Age));
        }
        public string Model { get; set; }
        public Engine Engine { get; set; } = new Engine();
        public Cargo Cargo { get; set; } = new Cargo();
        public List<Tyre> Tyres { get; set; } = new List<Tyre>(4);
    }
}
