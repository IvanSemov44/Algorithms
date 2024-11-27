namespace CombinatorialProblems
{
    //1. Permutations without Repetitions
    //Given a set of elements, find all permutations without repetitions.

    //Examples

    //Input: A B C
    //Output:
    //A B C  
    //A C B
    //B A C
    //B C A
    //C B A
    //C A B
    //--------
    //Input: A B
    //Output:
    //A B
    //B A
    internal static class PermutationsWithoutRepetition
    {
        private static string[] elements;
        private static string[] permutations;
        private static bool[] used;

        public static void Solution()
        {
            //elements = new[] { "A", "B", "C" };
            elements = new[] { "A", "B" };
            permutations = new string[elements.Length];
            used = new bool[elements.Length];

            Permute(0);
        }
        private static void Permute(int idx)
        {
            if (idx >= permutations.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutations[idx] = elements[i];
                    Permute(idx + 1);
                    used[i] = false;
                }
            }
        }
    }
}
