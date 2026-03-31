namespace Exercise_GraphTheoryTraversalAndShortestPaths
{

    /*
     1. Distance Between Vertices
We are given a directed graph. We are given also a set of pairs of vertices. Find the shortest distance between each 
pair of vertices or -1 if there is no path connecting them. 
On the first line, you will get N, the number of vertices in the graph. On the second line, you will get P, the number of 
pairs between which to find the shortest distance. 
On the next N lines will be the edges of the graph and on the next P lines, the pairs.
*/
    //INPUT
/*
8
4
1:4
2:4
3:4 5
4:6
5:3 7 8
6:
7:8
8:
1-6
1-5
5-6
5-8
*/
    // OUTPUT
/*
{1, 6} -> 2
{1, 5} -> -1
{5, 6} -> 3
{5, 8} -> 1
 */

    internal static class DistanceBetweenVertices
    {
        private static Dictionary<int, List<int>> graph;

        public static void Solution()
        {
            var nodes = int.Parse(Console.ReadLine());
            var pairs = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();

            //Read Graph From Console
            for (int i = 0; i < nodes; i++)
            {
                var nodeAndChildren = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

                var node = int.Parse(nodeAndChildren[0]);

                if (nodeAndChildren.Length == 1)
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var chidren = nodeAndChildren[1]
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                    graph[node] = chidren;
                }
            }

            //Find Distance
            for (int i = 0; i < pairs; i++)
            {
                var pair = Console.ReadLine()
                    .Split("-")
                    .Select(int.Parse)
                    .ToArray();

                var start = pair[0];
                var destination = pair[1];

                var steps = BFS(start, destination);

                Console.WriteLine($"{{{start}, {destination}}} -> {steps}");
            }
        }
        private static int BFS(int start, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            var visited = new HashSet<int> { start };
            var parent = new Dictionary<int, int> { { start, -1 } };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                    return GetSteps(parent, destination);

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child)) continue;

                    visited.Add(child);
                    queue.Enqueue(child);
                    parent[child] = node;
                }
            }

            return -1;
        }

        private static int GetSteps(Dictionary<int, int> parent, int destination)
        {
            var steps = 0;
            var node = destination;

            while (node != -1)
            {
                node = parent[node];
                steps++;
            }

            return steps - 1;
        }
    }
}
