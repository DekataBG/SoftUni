namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class CarManagerTests
    {
        [TestCase("make", "model", 14.4, 18)]
        [TestCase("aasddd", "model 14", 14.4899866, 18000)]
        [TestCase("make", "model", 10.0004, 18)]
        public void ConstructorShouldBeProperlyInitialised(string make, string model,
            double fuelConsumption, double fuelCapacity)
        {
            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            bool condition = car.Make == make || car.Model == model 
                || car.FuelConsumption == fuelConsumption || car.FuelCapacity == fuelCapacity;

            Assert.That(condition, Is.EqualTo(true));
        }

        [TestCaseSource("InvalidConstructorData")]
        public void ConstructorReceivesWrongDataAndThrowsErrors(string make, string model,
            double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void MakeGetterShouldWorkProperly()
        {
            var car = new Car("make", "model", 1, 2);

            Assert.That("make", Is.EqualTo(car.Make));
        }

        [Test]
        public void ModelGetterShouldWorkProperly()
        {
            var car = new Car("make", "model", 1, 2);

            Assert.That("model", Is.EqualTo(car.Model));
        }

        [Test]
        public void FuelConsumptionGetterShouldWorkProperly()
        {
            var car = new Car("make", "model", 1, 2);

            Assert.That(1, Is.EqualTo(car.FuelConsumption));
        }

        [Test]
        public void FuelCapacityGetterShouldWorkProperly()
        {
            var car = new Car("make", "model", 1, 2);

            Assert.That(2, Is.EqualTo(car.FuelCapacity));
        }

        [TestCase(0)]
        [TestCase(-40)]
        [TestCase(-4.6)]
        public void RefuelWithNegativeNumberThrowsException(double refuel)
        {
            var car = new Car("make", "model", 1, 2);

            Assert.That(() => car.Refuel(refuel), Throws.ArgumentException);
        }

        [TestCase(20)]
        [TestCase(1.20)]
        public void RefuelIncreasesFuelAmount(double refuel)
        {
            var car = new Car("make", "model", 1, 200);

            car.Refuel(refuel);

            Assert.That(refuel, Is.EqualTo(car.FuelAmount));
        }

        [Test]
        public void RefuelOverTheFuelCapacity()
        {
            var car = new Car("make", "model", 1, 20);

            car.Refuel(50);

            Assert.That(20, Is.EqualTo(car.FuelAmount));
        }

        [Test]
        public void DriveWithoutEnoughFuelShouldThrowException()
        {
            var car = new Car("make", "model", 1, 20);

            Assert.That(() => car.Drive(30), Throws.InvalidOperationException);
        }

        [Test]
        public void DriveWithEnoughFuelReducesFuel()
        {
            var car = new Car("make", "model", 1, 75);

            car.Refuel(50);
            car.Drive(3000);

            Assert.That(20, Is.EqualTo(car.FuelAmount));
        }

        public static IEnumerable<TestCaseData> InvalidConstructorData()
        {
            var testCases = new TestCaseData[]
            {
                new TestCaseData(null, "model", 12, 13),
                new TestCaseData("", "model", 12, 13),
                new TestCaseData("make", null, 12, 13),
                new TestCaseData("make", "", 12, 13),
                new TestCaseData("make", "model", 0, 1.3),
                new TestCaseData("make", "model", -14, 13),
                new TestCaseData("make", "model", 18.9, 0),
                new TestCaseData("make", "model", 18.9, -13)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }
    }
}
