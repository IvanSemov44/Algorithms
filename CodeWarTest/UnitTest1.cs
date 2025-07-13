using SolutionsFromCodewars;

namespace CodeWarTest
{

    [TestFixture]
    public class SolutionTest
    {
        [Test, Order(1)]
        public void SampleTest()
        {
            Assert.That(ArrayDiff.Solution(new int[] { 1, 2 }, new int[] { 1 }), Is.EqualTo(new int[] { 2 }));

            Assert.That(ArrayDiff.Solution(new int[] { 1, 2 }, new int[] { 1 }), Is.EqualTo(new int[] { 2 }));
            Assert.That(ArrayDiff.Solution(new int[] { 1, 2, 2 }, new int[] { 1 }), Is.EqualTo(new int[] { 2, 2 }));
            Assert.That(ArrayDiff.Solution(new int[] { 1, 2, 2 }, new int[] { 2 }), Is.EqualTo(new int[] { 1 }));
            Assert.That(ArrayDiff.Solution(new int[] { 1, 2, 2 }, new int[] { }), Is.EqualTo(new int[] { 1, 2, 2 }));
            Assert.That(ArrayDiff.Solution(new int[] { }, new int[] { 1, 2 }), Is.EqualTo(new int[] { }));
            Assert.That(ArrayDiff.Solution(new int[] { 1, 2, 3 }, new int[] { 1, 2 }), Is.EqualTo(new int[] { 3 }));
        }
    }
}