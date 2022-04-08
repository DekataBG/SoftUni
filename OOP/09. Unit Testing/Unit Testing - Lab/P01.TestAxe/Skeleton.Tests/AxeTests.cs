using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurability()
        {
            var axe = new Axe(10, 10);
            var dummy = new Dummy(20, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9)
                , "Axe durability doesn't change after attack.");
        }

        [Test]
        public void AttackWithBrokenWeapon()
        {
            var axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException> (() => axe.Attack(new Dummy(20, 0)));
        }
    }
}