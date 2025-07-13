namespace SolutionsFromCodewars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(JosSurvivor.Solution(7, 3));
            //Console.WriteLine(JosSurvivor.Solution(100,1));

            //FindTheOddInt.Solution(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 });

            ArrayDiff.Solution(new int[] { 1, 2 }, new int[] { 1 });
            ArrayDiff.Solution(new int[] { 1, 2, 2 }, new int[] { 1 });
            ArrayDiff.Solution(new int[] { 1, 2, 2 }, new int[] { 2 });
            ArrayDiff.Solution(new int[] { 1, 2, 2 }, new int[] { });
            ArrayDiff.Solution(new int[] { }, new int[] { 1, 2 });
            ArrayDiff.Solution(new int[] { 1, 2, 3 }, new int[] { 1, 2 });




        }
    }
}
