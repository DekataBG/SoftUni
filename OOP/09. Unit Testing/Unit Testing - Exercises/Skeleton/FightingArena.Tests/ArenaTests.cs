namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void ConstructorShouldInitializeProperly()
        {
            var arena = new Arena();

            Assert.IsNotNull(arena.Warriors, "Warriors list is null.");
            Assert.AreEqual(arena.Warriors.Count, arena.Count, "List count and count do not match.");
            Assert.AreEqual(0, arena.Count, "Count does not match.");
        }


        [Test]
        public void EnrollAlreadyEnrolledStudentThrowsException()
        {
            var arena = new Arena();
            var warrior1 = new Warrior("name", 10, 40);
            var warrior2 = new Warrior("name", 30, 70);

            arena.Enroll(warrior1);

            Assert.That(() => arena.Enroll(warrior2), Throws.InvalidOperationException);
        }

        [TestCase("warrior")]
        [TestCase("Name")]
        public void EnrollWarriorWorks(string name)
        {
            var arena = new Arena();
            arena.Enroll(new Warrior(name, 10, 90));

            Assert.That(arena.Warriors.ToList()[0].Name, Is.EqualTo(name));
        }

        [TestCaseSource("NotEnrolledFighters")]
        public void NotEnrolledWarriorCannotFight(string enrolledAttacker, string enrolledDefender,
            string attacker, string defender)
        {
            var arena = new Arena();
            var attackerWarrior = new Warrior(enrolledAttacker, 10, 40);
            var defenderWarrior = new Warrior(enrolledDefender, 10, 40);

            arena.Enroll(attackerWarrior);
            arena.Enroll(defenderWarrior);

            Assert.That(() => arena.Fight(attacker, defender), Throws.InvalidOperationException);
        }

        [Test]
        public void EnrolledWarriorsCanFight()
        {
            var arena = new Arena();
            var attackerWarrior = new Warrior("warrior1", 10, 40);
            var defenderWarrior = new Warrior("warrior2", 10, 50);

            arena.Enroll(attackerWarrior);
            arena.Enroll(defenderWarrior);

            arena.Fight("warrior1", "warrior2");

            Assert.That(attackerWarrior.HP, Is.EqualTo(30));
            Assert.That(defenderWarrior.HP, Is.EqualTo(40));
        }

        public static IEnumerable<TestCaseData> NotEnrolledFighters()
        {
            var fighters = new TestCaseData[]
            {
                new TestCaseData("attacker1", "defender1", "attacker2", "defender1"),
                new TestCaseData("attacker1", "defender1", "attacker1", "defender2"),
                new TestCaseData("attacker1", "defender1", "attacker2", "defender2")
            };

            foreach (var item in fighters)
            {
                yield return item;
            }
        }
    }
}
