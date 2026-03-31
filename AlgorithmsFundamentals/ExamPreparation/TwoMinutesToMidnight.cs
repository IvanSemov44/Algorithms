namespace ExamPreparation
{
    internal class TwoMinutesToMidnight
    {
        private static Dictionary<string, ulong> cache;
        public static void Solution()
        {
            cache = new Dictionary<string, ulong>();

            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            Console.WriteLine(GetBinom(n, k));
        }

        private static ulong GetBinom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
                return 1;

            string identifier = $"{row}-{col}";

            if (cache.ContainsKey(identifier))
                return cache[identifier];

            var result = GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
            cache[identifier] = result;

            return result;
        }
    }
}
