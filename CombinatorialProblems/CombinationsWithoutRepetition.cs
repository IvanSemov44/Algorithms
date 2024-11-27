namespace CombinatorialProblems
{
    //    5. Combinations without Repetition
    //Given a set of elements, generate all combinations of k elements without repetition.

    //Examples

    //Input
    //A B C
    //2

    //Output
    //A B
    //A C
    //B C

    internal class CombinationsWithoutRepetition
    {
        private static int k;
        private static string[] elements;
        private static string[] variations;

        public static void Solution()
        {
            elements = new[] { "A", "B", "C" };
            k = 2;
            //elements = Console.ReadLine().Split();
            //k = int.Parse(Console.ReadLine());

            variations = new string[k];

            Combinations(0, 0);
        }
        private static void Combinations(int idx, int elementsStartIdx)
        {
            if (idx >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = elementsStartIdx; i < elements.Length; i++)
            {
                variations[idx] = elements[i];
                Combinations(idx + 1, i + 1);
            }
        }
    }
}
