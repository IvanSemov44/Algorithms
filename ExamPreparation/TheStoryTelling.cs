namespace ExamPreparation
{
    internal static class TheStoryTelling
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> passedNodes;

        public static void Solution()
        {
            graph = ReadGraph();
            passedNodes = new HashSet<string>();

            foreach (string parentNode in graph.Keys)
                DFSGraph(parentNode);

            Console.WriteLine(string.Join(" ", passedNodes.Reverse()));
        }

        private static void DFSGraph(string parentNode)
        {
            if (passedNodes.Contains(parentNode))
                return;

            foreach (string childNode in graph[parentNode])
                DFSGraph(childNode);

            passedNodes.Add(parentNode);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var result = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var parts = command
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var key = parts[0];

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
