namespace GraphTheoryTraversalAndShortest
{
    //https://judge.softuni.org/Contests/Practice/DownloadResource/33719

    /*
      1. Connected Components
    The first part of this lab aims to implement the DFS algorithm (Depth-First-Search) to traverse a graph and find its
    connected components (nodes connected either directly, or through other nodes). The graph nodes are numbered
    from 0 to n-1. The graph comes from the console in the following format:
        • First line: number of lines n
        • Next n lines: list of child nodes for the nodes 0 … n-1 (separated by a space)
     */

    internal class ConnectedComponents
    {
        private static List<int>[] graph;
        private static bool[] visited;

        public static void Solution()
        {
            var n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited = new bool[n];

            for (int node = 0; node < n; node++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                    graph[node] = new List<int>();
                else
                {
                    var children = line.Split()
                        .Select(int.Parse)
                        .ToList();

                    graph[node] = children;
                }
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node]) continue;

                var component = new List<int>();
                DSF(node, component);

                Console.WriteLine($"Connected component: {string.Join(" ", component)}");
            }
        }

        private static void DSF(int node, List<int> component)
        {
            if (visited[node]) return;

            visited[node] = true;

            foreach (var child in graph[node])
                DSF(child, component);

            component.Add(node);
        }
    }
}
