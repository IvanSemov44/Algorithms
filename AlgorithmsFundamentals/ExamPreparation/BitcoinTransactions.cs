namespace ExamPreparation
{
    internal class BitcoinTransactions
    {
        public static void Solution()
        {
            var first = Console.ReadLine()
                .Split()
                .ToArray();

            var second = Console.ReadLine()
                .Split()
                .ToArray();

            int rowLength = first.Length;
            int colLength = second.Length;

            var lcs = new int[rowLength + 1, colLength + 1];

            for (int row = 1; row < lcs.GetLength(0); row++)
                for (int col = 1; col < lcs.GetLength(1); col++)
                    if (first[row - 1] == second[col - 1])
                        lcs[row, col] = lcs[row - 1, col - 1] + 1;
                    else
                        lcs[row, col] = Math.Max(lcs[row - 1, col], lcs[row, col - 1]);

            Stack<string> longestCommonSubsequence = new Stack<string>();

            while (rowLength > 0 && colLength > 0)
                if (first[rowLength - 1] == second[colLength - 1])
                {
                    longestCommonSubsequence.Push(first[rowLength - 1]);
                    rowLength--;
                    colLength--;
                }
                else if (lcs[rowLength, colLength - 1] >= lcs[rowLength - 1, colLength])
                    colLength--;
                else
                    rowLength--;

            Console.WriteLine(string.Join(" ", longestCommonSubsequence));
        }
    }
}
