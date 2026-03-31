namespace ExamPreparation
{
    internal class StringsMashup
    {
        private static string str;
        private static string[] combinations;
        public static void Solution()
        {
            var input = Console.ReadLine();

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            str = new string(charArray);
            
            var n = int.Parse(Console.ReadLine());

            combinations = new string[str.Length - 1];

            Combinations(0, 0);
        }

        private static void Combinations(int idx, int elementStartIdx)
        {
            if (idx >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementStartIdx; i < str.Length; i++)
            {
                combinations[idx] = str[i].ToString();
                Combinations(idx + 1, i);
            }
        }
    }
}
