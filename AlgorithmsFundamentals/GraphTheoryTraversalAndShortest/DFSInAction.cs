namespace GraphTheoryTraversalAndShortest
{
    //Depth-First-Search
    internal class DFSInAction
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;

        public static void Solution()
        {
            graph = new Dictionary<int, List<int>>()
            {
                { 1, new List<int>()  { 19, 21, 14 } },
                { 19, new List<int>() { 7, 12, 31, 23 } },
                { 7, new List<int>()  { 1 } },
                { 31, new List<int>() { 21 } },
                { 21, new List<int>() { 14 } },
                { 23, new List<int>() { 21 } },
                { 14, new List<int>() { 23, 6} },
                { 12, new List<int>() },
                { 6, new List<int>() },
            };

            visited = new HashSet<int>();

            foreach (var node in graph.Keys) Dfs(node);
        }

        private static void Dfs(int node)
        {
            if (visited.Contains(node)) return;

            visited.Add(node);

            foreach (var child in graph[node]) Dfs(child);

            Console.WriteLine(node);
        }
    }
}
