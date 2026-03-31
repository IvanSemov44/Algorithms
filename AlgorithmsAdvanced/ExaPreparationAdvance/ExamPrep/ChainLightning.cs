namespace ExamPreparationAdvance.ExamPrep
{
    public class EdgeChain
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }

    internal static class ChainLightning
    {
        public static void Solution()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());
            var lightnings = int.Parse(Console.ReadLine());


            var graph = new List<EdgeChain>[nodes];

            for (int node = 0; node < graph.Length; node++)
                graph[node] = new List<EdgeChain>();

            for (int i = 0; i < edges; i++)
            {
                var edgeParts = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeParts[0];
                var secondNode = edgeParts[1];
                var weight = edgeParts[2];

                var edge = new EdgeChain
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight
                };

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }

            var damageByNode = new int[nodes];

            for (int i = 0; i < lightnings; i++)
            {
                var lightningParts = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var node = lightningParts[0];
                var damage = lightningParts[1];

                Prim(graph, damageByNode, node, damage);
            }

            Console.WriteLine(damageByNode.Max());
        }

        private static void Prim(List<EdgeChain>[] graph, int[] damageByNode, int startNode, int damage)
        {
            damageByNode[startNode] += damage;

            var tree = new HashSet<int> { startNode };
            var jumps = new int[graph.Length];

            var queue = new PriorityQueue<EdgeChain, int>();

            foreach (var edge in graph[startNode])
                queue.Enqueue(edge, edge.Weight);

            while (queue.Count > 0)
            {
                var minEdge = queue.Dequeue();

                var treeNode = -1;
                var nonTreeNode = -1;

                if (tree.Contains(minEdge.First) &&
                    !tree.Contains(minEdge.Second))
                {
                    treeNode = minEdge.First;
                    nonTreeNode = minEdge.Second;
                }
                else if (tree.Contains(minEdge.Second) &&
                     !tree.Contains(minEdge.First))
                {
                    treeNode = minEdge.Second;
                    nonTreeNode = minEdge.First;
                }

                if (nonTreeNode == -1)
                    continue;

                tree.Add(nonTreeNode);

                foreach (var edge in graph[nonTreeNode])
                    queue.Enqueue(edge, edge.Weight);

                jumps[nonTreeNode] = jumps[treeNode] + 1;
                damageByNode[nonTreeNode] += CalcDamage(damage, jumps[nonTreeNode]);
            }
        }

        private static int CalcDamage(int damage, int jumps)
        {
            for (int i = 0; i < jumps; i++)
                damage /= 2;

            return damage;
        }
    }
}
