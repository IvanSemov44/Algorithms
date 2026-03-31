namespace DynamicProgrammingAdvanced
{
    internal static class RodCutting
    {
        private static int[] memo;
        private static int[] prev;
         
        public static void Solution()
        {
            var price = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            memo = new int[price.Length];
            prev = new int[price.Length];

            var length = int.Parse(Console.ReadLine());

            var bestPrice = CutRod(price, length);

            Console.WriteLine(bestPrice);

            var parts = new List<int>();

            while (length != 0)
            {
                var currentPrev = prev[length];
                parts.Add(currentPrev);
                length -= currentPrev;
            }

            Console.WriteLine(string.Join(" ", parts));
        }

        private static int CutRod(int[] price, int length)
        {
            if (length == 0)
                return 0;

            if (memo[length] != 0)
                return memo[length];

            var bestPrice = price[length];  
            var bestCombo = length;

            for (var i = 1; i < length; i++)
            {
                var currentPrice = price[i] + CutRod(price, length - i);

                if (currentPrice > bestPrice)
                {
                    bestPrice = currentPrice;
                    bestCombo = i;
                }
            }

            memo[length] = bestPrice;
            prev[length] = bestCombo;

            return bestPrice;
        }
    }
}
