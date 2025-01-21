namespace ExamPreparation
{
    internal  static class TheStoryTelling
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;

        public static void Solution()
        {
            graph = ReadGraph();
            dependencies = ExtractDependencies(graph);
            var sorted = TopologicalSorted(dependencies);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static List<string> TopologicalSorted(Dictionary<string, int> dependencies)
        {
            var sorted = new List<string>();

            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies.FirstOrDefault(x => x.Value == 0).Key;

                if (nodeToRemove == null)
                    break;

                dependencies.Remove(nodeToRemove);
                sorted.Add(nodeToRemove);

                foreach (var child in graph[nodeToRemove])
                    dependencies[child] -= 1;
            }

            return sorted;
        }

        private static Dictionary<string, int> ExtractDependencies(Dictionary<string, List<string>> graph)
        {
            var result = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                if (!result.ContainsKey(node))
                    result[node] = 0;

                foreach (var child in children)
                    if (!result.ContainsKey(child))
                        result[child] = 1;
                    else
                        result[child]++;
            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var result = new Dictionary<string, List<string>>();

            while (true)
            {
                var parts = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var key = parts[0];

                if (key == "End") break;

                if (parts.Length == 1)
                {
                    result[key] = new List<string>();
                }
                else
                {
                    var children = parts[1].Split().ToList();
                    result[key] = children;
                }
            }

            return result;
        }
    }
}
