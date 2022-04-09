using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void SmartphoneCtorWorksProperly()
        {
            var phone = new Smartphone("model", 100);

            Assert.AreEqual("model", phone.ModelName);
            Assert.AreEqual(100, phone.MaximumBatteryCharge);
            Assert.AreEqual(100, phone.CurrentBateryCharge);
        }

        [Test]
        public void ShopCtorWorksProperly()
        {
            var shop = new Shop(100);

            Assert.AreEqual(100, shop.Capacity);
        }

        [Test]
        public void NegativeCapacityThrowsException()
        {
            Shop shop;
            Assert.Throws<ArgumentException>(() => shop = new Shop(-100));
        }

        [Test]
        public void CountShowsCorrectCount()
        {
            var phone = new Smartphone("model", 100);
            var shop = new Shop(100);

            shop.Add(phone);

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void AddingSameModelThrowsException()
        {
            var phone = new Smartphone("model", 100);
            var shop = new Shop(100);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(phone));
        }

        [Test]
        public void AddingMoreModelsThanCapacityThrowsException()
        {
            var phone = new Smartphone("model", 100);
            var shop = new Shop(2);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(phone));
        }

        [Test]
        public void RemovingUnexistingPhoneThrowsException()
        {
            var phone = new Smartphone("model", 100);
            var shop = new Shop(2);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("anotherModel"));
        }

        [Test]
        public void RemovingPhone()
        {
            var phone = new Smartphone("model", 100);
            var shop = new Shop(2);

            shop.Add(phone);
            shop.Remove("model");

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void TestUnexistingPhoneThrowsException()
        {
            var phone = new Smartphone("model", 100);
            var shop = new Shop(2);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("anotherModel", 12));
        }

        [Test]
        public void TestLowBatteryPhoneThrowsException()
        {
            var phone = new Smartphone("model", 40);
            var shop = new Shop(2);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("model", 50));
        }

        [Test]
        public void TestPhone()
        {
            var phone = new Smartphone("model", 40);
            var shop = new Shop(2);

            shop.Add(phone);
            shop.TestPhone("model", 30);

            Assert.AreEqual(10, phone.CurrentBateryCharge);
        }

        [Test]
        public void ChargeUnexistingPhoneThrowsException()
        {
            var phone = new Smartphone("model", 40);
            var shop = new Shop(2);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("anothermodel"));
        }

        [Test]
        public void ChargePhone()
        {
            var phone = new Smartphone("model", 40);
            var shop = new Shop(2);

            shop.Add(phone);
            shop.TestPhone("model", 10);
            shop.ChargePhone("model");

            Assert.AreEqual(40, phone.CurrentBateryCharge);
            Assert.AreEqual(phone.MaximumBatteryCharge, phone.CurrentBateryCharge);
        }
    }
}