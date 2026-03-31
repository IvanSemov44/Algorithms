using System;
using System.Collections.Generic;
using System.Drawing;

namespace Exercise_RecursionAndCombinatorialProblems
{

    /*
     * 3. Connected Areas in a Matrix
    Let’s define a connected area in a matrix as an area of cells in which there is a path between every two cells. 
    Write a program to find all connected areas in a matrix. 
    Input
    • On the first line, you will get the number of rows.
    • On the second line, you will get the number of columns.
    • The rest of the input will be the actual matrix.
    Output
    • Print on the console the total number of areas found.
    • On a separate line for each area print its starting coordinates and size. 
    • Order the areas by size (in descending order) so that the largest area is printed first.
    o If several areas have the same size, order them by their position, first by the row, then by the column 
    of the top-left corner.
    o If there are two connected areas of the same size, the one which is above and/or to the left of the 
    other will be printed first.

    Examples

    Input Output
    4
    9
    ---*---*-
    ---*---*-
    ---*---*-
    ----*-*--
    Total areas found: 3
    Area #1 at (0, 0), size: 13
    Area #2 at (0, 4), size: 10
    Area #3 at (0, 8), size: 5

    5
    10
    *--*---*--
    *--*---*--
    *--*****--
    *--*---*--
    *--*---*--
    Total areas found: 4
    Area #1 at (0, 1), size: 10
    Area #2 at (0, 8), size: 10
    Area #3 at (0, 4), size: 6
    Area #4 at (3, 4), size: 6
    
         */

    public class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }

    internal static class ConnectedAreasInAMatrix
    {
        private const char VisitedSymbol = 'v';
        private static char[,] matrix;
        private static int size = 0;

        public static void Solution()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var colElements = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = colElements[c];
                }
            }

            var areas = new List<Area>();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    size = 0;
                    ExploreArea(r, c);

                    if (size != 0)
                    {
                        areas.Add(new Area { Row = r, Col = c, Size = size });
                    }
                }
            }

            var sorted = areas
                .OrderByDescending(a => a.Size)
                .ThenBy(a => a.Row)
                .ThenBy(a => a.Col)
                .ToList();

            Console.WriteLine($"Total areas found: {areas.Count}");

            for (int i = 0; i < sorted.Count; i++)
            {
                var area = sorted[i];
                Console.WriteLine($"Area #{i + 1} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static void ExploreArea(int row, int col)
        {
            if (IsOutside(row, col) || IsWall(row, col) || IsVisited(row, col))
            {
                return;
            }

            size += 1;
            matrix[row, col] = VisitedSymbol;

            ExploreArea(row - 1, col);
            ExploreArea(row + 1, col);
            ExploreArea(row, col - 1);
            ExploreArea(row, col + 1);
        }

        private static bool IsVisited(int row, int col)
        {
            return matrix[row, col] == VisitedSymbol;
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1);
        }
    }
}
