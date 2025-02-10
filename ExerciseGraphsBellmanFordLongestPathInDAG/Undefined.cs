namespace ExerciseGraphsBellmanFordLongestPathInDAG
{
    internal static class Undefined
    {
        public static void Solution()
        {
            var nodes = int.Parse(Console.ReadLine()) + 1;
            var edges = int.Parse(Console.ReadLine());

            var graph = new List<Edge>();

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                graph.Add(new Edge
                {
                    First = edgeData[0],
                    Second = edgeData[1],
                    Weight = edgeData[2]
                });
            }

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distance = new double[nodes];
            var prev = new int[nodes];

            for (int node = 0; node < nodes; node++)
            {
                distance[node] = double.PositiveInfinity;
                prev[node] = -1;
            }

            distance[source] = 0;

            for (int i = 0; i < nodes - 2; i++)
            {
                var updated = false;

                foreach (var edge in graph)
                {
                    if (double.IsPositiveInfinity(distance[edge.First]))
                        continue;

                    var newDistance = distance[edge.First] + edge.Weight;

                    if (newDistance < distance[edge.Second])
                    {
                        distance[edge.Second] = newDistance;
                        prev[edge.Second] = edge.First;
                        updated = true;
                    }
                }

                if (!updated)
                    break;
            }

            foreach (var edge in graph)
            {
                var newDistance = distance[edge.First] + edge.Weight;

                if (newDistance < distance[edge.Second])
                {
                    Console.WriteLine("Undefined");
                    return;
                }
            }

            var path = new Stack<int>();
            var currentNode = destination;

            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = prev[currentNode];
            }

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distance[destination]);
        }
    }
}
