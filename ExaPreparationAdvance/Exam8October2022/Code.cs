namespace ExamPreparationAdvance.Exam8October2022
{
    internal static class Code
    {
        public static void Solution()
        {
            var first = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var second = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            var lcs = new int[first.Length + 1, second.Length + 1];

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                    }
                }
            }

            var message = new int[lcs[first.Length, second.Length]];

            var x = first.Length;
            var y = second.Length;
            var idx = message.Length - 1;

            while (x > 0 && y > 0)
            {
                if (first[x - 1] == second[y - 1])
                {
                    message[idx] = first[x - 1];
                    idx--;
                    x--;
                    y--;
                }
                else if (lcs[x - 1, y] > lcs[x, y - 1])
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }

            Console.WriteLine(string.Join(" ", message));
            Console.WriteLine(message.Length);
        }
    }
}
