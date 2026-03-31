
namespace Exercise_GraphTheoryTraversalAndShortestPaths
{
    /*
     2. Areas in Matrix
We are given a matrix of letters of size N * M. Two cells are neighbors if they share a common wall. Write a program 
to find the connected areas of neighbor cells holding the same letter. Display the total number of areas and 
the number of areas for each alphabetical letter (ordered by alphabetical order). 
On the first line is given the number of rows
    */
    //INPUT
    /*
6
8
aacccaac
baaaaccc
baabaccc
bbdaaccc
ccdccccc
ccdccccc
    */
    //OUTPUT
    /*
Areas: 8
Letter 'a' -> 2
Letter 'b' -> 2
Letter 'c' -> 3
Letter 'd' -> 1
    */

    internal static class AreasInMatrix
    {
        private static char[,] graph;
        private static bool[,] visited;
        private static SortedDictionary<char, int> areas;

        public static void Solution()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            graph = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();

            for (int i = 0; i < rows; i++)
            {
                var rowsElements = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                    graph[i, j] = rowsElements[j];
            }

            var areasCount = 0;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    if (visited[r, c]) continue;

                    var nodeValue = graph[r, c];
                    DFS(r, c, nodeValue);

                    areasCount++;

                    if (areas.ContainsKey(nodeValue))
                        areas[nodeValue]++;
                    else
                        areas[nodeValue] = 1;
                }

            Console.WriteLine($"Areas: {areasCount}");

            foreach (var kvp in areas)
                Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
        }

        private static void DFS(int row, int col, char parentNode)
        {
            if (row < 0 || row >= graph.GetLength(0) ||
                col < 0 || col >= graph.GetLength(1))
                return;

            if (visited[row, col]) return;

            if (graph[row, col] != parentNode) return;

            visited[row, col] = true;

            DFS(row, col - 1, parentNode);
            DFS(row, col + 1, parentNode);
            DFS(row - 1, col, parentNode);
            DFS(row + 1, col, parentNode);
        }
    }
}
