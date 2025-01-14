namespace ExerciseIntroductionToDynamicProgramming
{
    /*
     5. Word Differences
Write a program that finds all the differences between two strings. You have to determine the smallest set of
deletions and insertions to make the first string equal to the second. Finally, you have to print the count of the
minimum insertions and deletions.
    */

    //Input         Output
    //YMCA          Deletions and Insertions: 6 
    //HMBB
    //---------------------------------
    //JFEIOWHGOW    Deletions and Insertions: 12
    //GHEWQHFEWQ

    internal static class WordDifferences
    {
        public static void Solution()
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var dp = new int[str1.Length + 1, str2.Length + 1];

            for (int row = 0; row < dp.GetLength(0); row++)
                dp[row, 0] = row;

            for (int col = 0; col < dp.GetLength(1); col++)
                dp[0, col] = col;

            for (int row = 1; row < dp.GetLength(0); row++)
                for (int col = 1; col < dp.GetLength(1); col++)
                    if (str1[row - 1] == str2[col - 1])
                        dp[row, col] = dp[row - 1, col - 1];
                    else
                        dp[row, col] = Math.Min(dp[row - 1, col], dp[row, col - 1]) + 1;

            Console.WriteLine($"Deletions and Insertions: {dp[str1.Length, str2.Length]}");
        }
    }
}
