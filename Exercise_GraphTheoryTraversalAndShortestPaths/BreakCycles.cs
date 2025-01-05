namespace Exercise_GraphTheoryTraversalAndShortestPaths
{
    /*
     5. Break Cycles
You are given an undirected multi-graph. Remove a minimal number of edges to make the graph acyclic (to break all 
cycles). As a result, print the number of edges removed and the removed edges. If several edges can be removed to 
break a certain cycle, remove the smallest of them in alphabetical order (smallest start vertex in alphabetical order 
and smallest end vertex in alphabetical order). 
    */
    //Input
    /*
8 
1 -> 2 5 4
2 -> 1 3
3 -> 2 5
4 -> 1
5 -> 1 3
6 -> 7 8
7 -> 6 8
8 -> 6 7
    */
    //Output
    /*
Edges to remove: 2
1 - 2
6 - 7
     */
    public class Edge
    {
        public string First { get; set; }
        public string Second { get; set; }

        public override string ToString()
        {
            return $"{First} - {Second}";
        }
    }

    internal static class BreakCycles
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        public static void Solution()
        {
            int n = int.Parse(Console.ReadLine());
            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                var nodeAndChildren = Console.ReadLine().Split(" -> ");

                var node = nodeAndChildren[0];
                var children = nodeAndChildren[1].Split().ToList();

                graph[node] = children;

                foreach (var child in children)
                    edges.Add(new Edge { First = node, Second = child });
            }

            edges = edges
                 .OrderBy(e => e.First)
                 .ThenBy(e => e.Second)
                 .ToList();

            var removedEdges = new List<Edge>();


            foreach (var edge in edges)
            {
                var removed = graph[edge.First].Remove(edge.Second) &&
                              graph[edge.Second].Remove(edge.First);

                if (!removed)
                    continue;

                if (BFS(edge.First, edge.Second))
                {
                    removedEdges.Add(edge);
                }
                else
                {
                    graph[edge.First].Add(edge.Second);
                    graph[edge.Second].Add(edge.First);
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");

            foreach (var edge in removedEdges)
                Console.WriteLine(edge);
        }

        private static bool BFS(string start, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);

            var visited = new HashSet<string> { start };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                    return true;

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                        continue;

                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return false;
        }
    }
}
