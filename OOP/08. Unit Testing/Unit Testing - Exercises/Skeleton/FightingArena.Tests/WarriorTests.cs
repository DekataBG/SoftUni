namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class WarriorTests
    {
        [TestCase("warrior", 50, 100)]
        [TestCase("  wr", 30, 100)]
        [TestCase("warrior", 30, 0)]
        public void ConstructorWithValidDataWorks(string name, int dmg, int hp)
        {
            var warrior = new Warrior(name, dmg, hp);

            Assert.That(warrior.Name, Is.EqualTo(name));
            Assert.That(warrior.Damage, Is.EqualTo(dmg));
            Assert.That(warrior.HP, Is.EqualTo(hp));
        }

        [TestCaseSource("InvalidConstructorData")]
        public void ConstructorWithInvalidDataThrowsException(string name, int dmg, int hp)
        {
            Assert.That(() => new Warrior(name, dmg, hp), Throws.ArgumentException);
        }
       
        [TestCaseSource("CannotAttackCases")]
        public void CannotAttackTestCases(int attackingHP, int attackedHP, int attackedDmg)
        {
            var attackingWarrior = new Warrior("attacking", 40, attackingHP);
            var attackedWarrior = new Warrior("attacked", attackedDmg, attackedHP);

            Assert.That(() => attackingWarrior.Attack(attackedWarrior), Throws.InvalidOperationException);
        }

        [TestCase(60, 20)]
        [TestCase(40, 40)]
        public void AttackingHPReducesWhenAttacking(int attackingHP, int attackedDmg)
        {
            var attackingWarrior = new Warrior("attacking", 40, attackingHP);
            var attackedWarrior = new Warrior("attacked", attackedDmg, 40);

            attackingWarrior.Attack(attackedWarrior);

            Assert.That(attackingWarrior.HP, Is.EqualTo(attackingHP - attackedDmg));
        }

        [TestCase(40, 80)]
        [TestCase(45, 95)]
        [TestCase(55, 55)]
        public void AttackedHPReducesWhenAttackedAndNotKilled(int attackingDmg, int attackedHP)
        {
            var attackingWarrior = new Warrior("attacking", attackingDmg, 50);
            var attackedWarrior = new Warrior("attacked", 31, attackedHP);

            attackingWarrior.Attack(attackedWarrior);

            Assert.That(attackedWarrior.HP, Is.EqualTo(attackedHP - attackingDmg));
        }

        [TestCase(90, 80)]
        [TestCase(105, 95)]
        public void AttackedHPIs0WhenAttackedAndKilled(int attackingDmg, int attackedHP)
        {
            var attackingWarrior = new Warrior("attacking", attackingDmg, 50);
            var attackedWarrior = new Warrior("attacked", 31, attackedHP);

            attackingWarrior.Attack(attackedWarrior);

            Assert.That(attackedWarrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void NameGetterShouldWork()
        {
            var warrior = new Warrior("warrior", 10, 20);

            Assert.That(warrior.Name, Is.EqualTo("warrior"));
        }

        [Test]
        public void DamageGetterShouldWork()
        {
            var warrior = new Warrior("warrior", 10, 20);

            Assert.That(warrior.Damage, Is.EqualTo(10));
        }

        [Test]
        public void HPGetterShouldWork()
        {
            var warrior = new Warrior("warrior", 10, 20);

            Assert.That(warrior.HP, Is.EqualTo(20));
        }

        public static IEnumerable<TestCaseData> InvalidConstructorData()
        {
            var data = new TestCaseData[]
            {
                new TestCaseData(null, 50, 100),
                new TestCaseData("", 50, 100),
                new TestCaseData("    ", 50, 100),
                new TestCaseData("warrior", 0, 100),
                new TestCaseData("warrior", -10, 100),
                new TestCaseData("warrior", 10, -100),
            };

            foreach (var item in data)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> CannotAttackCases()
        {
            var data = new TestCaseData[]
            {
                new TestCaseData(20, 50, 100),
                new TestCaseData(30, 50, 100),
                new TestCaseData(0, 50, 100),
                new TestCaseData(50, 20, 100),
                new TestCaseData(50, 30, 100),
                new TestCaseData(0, 30, 100),
                new TestCaseData(50, 40, 100),
            };

            foreach (var item in data)
            {
                yield return item;
            }
        }
    }
}