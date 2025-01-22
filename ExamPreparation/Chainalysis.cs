namespace ExamPreparation
{
    internal static class Chainalysis
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> passed;

        public static void Solution()
        {
            int n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);
            passed = new HashSet<string>();

            var count = 0;
            foreach (var node in graph.Keys)
            {
                if (passed.Contains(node))
                    continue;

                count++;

                DFS(node);
            }

            Console.WriteLine(count);

        }

        private static void DFS(string node)
        {
            if (passed.Contains(node))
                return;

            foreach (var child in graph[node])
                DFS(child);

            passed.Add(node);
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToArray();

                var key = input[0];

                if (!result.ContainsKey(key))
                    result[key] = new List<string>();

                result[key].Add(input[1]);

                if (!result.ContainsKey(input[1]))
                    result[input[1]] = new List<string>();
            }

            return result;
        }
    }
}
