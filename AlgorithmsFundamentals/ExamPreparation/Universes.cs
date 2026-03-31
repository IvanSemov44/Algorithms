namespace ExamPreparation
{
    internal class Universes
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        public static void Solution()
        {
            int n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);
            visited = new HashSet<string>();

            int count = 0;

            foreach (string node in graph.Keys)
            {
                if (visited.Contains(node))
                    continue;

                DFS(node);

                count++;
            }
            Console.WriteLine(count);
        }

        private static void DFS(string node)
        {
            if (visited.Contains(node)) 
                return;

            foreach (var child in graph[node])
                DFS(child);

            visited.Add(node);
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split("-", StringSplitOptions.TrimEntries)
                    .ToArray();

                var key = input[0];
                var value = input[1];

                if (!result.ContainsKey(key))
                    result[key] = new List<string>();

                result[key].Add(value);

                if (!result.ContainsKey(value))
                    result[value] = new List<string>();
            }

            return result;
        }
    }
}
