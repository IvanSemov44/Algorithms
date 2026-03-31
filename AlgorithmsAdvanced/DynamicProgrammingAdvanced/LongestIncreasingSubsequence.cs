namespace DynamicProgrammingAdvanced
{
    internal static class LongestIncreasingSubsequence
    {
        public static void Solution()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var length = new int[numbers.Length];
            var parent = new int[numbers.Length];

            var bestLength = 0;
            var bestIdx = 0;

            for (int current = 0; current < numbers.Length; current++)
            {
                var currentNumber = numbers[current];
                var currentLength = 1;
                var currentParent = -1;

                for (int prev = current - 1; prev >= 0; prev--)
                {
                    var prevNumber = numbers[prev];
                    var prevLength = length[prev];

                    if (currentNumber > prevNumber &&
                        prevLength + 1 >= currentLength)
                    {
                        currentLength = prevLength + 1;
                        currentParent = prev;
                    }
                }

                length[current] = currentLength;
                parent[current] = currentParent;

                //in case not uniq lis, we take most right with comment code
                //if (currentLength >= bestLength)
                //most left
                if (currentLength > bestLength)
                {
                    bestLength = currentLength;
                    bestIdx = current;
                }
            }

            var lis = new Stack<int>();

            while (bestIdx != -1)
            {
                lis.Push(numbers[bestIdx]);
                bestIdx = parent[bestIdx];
            }

            Console.WriteLine(string.Join(" ", lis));
            Console.WriteLine(bestLength);
        }
    }
}
