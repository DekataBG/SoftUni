using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHeadIfAttacked()
        {
            var axe = new Axe(10, 10);
            var dummy = new Dummy(20, 100);

            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(10));

        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            var axe = new Axe(10, 10);
            var dummy = new Dummy(0, 100);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            var axe = new Axe(20, 10);
            var dummy = new Dummy(20, 100);

            axe.Attack(dummy);

            Assert.That(dummy.GiveExperience() > 0);
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            var axe = new Axe(20, 10);
            var dummy = new Dummy(20, 100);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}