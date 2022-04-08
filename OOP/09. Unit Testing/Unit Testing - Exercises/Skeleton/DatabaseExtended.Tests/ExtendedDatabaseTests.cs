namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("TestCasesAddInvalid")]
        public void Add_To_Database_With_Invalid_Data_Should_Throw_Exception(Person[] ctor, Person[] arrToAdd, Person toAdd)
        {
            Database db = new Database(ctor);

            foreach (Person person in arrToAdd)
            {
                db.Add(person);
            }

            Assert.That(() => db.Add(toAdd), Throws.InvalidOperationException, "Invalid data does not throw an exception.");
        }

        public static IEnumerable<TestCaseData> TestCasesAddInvalid()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Harold"),
                        new Person(2, "Jeremy"),
                        new Person(3, "Ethan"),
                        new Person(4, "Walter"),
                        new Person(5, "Peter"),
                        new Person(6, "Nathan"),
                        new Person(7, "Henry"),
                        new Person(8, "Dennis"),
                        new Person(9, "Andrej"),
                        new Person(10, "Alexander"),
                        new Person(11, "Larry"),
                        new Person(12, "Eric"),
                        new Person(13, "Garry"),
                    },
                    new Person[]
                    {
                        new Person(14, "Sarah"),
                        new Person(15, "Karen"),
                        new Person(16, "Elizabeth"),
                    },
                    new Person(17, "Steve")),
                new TestCaseData(
                    new Person[] { },
                    new Person[]
                    {
                        new Person(1, "Dennis"),
                        new Person(2, "Andrej"),
                    },
                    new Person(3, "Dennis")),
                new TestCaseData(
                    new Person[] { },
                    new Person[]
                    {
                        new Person(1, "Dennis"),
                        new Person(2, "Andrej"),
                    },
                    new Person(2, "Ethan")),
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }
        }

        [TestCaseSource("PersonsForConstructor")]
        public void AddUserRangeThroughConstructor(Person[] persons, int expectedCount)
        {
            var db = new Database(persons);

            Assert.That(db.Count, Is.EqualTo(expectedCount));
        }

        public static IEnumerable<TestCaseData> PersonsForConstructor()
        {
            yield return new TestCaseData(
                new Person[]
                {
                    new Person(1, "person1"),
                    new Person(2, "person2"),
                    new Person(3, "person3"),
                    new Person(4, "person4"),
                },
                4);

            yield return new TestCaseData(
            new Person[] { },
            0);
        }


        [TestCase(0, "go6o", 2, 3)]
        [TestCase(0, "Max", 0, 1)]
        [TestCase(0, "Steve", 15, 16)]
        public void AddUser(int id, string username, int morePeople, int expectedPeople)
        {
            var db = new Database();

            db.Add(new Person(id, username));

            for (int i = 1; i <= morePeople; i++)
            {
                db.Add(new Person(i, $"Person{i}"));
            }

            Assert.That(db.Count, Is.EqualTo(expectedPeople));
        }

        [Test]
        public void AddMoreThan16Users()
        {
            Database db = new Database();
            for (int i = 0; i < 16; i++)
            {
                db.Add(new Person(i, $"Person{i}"));
            }

            Assert.Throws<InvalidOperationException>(
                () => db.Add(new Person(69, "asl")));
        }

        [TestCase(1, "go6o")]
        [TestCase(2, "Max")]
        [TestCase(3, "Steve")]
        public void AddUserWithSameUsername(int id, string username)
        {
            var db = new Database();

            db.Add(new Person(id, username));

            Assert.Throws<InvalidOperationException>(
                () => db.Add(new Person(id + 1, username)));
        }

        [TestCase(1, "go6o")]
        [TestCase(2, "Max")]
        [TestCase(3, "Steve")]
        public void AddUserWithSameId(int id, string username)
        {
            var db = new Database();

            db.Add(new Person(id, username));

            Assert.Throws<InvalidOperationException>(
                () => db.Add(new Person(id + 1, username)));
        }

        [TestCase(1, 1, 0)]
        [TestCase(2, 2, 0)]
        [TestCase(7, 1, 6)]
        [TestCase(7, 5, 2)]
        public void RemovePerson(int peopleToAdd, int peopleToRemove, int expectedPeopleLeft)
        {
            var db = new Database();

            for (int i = 0; i < peopleToAdd; i++)
            {
                db.Add(new Person(i, $"Person{i}"));
            }

            for (int i = 0; i < peopleToRemove; i++)
            {
                db.Remove();
            }

            Assert.That(db.Count, Is.EqualTo(expectedPeopleLeft));
        }

        [Test]
        public void RemovePersonWhenCollectionIsEmpty()
        {
            var db = new Database();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [TestCase(1, "Ivan")]
        [TestCase(2, "Andrei")]
        [TestCase(2, "pe60")]
        public void FindPersonByExistingUsername(int id, string username)
        {
            var db = new Database();

            db.Add(new Person(id, username));

            var person = db.FindByUsername(username);

            Assert.That(person, Is.Not.Null);
            //Assert.IsNotNull(person);
        }

        [TestCase(1, "")]
        [TestCase(2, null)]
        public void FindPersonByNullUsername(int id, string username)
        {
            var db = new Database();

            db.Add(new Person(1, "steve"));

            Assert.That(() => db.FindByUsername(username), Throws.ArgumentNullException);
            //Assert.Throws<ArgumentNullException>(() => db.FindByUsername(username));
        }

        [TestCase("pe60", "go6o")]
        [TestCase("pe60", "pe6o")]
        [TestCase("Ivan", "ivan")]
        [TestCase("Ivan", "IVAN")]
        [TestCase("Ivan", "iVan")]
        public void FindPersonByWrongUsername(string username, string searchedUsername)
        {
            var db = new Database();

            db.Add(new Person(1, username));

            Assert.That(() => db.FindByUsername(searchedUsername), Throws.InvalidOperationException);
            //Assert.Throws<InvalidOperationException>(() => db.FindByUsername(searchedUsername));
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(10000, 10000)]
        [TestCase(100000000, 100000000)]
        public void FindPersonByExistingId(int id, int searchedId)
        {
            var db = new Database();

            db.Add(new Person(id, "person"));

            var person = db.FindById(searchedId);

            Assert.That(person, Is.Not.Null);
            //Assert.IsNotNull(db.FindById(searchedId));
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(1110)]
        [TestCase(1000000000)]
        public void FindPersonByNonExistingId(int searchedId)
        {
            var db = new Database();

            Assert.That(() => db.FindById(searchedId), Throws.InvalidOperationException);
            //Assert.Throws<InvalidOperationException>(() => db.FindById(searchedId));
        }

        [TestCase(-1)]
        [TestCase(-123)]
        [TestCase(-12300000)]
        public void FindPersonByNegativeId(int searchedId)
        {
            var db = new Database();

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(searchedId));
        }
    }
}