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

    internal class PermutationsWithoutRepetitionWithUsingExtraMemory
    {
        private static string[] elements;

        public static void Solution()
        {
            elements = new[] { "A", "B", "C" };

            Permute(0);
        }
        private static void Permute(int idx)
        {
            if (idx >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(idx + 1);

            for (int i = idx + 1; i < elements.Length; i++)
            {
                Swap(idx, i);
                Permute(idx + 1);
                Swap(idx, i);

            }
        }

        private static void Swap(int first, int second)
        {
            //(elements[first], elements[second]) = (elements[second], elements[first]);
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
