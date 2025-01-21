namespace ExamPreparation
{
    internal static class Time
    {
        private static int[][] lcs;
        public static void Solution()
        {
            var first = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var second = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            InitializeTable(first, second);

            Stack<int> longestCommonSubsequence = new Stack<int>();

            int row = first.Length;
            int col = second.Length;

            while (row > 0 && col > 0)
                if (first[row - 1] == second[col - 1])
                {
                    longestCommonSubsequence.Push(first[row - 1]);
                    row--;
                    col--;
                }
                else if (lcs[row][col - 1] >= lcs[row - 1][col])
                    col--;
                else
                    row--;

            Console.WriteLine(string.Join(" ", longestCommonSubsequence));
            Console.WriteLine(lcs[^1][^1]);
        }

        private static void InitializeTable(int[] firstSequence, int[] secondSequence)
        {
            lcs = new int[firstSequence.Length + 1][];

            for (int row = 0; row < lcs.Length; row++)
                lcs[row] = new int[secondSequence.Length + 1];

            for (int row = 1; row < lcs.Length; row++)
                for (int col = 1; col < lcs[row].Length; col++)
                    if (firstSequence[row - 1] == secondSequence[col - 1])
                        lcs[row][col] = lcs[row - 1][col - 1] + 1;
                    else
                        lcs[row][col] = Math.Max(lcs[row][col - 1], lcs[row - 1][col]);
        }
    }
}