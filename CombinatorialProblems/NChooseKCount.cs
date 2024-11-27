
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CombinatorialProblems
{
    //7. N Choose K Count
    //Given a n and k, calculate the number of possible n choose k combinations(without repetition).

    //Examples

    //Input         Input
    //3             5
    //2             3

    //Output        Output
    //3             10
    internal class NChooseKCount
    {
        public static void Solution()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(GetBinom(n, k));
        }
        private static int GetBinom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row) return 1;

            return GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
        }
    }
}
