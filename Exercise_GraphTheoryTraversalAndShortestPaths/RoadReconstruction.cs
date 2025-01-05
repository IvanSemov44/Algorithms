namespace Exercise_GraphTheoryTraversalAndShortestPaths
{
    /*
     6. Road Reconstruction
Write a program that finds all the roads without which buildings in the city will become unreachable. 
You will receive how many buildings the town has on the first line, then you will receive the number of streets and 
finally, for each street, you will receive which buildings it connects. Find all the streets that are important and 
cannot be removed and print them in ascending order (e. g. 3 0 should be printed as 0 3).
    */
    //Input
    /*
5
5
1 - 0
0 - 2
2 - 1
0 - 3
3 - 4
    */
    //Output
    /*
Important streets:
0 3
3 4
     */

    public class EdgeRoad
    {
        public int First { get; set; }
        public int Second { get; set; }
        public override string ToString() => $"{First} {Second}";
    }

    internal static class RoadReconstruction
    {
        private static List<int>[] graph;
        private static List<EdgeRoad> edges;
        private static bool[] visited;

        public static void Solution()
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            edges = new List<EdgeRoad>();

            for (int node = 0; node < graph.Length; node++)
                graph[node] = new List<int>();

            for (int i = 0; i < e; i++)
            {
                var edgePaths = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgePaths[0];
                var secondNode = edgePaths[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);

                edges.Add(new EdgeRoad { First = firstNode, Second = secondNode });
            }

            Console.WriteLine("Important streets:");

            foreach (var edge in edges)
            {
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                visited = new bool[graph.Length];

                DFS(0);

                if (visited.Contains(false))
                {
                    var newEdge = new EdgeRoad
                    {
                        First = Math.Min(edge.First, edge.Second),
                        Second = Math.Max(edge.First, edge.Second),
                    };

                    Console.WriteLine(newEdge);
                }

                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }
        }
        private static void DFS(int node)
        {
            if (visited[node])
                return;

            visited[node] = true;

            foreach (var child in graph[node])
                DFS(child);
        }
    }
}
