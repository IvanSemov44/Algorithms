namespace ExamPreparation
{
    internal class Rumors
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parent;

        public static void Solution()
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            graph = new List<int>[n + 1];
            GenerateDefault();

            for (int node = 0; node < graph.Length; node++)
                graph[node] = new List<int>();

            for (int i = 0; i < e; i++)
            {
                var edge = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            var x = int.Parse(Console.ReadLine());

            for (int destination = 1; x < graph.Length; destination++)
            {
                if (x == destination)
                    continue;

                BFS(x, destination);
            }
        }

        private static void GenerateDefault()
        {
            visited = new bool[graph.Length];
            parent = new int[graph.Length];
            Array.Fill(parent, -1);
        }

        private static void BFS(int x, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(x);

            visited[x] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    var path = GetPath(destination);
                    Console.WriteLine($"{x} -> {destination} ({path.Count - 1})");
                    GenerateDefault();
                    break;
                }

                foreach (var child in graph[node])
                    if (!visited[child])
                    {
                        parent[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
            }
        }

        private static Stack<int> GetPath(int destination)
        {
            var path = new Stack<int>();
            var node = destination;

            while (node != -1)
            {
                path.Push(node);
                node = parent[node];
            }

            return path;
        }
    }
}
