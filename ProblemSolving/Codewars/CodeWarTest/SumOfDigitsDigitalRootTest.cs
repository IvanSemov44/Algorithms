using SolutionsFromCodewars;

namespace CodeWarTest
{
    [TestFixture]
    public class SumOfDigitsDigitalRootTest
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(10, ExpectedResult = 1)]
        [TestCase(16, ExpectedResult = 7)]
        [TestCase(195, ExpectedResult = 6)]
        [TestCase(992, ExpectedResult = 2)]
        [TestCase(167346, ExpectedResult = 9)]
        [TestCase(999999999999, ExpectedResult = 9)]
        [Order(1)]
        public int Tests(long n)
        {
            return SumOfDigitsDigitalRoots.DigitalRoot(n);
        }
    }

}
