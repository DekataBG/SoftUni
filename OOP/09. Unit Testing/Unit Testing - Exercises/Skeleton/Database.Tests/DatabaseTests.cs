namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] {1, 2, 3})]
        [TestCase(new int[] {})]
        [TestCase(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15})]
        public void AddingElements(int[] array)
        {
            var database = new Database(array);

            Assert.AreEqual(array.Length, database.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 14, 16 }, 0)]
        public void Adding17thElementThrowsException(int[] array, int element)
        {
            var database = new Database(array);

            Assert.Throws<InvalidOperationException>(() => database.Add(element));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 18, 20 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 14, 16, 16, 16 })]
        public void ConstructorWithMoreThan17ElementsThrowsException(int[] array)
        {
            Database database;

            Assert.Throws<InvalidOperationException>(() =>  database = new Database(array));
        }

        [TestCase(new int[] {1,2,3,4,5 }, 3, 2)]
        [TestCase(new int[] {1,2,3,4,5,6,7 }, 3, 4)]
        [TestCase(new int[] {1,2,3,4,5 }, 0, 5)]
        public void RemovingElementReducesCount(int[] array, int elementsToRemove, int expectedElements)
        {
            Database database = new Database(array);

            for (int i = 0; i < elementsToRemove; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedElements, database.Count);
        }

        [TestCase(new int[] {1,2,3,4,5}, 6)]
        [TestCase(new int[] { }, 1)]
        public void RemovingElementFromEmptyCollection(int[] array, int elementsToRemove)
        {
            Database database = new Database(array);

            for (int i = 0; i < elementsToRemove - 1; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() =>database.Remove());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 5 })]
        public void FetchReturnsArray(int[] array)
        {
            var database = new Database(array);

            Assert.IsInstanceOf(typeof(int[]), database.Fetch());
        }
    }
}
