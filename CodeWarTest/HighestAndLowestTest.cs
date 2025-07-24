using SolutionsFromCodewars;

namespace CodeWarTest
{
    [TestFixture]
    public class HighestAndLowestTest
    {
        [Test, Order(1)]
        public void Test1()
        {
            Assert.That(HighestAndLowest.HighAndLow("8 3 -5 42 -1 0 0 -9 4 7 4 -4"), Is.EqualTo("42 -9"));
        }
        [Test, Order(2)]
        public void Test2()
        {
            Assert.That(HighestAndLowest.HighAndLow("1 2 3"), Is.EqualTo("3 1"));
        }
    }
}