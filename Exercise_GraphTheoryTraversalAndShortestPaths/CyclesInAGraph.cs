using System.ComponentModel;

namespace Exercise_GraphTheoryTraversalAndShortestPaths
{
    /*
  3. ;
Write a program to check whether a directed graph is acyclic or holds any cycles. The input ends with "End" line.
    */
    //Input
    /*
    A-F
    F-D
    D-A
    End
    */
    //Output -->Acyclic: No

    internal static class CyclesInAGraph
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;

        public static void Solution()
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "End")
                    break;

                var edge = line.Split("-");
                var from = edge[0];
                var to = edge[1];

                if (!graph.ContainsKey(from))
                    graph.Add(from, new List<string>());

                if (!graph.ContainsKey(to))
                    graph.Add(to, new List<string>());

                graph[from].Add(to);
            }

            try
            {
                foreach (var node in graph.Keys)
                    DFS(node);

                Console.WriteLine("Acyclic: Yes");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Acyclic: No");
            }
        }
        private static void DFS(string node)
        {
            if (cycles.Contains(node))
                throw new InvalidOperationException();

            if (visited.Contains(node))
                return;

            visited.Add(node);
            cycles.Add(node);

            foreach (var child in graph[node])
                DFS(child);

            cycles.Remove(node);
        }
    }
}
