namespace ExamPreparationAdvance
{
    internal class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }

    internal class LeTourDeSofia
    {
        private static Dictionary<int, List<Edge>> streetsByEdge;
        private static double[] distance;
        private static int[] parent;
        private static StreamReader str;
        private static int streets;
        private static int source;
        private static int lastReachedNode;

        public static void Solution()
        {
            //str = new StreamReader("C:\\Users\\ivans\\source\\repos\\RecurtionAndBacktracking\\ExaPreparationAdvance\\input.txt");

            //var junctions = int.Parse(str.ReadLine());
            //streets = int.Parse(str.ReadLine());
            //var source = int.Parse(str.ReadLine());

            var junctions = int.Parse(Console.ReadLine());
            streets = int.Parse(Console.ReadLine());
            source = int.Parse(Console.ReadLine());

            streetsByEdge = new Dictionary<int, List<Edge>>();

            ReadGraph();
            InitializeDistanceAndParent();
            Dijkstra();
            PrintGraph();
        }

        private static void PrintGraph()
        {
            if (distance[source] == 0)
            {
                var currentNode = lastReachedNode;
                var path = new Stack<int>();

                while (currentNode != source)
                {
                    path.Push(currentNode);
                    currentNode = parent[currentNode];
                }

                path.Push(source);

                //Console.WriteLine(lastReachedNode);
                Console.WriteLine("There is no route for Pierre. Junctions that can be reached: ");
                Console.WriteLine(string.Join(" -> ", path));

            }
            else
            {
                var currentNode = source;
                var path = new Stack<int>();

                do
                {
                    path.Push(currentNode);
                    currentNode = parent[currentNode];
                }
                while (currentNode != source);

                path.Push(source);

                //Console.WriteLine(distance[source]);
                Console.WriteLine($"The shortest route starting at {source} is:");
                Console.WriteLine(string.Join(" -> ", path));
            }
        }

        private static void Dijkstra()
        {
            distance[source] = 0;

            var queue = new PriorityQueue<int, double>();

            queue.Enqueue(source, distance[source]);

            while (queue.Count > 0)
            {
                var minNode = queue.Dequeue();

                if (double.IsPositiveInfinity(minNode))
                    break;

                foreach (var edge in streetsByEdge[minNode])
                {
                    var otherNode = edge.First == minNode
                        ? edge.Second
                        : edge.First;

                    if (double.IsPositiveInfinity(distance[otherNode]))
                    {
                        queue.Enqueue(otherNode, distance[otherNode]);
                        lastReachedNode = otherNode;
                    }

                    var newDistance = distance[minNode] + edge.Weight;

                    if (newDistance < distance[otherNode] ||
                        otherNode == source && distance[source] == 0)
                    {
                        parent[otherNode] = minNode;
                        distance[otherNode] = newDistance;
                    }
                }
            }
        }

        private static void InitializeDistanceAndParent()
        {
            var biggestNode = streetsByEdge.Keys.Max() + 1;

            distance = new double[biggestNode];
            parent = new int[biggestNode];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
                parent[i] = -1;
            }
        }

        private static void ReadGraph()
        {
            for (int i = 0; i < streets; i++)
            {
                //var streetData = str.ReadLine()
                //    .Split()
                //    .Select(int.Parse)
                //    .ToArray();

                var streetData = Console.ReadLine()
                   .Split()
                   .Select(int.Parse)
                   .ToArray();

                var first = streetData[0];
                var second = streetData[1];

                if (!streetsByEdge.ContainsKey(first))
                    streetsByEdge.Add(first, new List<Edge>());

                if (!streetsByEdge.ContainsKey(second))
                    streetsByEdge.Add(second, new List<Edge>());

                var street = new Edge
                {
                    First = first,
                    Second = second,
                    Weight = streetData[2]
                };

                streetsByEdge[first].Add(street);
            }
        }
    }
}