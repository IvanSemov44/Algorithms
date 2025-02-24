namespace ExerciseGraphsStronglyConnectedComponentsMaxFlow
{
    internal static class FindBiConnectedComponents
    {
        private static List<int>[] graph;
        private static int[] depth;
        private static int[] lowpoint;
        private static bool[] visited;
        private static int[] parent;

        private static Stack<int> stack;
        private static List<HashSet<int>> components;

        public static void Solution()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];
            depth = new int[graph.Length];
            lowpoint = new int[graph.Length];
            visited = new bool[graph.Length];
            parent = new int[graph.Length];
            stack = new Stack<int>();
            components = new List<HashSet<int>>();

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
                parent[node] = -1;
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondSode = edgeData[1];

                graph[firstNode].Add(secondSode);
                graph[secondSode].Add(firstNode);
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                    continue;

                FindArticulationPoints(node, 1);

                var lastComponent = stack.ToHashSet();
                components.Add(lastComponent);
            }
            Console.WriteLine("Number of biconnected components: " + components.Count);
        }

        private static void FindArticulationPoints(int node, int currentDepth)
        {
            visited[node] = true;
            depth[node] = currentDepth;
            lowpoint[node] = currentDepth;

            var childCount = 0;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    stack.Push(node);
                    stack.Push(child);

                    parent[child] = node;

                    FindArticulationPoints(child, currentDepth + 1);

                    childCount += 1;

                    if ((parent[node] != -1 && lowpoint[child] >= depth[node]) ||
                        (parent[node] == -1 && childCount > 1))
                    {
                        var component = new HashSet<int>();
                        while (true)
                        {
                            var stackChild = stack.Pop();
                            var stackNode = stack.Pop();

                            component.Add(stackNode);
                            component.Add(stackChild);

                            if (stackNode == node &&
                                stackChild == child)
                            {
                                break;
                            }
                        }

                        components.Add(component);
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
                }
                else if (parent[node] != child &&
                    depth[child] < lowpoint[node])
                {
                    lowpoint[node] = depth[child];

                    stack.Push(node);
                    stack.Push(child);
                }
            }
        }
    }
}
