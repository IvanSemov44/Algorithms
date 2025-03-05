namespace ExamPreparationAdvance
{
    internal static class RoadTrip
    {
        public static void Solution()
        {
            var value = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var space = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var maxCapacity = int.Parse(Console.ReadLine());

            var dp = new int[value.Length + 1, maxCapacity + 1];

            for (int itemIdx = 1; itemIdx < dp.GetLength(0); itemIdx++)
            {
                var itemValue = value[itemIdx - 1];
                var itemSpace = space[itemIdx - 1];

                for (int capacity = 0; capacity < dp.GetLength(1); capacity++)
                {
                    var excluding = dp[itemIdx - 1, capacity];

                    if (itemSpace > capacity)
                    {
                        dp[itemIdx, capacity] = excluding;
                        continue;
                    }

                    var incluing = itemValue + dp[itemIdx - 1, capacity - itemSpace];

                    dp[itemIdx, capacity] = Math.Max(excluding, incluing);
                }
            }

            Console.WriteLine("Maximum value: " + dp[value.Length, maxCapacity]);
        }
    }
}
