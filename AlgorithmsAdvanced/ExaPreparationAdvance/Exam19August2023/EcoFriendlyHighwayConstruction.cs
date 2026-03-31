namespace ExamPreparationAdvance.Exam19August2023
{
    public class EdgeEco
    {
        public char First { get; set; }
        public char Second { get; set; }
        public int TotalWeight { get; set; }
    }

    internal static class EcoFriendlyHighwayConstruction
    {
        private static List<EdgeEco> edges;
        private static List<EdgeEco> forest;
        private static char[] parent;

        public static void Solution()
        {
            edges = new List<EdgeEco>();
            forest = new List<EdgeEco>();

            var maxNode = ReadGraph();

            parent = new char[maxNode + 1];
            for (int i = 0; i < parent.Length; i++)
                parent[i] = (char)(i + 65);

            Kruskal();

            var count = 0;
            foreach (var edge in forest)
                count += edge.TotalWeight;

            Console.WriteLine("Total cost of building highways: " + count);
        }
        private static void Kruskal()
        {
            var sortedEdges = edges.OrderBy(e => e.TotalWeight);

            foreach (var edge in sortedEdges)
            {
                var firstNodeRoot = FindRoot(edge.First);
                var secondNodeRoot = FindRoot(edge.Second);

                if (firstNodeRoot == secondNodeRoot)
                    continue;

                parent[firstNodeRoot - 65] = secondNodeRoot;

                forest.Add(edge);
            }
        }

        private static char FindRoot(char node)
        {
            while (node != parent[node - 65])
                node = parent[node - 65];

            return node;
        }

        private static int ReadGraph()
        {
            var count = int.Parse(Console.ReadLine());
            var maxNode = 0;

            for (int i = 0; i < count; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .ToArray();

                var firstNode = char.Parse(edgeData[0]);
                var secondNode = char.Parse(edgeData[1]);

                if (firstNode > maxNode)
                    maxNode = firstNode;

                if (secondNode > maxNode)
                    maxNode = secondNode;

                var totalWeight = int.Parse(edgeData[2]);

                if (edgeData.Length > 3)
                    totalWeight += int.Parse(edgeData[3]);

                var edge = new EdgeEco
                {
                    First = firstNode,
                    Second = secondNode,
                    TotalWeight = totalWeight,
                };
                edges.Add(edge);
            }
            return maxNode - 65;
        }
    }
}