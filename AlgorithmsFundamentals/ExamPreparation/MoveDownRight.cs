
namespace ExamPreparation
{
    internal class MoveDownRight
    {
        private static List<string> endResult;
        public static void Solution()
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            var grid = new int[row, col];

            endResult = new List<string>();

            FindPaths(grid, 0, 0, new List<string>(), string.Empty);

            Console.WriteLine(endResult.Count);
        }

        private static void FindPaths(int[,] grid, int row, int col, List<string> directions, string direction)
        {
            if (row >= grid.GetLength(0) || col >= grid.GetLength(1))
                return;

            if (grid[row, col] == 1)
                return;

            directions.Add(direction);

            if (row == grid.GetLength(0) - 1 && col == grid.GetLength(1) - 1)
            {
                endResult.Add(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            grid[row, col] = 1;

            FindPaths(grid, row + 1, col, directions, "D");
            FindPaths(grid, row, col + 1, directions, "R");

            grid[row, col] = 0;
            directions.RemoveAt(directions.Count - 1);
        }
    }
}
