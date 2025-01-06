namespace IntroductionToDynamicProgramming
{
    /*
     2. Move Down/Right
Given a matrix of N by M cells filled with positive integers, find the path from top left to bottom right with the
highest sum of cells by moving only down or right.
    */
    internal static class MoveDownRight
    {
        public static void Solution()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var rowsElemets = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < rowsElemets.Length; c++)
                    matrix[r, c] = rowsElemets[c];
            }

            var dp = new int[rows, cols];
            dp[0, 0] = matrix[0, 0];

            for (int c = 1; c < cols; c++)
                dp[0, c] = dp[0, c - 1] + matrix[0, c];

            for (int r = 1; r < rows; r++)
                dp[r, 0] = dp[r - 1, 0] + matrix[r, 0];

            for (int r = 1; r < rows; r++)
                for (int c = 1; c < cols; c++)
                    dp[r, c] = Math.Max(dp[r - 1, c], dp[r, c - 1]) + matrix[r, c];

            var path = new Stack<string>();

            var row = rows - 1;
            var col = cols - 1;

            while (row > 0 && col > 0)
            {
                path.Push($"[{row}, {col}]");

                var upper = dp[row - 1, col];
                var left = dp[row, col - 1];

                if (upper > left)
                    row -= 1;
                else
                    col -= 1;
            }

            while (row > 0)
            {
                path.Push($"[{row}, {col}]");
                row -= 1;
            }
            while (col > 0)
            {
                path.Push($"[{row}, {col}]");
                col -= 1;
            }

            path.Push($"[{row}, {col}]");

            Console.WriteLine(string.Join(" ", path));
        }
    }
}
