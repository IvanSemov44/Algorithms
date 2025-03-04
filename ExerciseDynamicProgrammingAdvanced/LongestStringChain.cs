namespace ExerciseDynamicProgrammingAdvanced
{
    internal class LongestStringChain
    {
        public static void Solution()
        {
            var words = Console.ReadLine().Split();

            var bestLength = new int[words.Length];
            var parent = new int[words.Length];
            var maxLength = 0;
            var lastIdx = 0;

            for (int current = 0; current < words.Length; current++)
            {
                var currentStr = words[current];
                var currentBestLength = 1;
                var currentParent = -1;

                for (int prev = current - 1; prev >= 0; prev--)
                {
                    var prevStr = words[prev];
                    var prevLen = bestLength[prev];

                    if (currentStr.Length > prevStr.Length &&
                        prevLen + 1 >= currentBestLength)
                    {
                        currentBestLength = prevLen + 1;
                        currentParent = prev;
                    }
                }

                bestLength[current] = currentBestLength;
                parent[current] = currentParent;

                if (currentBestLength > maxLength)
                {
                    maxLength = currentBestLength;
                    lastIdx = current;
                }
            }

            var chain = new Stack<string>();

            while (lastIdx != -1)
            {
                var str = words[lastIdx];
                chain.Push(str);
                lastIdx = parent[lastIdx];
            }

            Console.WriteLine(string.Join(" ", chain));
        }
    }
}
