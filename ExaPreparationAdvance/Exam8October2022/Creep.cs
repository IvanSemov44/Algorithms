namespace ExamPreparationAdvance.Exam8October2022
{
    public class EdgeVine
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }

    internal static class Creep
    {
        public static void Solution()
        {
            var nodes = int.Parse(Console.ReadLine());
            var count = int.Parse(Console.ReadLine());

            var graph = new Dictionary<int, Dictionary<int, int>>();
            for (int node = 0; node < nodes + 1; node++)
                graph.Add(node, new Dictionary<int, int>());

            for (int i = 0; i < count; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var fromNode = edgeData[0];
                var toNode = edgeData[1];
                var weight = edgeData[2];

                graph[fromNode][toNode] = weight;
            }

            var sortedEdges = new List<EdgeVine>();
            foreach (var node in graph)
            {
                foreach (var child in node.Value)
                {
                    var edge = new EdgeVine
                    {
                        First = node.Key,
                        Second = child.Key,
                        Weight = child.Value
                    };
                    sortedEdges.Add(edge);
                }
            }

            var parent = new int[nodes + 1];
            for (int node = 0; node < parent.Length; node++)
                parent[node] = node;

            var mst = new List<EdgeVine>();

            sortedEdges = sortedEdges
               .OrderBy(e => e.Weight)
               .ToList();

            foreach (var edge in sortedEdges)
            {
                var firstNodeRoot = FindRoot(edge.First, parent);
                var secondNodeRoot = FindRoot(edge.Second, parent);

                if (firstNodeRoot == secondNodeRoot)
                    continue;

                parent[firstNodeRoot] = secondNodeRoot;

                mst.Add(edge);
            }

            var resunt = 0;
            foreach (var edge in mst)
            {
                Console.WriteLine(edge.First + " " + edge.Second);
                resunt += edge.Weight;
            }
            Console.WriteLine(resunt);
        }
        private static int FindRoot(int node, int[] parent)
        {
            while (node != parent[node])
                node = parent[node];

            return node;
        }
    }
}
