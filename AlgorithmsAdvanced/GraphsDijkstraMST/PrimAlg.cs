namespace GraphsDijkstraMST
{
    using Wintellect.PowerCollections;

    internal static class PrimAlg
    {
        private static Dictionary<int, List<Edge>> graph;
        private static HashSet<int> forestNodes;
        private static List<Edge> forestEdges;

        public static void Solution()
        {
            graph = new Dictionary<int, List<Edge>>();
            forestNodes = new HashSet<int>();
            forestEdges = new List<Edge>();

            ReadGraph();

            foreach (var node in graph.Keys)
                if (!forestNodes.Contains(node))
                    Prim(node);

            foreach (var edge in forestEdges)
                Console.WriteLine($"{edge.First} - {edge.Second}");
        }

        private static void Prim(int startingNode)
        {
            forestNodes.Add(startingNode);

            var bag = new OrderedBag<Edge>(
                Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            bag.AddMany(graph[startingNode]);

            while (bag.Count > 0)
            {
                var minEdge = bag.RemoveFirst();

                var nonTreeNode = -1;


                if (forestNodes.Contains(minEdge.First) &&
                    !forestNodes.Contains(minEdge.Second))
                {
                    nonTreeNode = minEdge.Second;
                }

                if (forestNodes.Contains(minEdge.Second) &&
                   !forestNodes.Contains(minEdge.First))
                {
                    nonTreeNode = minEdge.First;
                }

                if (nonTreeNode == -1)
                    continue;

                forestNodes.Add(nonTreeNode);
                forestEdges.Add(minEdge);
                bag.AddMany(graph[nonTreeNode]);
            }
        }

        private static void ReadGraph()
        {
            var edges = int.Parse(Console.ReadLine());

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];

                if (!graph.ContainsKey(firstNode))
                    graph[firstNode] = new List<Edge>();

                if (!graph.ContainsKey(secondNode))
                    graph[secondNode] = new List<Edge>();

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = edgeData[2]
                };

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }
        }
    }
}
