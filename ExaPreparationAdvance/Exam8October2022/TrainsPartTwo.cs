namespace ExamPreparationAdvance.Exam8October2022
{
    public class EdgeTrack
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }

    internal static class TrainsPartTwo
    {
        private static Dictionary<int, List<EdgeTrack>> graph;
        private static double[] distance;
        private static int[] parent;

        public static void Solution()
        {
            var depots = int.Parse(Console.ReadLine());
            var tracks = int.Parse(Console.ReadLine());
            var startEnd = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var start = startEnd[0];
            var end = startEnd[1];

            graph = new Dictionary<int, List<EdgeTrack>>();

            ReadGraph(tracks);
            InitializeDistanceAndParent();
            Dijkstra(start);
            PrintGraph(end);
        }

        private static void PrintGraph(int end)
        {
            var path = new Stack<int>();
            var currentNode = end;

            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = parent[currentNode];
            }

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distance[end]);
        }

        private static void Dijkstra(int start)
        {
            distance[start] = 0;
            var queue = new PriorityQueue<int, double>();

            queue.Enqueue(start, distance[start]);

            while (queue.Count > 0)
            {
                var minNode = queue.Dequeue();

                if (double.IsPositiveInfinity(distance[minNode]))
                    break;

                foreach (var edge in graph[minNode])
                {
                    var otherNode = edge.First == minNode
                        ? edge.Second
                        : edge.First;

                    if (double.IsPositiveInfinity(distance[otherNode]))
                        queue.Enqueue(otherNode, distance[otherNode]);

                    var newDistance = edge.Weight + distance[minNode];

                    if (newDistance < distance[otherNode])
                    {
                        distance[otherNode] = newDistance;
                        parent[otherNode] = minNode;
                    }
                }
            }
        }

        private static void InitializeDistanceAndParent()
        {
            var max = graph.Keys.Max() + 1;

            distance = new double[max];
            parent = new int[max];

            for (int i = 0; i < max; i++)
            {
                distance[i] = double.PositiveInfinity;
                parent[i] = -1;
            }
        }

        private static void ReadGraph(int tracks)
        {
            for (int track = 0; track < tracks; track++)
            {
                var trackData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var first = trackData[0];
                var second = trackData[1];

                var edge = new EdgeTrack
                {
                    First = first,
                    Second = second,
                    Weight = trackData[2]
                };

                if (!graph.ContainsKey(first))
                    graph[first] = new List<EdgeTrack>();

                if (!graph.ContainsKey(second))
                    graph[second] = new List<EdgeTrack>();

                graph[first].Add(edge);
                graph[second].Add(edge);
            }
        }
    }
}
