using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] engineDiscription = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (engineDiscription.Length)
                {
                    case 2:
                        engines.Add(new Engine(engineDiscription[0], int.Parse(engineDiscription[1])));
                        break;
                    case 3:
                        if(int.TryParse(engineDiscription[2], out int a))
                            engines.Add(new Engine(engineDiscription[0], int.Parse(engineDiscription[1]), 
                                int.Parse(engineDiscription[2])));
                        else
                            engines.Add(new Engine(engineDiscription[0], int.Parse(engineDiscription[1]),
                                engineDiscription[2]));
                        break;
                    case 4:
                        engines.Add(new Engine(engineDiscription[0], int.Parse(engineDiscription[1]),
                            int.Parse(engineDiscription[2]), engineDiscription[3]));
                        break;
                }
            }


            int m = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] carDiscription = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = engines.Find(e => e.Model == carDiscription[1]);

                switch (carDiscription.Length)
                {

                    case 2:
                        cars.Add(new Car(carDiscription[0], engine));
                        break;
                    case 3:
                        if(int.TryParse(carDiscription[2], out int a))
                            cars.Add(new Car(carDiscription[0], engine, int.Parse(carDiscription[2])));
                        else
                            cars.Add(new Car(carDiscription[0], engine, carDiscription[2]));
                        break;
                    case 4:
                        cars.Add(new Car(carDiscription[0], engine, int.Parse(carDiscription[2]), carDiscription[3]));
                        break;
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($@"{car.Model}:
  { car.Engine.Model}:
    Power: { car.Engine.Power}
    Displacement: { (car.Engine.Displacement.ToString() != "0" ? car.Engine.Displacement.ToString() : "n/a")}
    Efficiency: { (car.Engine.Efficiency != null ? car.Engine.Efficiency : "n/a")}
    Weight: { (car.Weight.ToString() != "0" ? car.Weight.ToString() : "n/a")}
    Color: { (car.Color != null ? car.Color : "n/a")}");
            }
        }
    }
}
