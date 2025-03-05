namespace ExamPreparationAdvance
{
    public class EdgeRoad
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }
    }

    internal static class LeTourDeSofiaFromVideo
    {
        public static void Solution()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());
            var startNode = int.Parse(Console.ReadLine());

            var graph = new List<EdgeRoad>[nodes];

            for (int node = 0; node < nodes; node++)
                graph[node] = new List<EdgeRoad>();


            for (int i = 0; i < edges; i++)
            {
                var edgeParts = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edgeParts[0];

                graph[from].Add(new EdgeRoad
                {
                    From = from,
                    To = edgeParts[1],
                    Weight = edgeParts[2]
                });
            }

            var distance = new double[graph.Length];

            for (int i = 0; i < distance.Length; i++)
                distance[i] = double.PositiveInfinity;

            var queue = new PriorityQueue<int, double>();

            foreach (var edge in graph[startNode])
            {
                distance[edge.To] = edge.Weight;
                queue.Enqueue(edge.To, distance[edge.To]);
            }

            while (queue.Count > 0)
            {
                var minNode = queue.Dequeue();

                if (minNode == startNode)
                    break;

                foreach (var edge in graph[minNode])
                {
                    if (double.IsPositiveInfinity(distance[edge.To]))
                        queue.Enqueue(edge.To, distance[edge.To]);

                    var newDistance = edge.Weight + distance[minNode];

                    if (newDistance < distance[edge.To])
                        distance[edge.To] = newDistance;
                }
            }

            if (double.IsPositiveInfinity(distance[startNode]))
                Console.WriteLine(distance.Count(x => !double.IsPositiveInfinity(x)) + 1);
            else
                Console.WriteLine(distance[startNode]);
        }
    }
}
