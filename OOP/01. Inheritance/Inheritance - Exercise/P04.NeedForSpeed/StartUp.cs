namespace NeedForSpeed
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Vehicle vehicle = new Vehicle(15, 200);
            //SportCar vehicle = new SportCar(15, 200);
            //Car vehicle = new Car(15, 200);
            FamilyCar vehicle = new FamilyCar(15, 200);


            vehicle.Drive(15);

            Console.WriteLine(vehicle.Fuel);
        }
    }
}
