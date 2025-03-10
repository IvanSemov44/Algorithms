namespace GraphsDijkstraMST
{
    internal static class KruskalAlg
    {
        private static List<Edge> edges;
        private static List<Edge> forest;
        private static int[] parent;

        public static void Solution()
        {
            edges = new List<Edge>();
            forest = new List<Edge>();

            var maxNode = ReadEdges();

            parent = new int[maxNode + 1];

            for (int node = 0; node < parent.Length; node++)
                parent[node] = node;

            Kruskal();

            foreach (var edge in forest)
                Console.WriteLine($"{edge.First} - {edge.Second}");
        }

        private static void Kruskal()
        {
            var sortedEdges = edges
                .OrderBy(e => e.Weight)
                .ToArray();
            ;
            foreach (var edge in sortedEdges)
            {
                var firstNodeRoot = FindRoot(edge.First);
                var secondNodeRoot = FindRoot(edge.Second);

                if (firstNodeRoot == secondNodeRoot)
                    continue;

                parent[firstNodeRoot] = secondNodeRoot;

                forest.Add(edge);
            }
        }

        private static int FindRoot(int node)
        {
            while (node != parent[node])
                node = parent[node];

            return node;
        }

        private static int ReadEdges()
        {
            var count = int.Parse(Console.ReadLine());

            var maxNode = -1;

            for (int i = 0; i < count; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];

                if (firstNode > maxNode)
                    maxNode = firstNode;

                if (secondNode > maxNode)
                    maxNode = secondNode;

                edges.Add(new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = edgeData[2]
                });
            }

            return maxNode;
        }
    }
}
