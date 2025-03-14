namespace ExamPreparationAdvance.Exam19August2023
{
    public class EdgeTrack
    {
        public char First { get; set; }
        public char Second { get; set; }
        public int Influence { get; set; }
    }

    internal static  class SocialMediaTracker
    {
        public static void Solution()
        {
            var edges = int.Parse(Console.ReadLine());

            var graph = new Dictionary<char, List<EdgeTrack>>();
            var influence = new Dictionary<char, double>();
            var parent = new Dictionary<char, char>();

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .ToArray();

                var first = char.Parse(edgeData[0]);
                var second = char.Parse(edgeData[1]);

                var edge = new EdgeTrack
                {
                    First = first,
                    Second = second,
                    Influence = int.Parse(edgeData[2])
                };

                if (!graph.ContainsKey(first))
                    graph[first] = new List<EdgeTrack>();

                if (!graph.ContainsKey(second))
                    graph[second] = new List<EdgeTrack>();

                influence[first] = double.NegativeInfinity;
                influence[second] = double.NegativeInfinity;

                graph[first].Add(edge);
            }

            var start = char.Parse(Console.ReadLine());
            var end = char.Parse(Console.ReadLine());

            parent[start] = '0';

            influence[start] = 0;

            var maxHeap = new PriorityQueue<char, double>
                (Comparer<double>.Create((x, y) => y.CompareTo(x)));

            maxHeap.Enqueue(start, influence[start]);

            while (maxHeap.Count > 0)
            {
                var minNode = maxHeap.Dequeue();

                foreach (var edge in graph[minNode])
                {
                    var otherNode = edge.First == minNode
                        ? edge.Second
                        : edge.First;

                    //if (double.IsNegativeInfinity(distance[otherNode]))
                    maxHeap.Enqueue(otherNode, influence[otherNode]);

                    var newDistance = influence[minNode] + edge.Influence;

                    //If condition was for max hops
                    //if (newDistance >= distance[otherNode])

                    if (newDistance > influence[otherNode])
                    {
                        parent[otherNode] = minNode;
                        influence[otherNode] = newDistance;
                    }
                }
            }

            var currentNode = end;
            var path = new Stack<char>();

            while (!char.IsDigit(currentNode))
            {
                path.Push(currentNode);
                currentNode = parent[currentNode];
            }

            Console.WriteLine("(" + influence[end] + "," + (path.Count - 1) + ")");
        }
    }
}
