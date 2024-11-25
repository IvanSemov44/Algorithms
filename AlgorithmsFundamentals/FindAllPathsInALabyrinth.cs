using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace RecurtionAndBackTracking
{
    internal static class FindAllPathsInALabyrinth
    {

        // You are given a labyrinth.Your goal is to find all paths from the start(cell 0, 0) to the exit, marked with 'e'. 
        //• Empty cells are marked with a dash '-'.
        //• Walls are marked with a star '*'.
        //On the first line, you will receive the dimensions of the labyrinth.Next, you will receive the actual labyrinth.
        //The order of the paths does not matter.

        //Examples

        //Input      Output

        //3          RRDD
        //3          DDRR
        //---
        //-*-
        //--e

        //Input      Output

        //3          DRRRRU
        //5          DRRRUR
        //-**-e
        //-----
        //*****
        //DRRRRU
        //DRRRUR

        internal static void FindPaths()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var lab = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                var colElements = Console.ReadLine();

                for (int j = 0; j < colElements.Length; j++)
                {
                    lab[i, j] = colElements[j];
                }
            }
            FindPaths(lab, 0, 0, new List<string>(), string.Empty);
        }

        private static void FindPaths(char[,] lab, int row, int col, List<string> directions, string direction)
        {
            // Validate row and col
            if (row < 0 || row >= lab.GetLength(0) || col < 0 || col >= lab.GetLength(1)) return;

            // Checks for walls оr already visited cells
            if (lab[row, col] == '*' || lab[row, col] == 'v') return;

            directions.Add(direction);

            // Check for end
            if (lab[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            lab[row, col] = 'v';

            FindPaths(lab, row - 1, col, directions, "U");   //UP
            FindPaths(lab, row + 1, col, directions, "D");   //DOWN
            FindPaths(lab, row, col - 1, directions, "L");   //LEFT
            FindPaths(lab, row, col + 1, directions, "R");   //RIGHT

            lab[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }
    }
}
