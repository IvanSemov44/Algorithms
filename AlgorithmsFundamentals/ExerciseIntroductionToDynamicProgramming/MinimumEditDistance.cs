namespace ExerciseIntroductionToDynamicProgramming
{
    /*
     7. Minimum Edit Distance
We have two strings, s1 and s2. The goal is to obtain s2 from s1 by applying the following operations:
• replace(i, x) – in s1, replace the symbol at index with the character x
• insert(i, x) – in s1, inserts the character x at index i
• delete(i) – from s1, remove the character at index i
We are only allowed to modify s1, s2 always stays unchanged. Each of the three operations has a certain cost
associated with it (positive integer number).
Note: the cost of the replace(i, x) operation is 0 if it does not change the character.
The goal is to find the sequence of operations which will produce s2 from s1 with minimal cost.
*/

    //Input                 Output
    //3                     Minimum edit distance: 7
    //2
    //1
    //abracadabra
    //mabragabra
    //----------------------------------------------
    //1                     Minimum edit distance: 8
    //1
    //1
    //equal
    //different


    internal static class MinimumEditDistance
    {
        public static void Solution()
        {
            var replaceCost = int.Parse(Console.ReadLine());
            var insertCost = int.Parse(Console.ReadLine());
            var deleteCost = int.Parse(Console.ReadLine());

            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var dp = new int[str1.Length + 1, str2.Length + 1];

            for (int col = 1; col < dp.GetLength(1); col++)
                dp[0, col] = dp[0, col - 1] + insertCost;

            for (int row = 1; row < dp.GetLength(0); row++)
                dp[row, 0] = dp[row - 1, 0] + deleteCost;

            for (int row = 1; row < dp.GetLength(0); row++)
                for (int col = 1; col < dp.GetLength(1); col++)
                    if (str1[row - 1] == str2[col - 1])
                        dp[row, col] = dp[row - 1, col - 1];
                    else
                    {
                        var replace = dp[row - 1, col - 1] + replaceCost;
                        var delete = dp[row - 1, col] + deleteCost;
                        var insert = dp[row, col - 1] + insertCost;

                        dp[row, col] = Math.Min(Math.Min(replace, delete), insert);
                    }

            Console.WriteLine($"Minimum edit distance: {dp[str1.Length, str2.Length]}");
        }
    }
}
