namespace Exercise_GraphTheoryTraversalAndShortestPaths
{
    /*
     4. Salaries
    We have a hierarchy between the employees in a company. 
    Employees can have one or several direct managers. People who manage nobody are called regular employees and 
    their salaries are 1. People who manage at least one employee are called managers. Each manager takes a salary
    which is equal to the sum of the salaries of their directly managed employees
    */
    //Input
    /*
     4
    NNYN
    NNYN
    NNNN
    NYYN
    */
    //Output
    /*
     5
    */

    internal static class Salaries
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> visited;

        public static void Solution()
        {
            var n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visited = new Dictionary<int, int>();

            for (int node = 0; node < n; node++)
            {
                graph[node] = new List<int>();

                var nodeChildren = Console.ReadLine();

                for (int child = 0; child < nodeChildren.Length; child++)
                    if (nodeChildren[child] == 'Y')
                        graph[node].Add(child);
            }

            var salary = 0;
            for (int node = 0; node < graph.Length; node++)
                salary += DFS(node);

            Console.WriteLine(salary);
        }
        private static int DFS(int node)
        {
            if (visited.ContainsKey(node))
                return visited[node];

            var salary = 0;

            if (graph[node].Count == 0)
                salary = 1;
            else
                foreach (var child in graph[node])
                    salary += DFS(child);

            visited[node] = salary;
            return salary;
        }
    }
}
