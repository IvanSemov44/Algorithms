
namespace CombinatorialProblems
{
    //2. Permutations with Repetitions
    //Given a multi-set of elements, find all permutations.

    //Examples

    //Input:
    //A B B

    //Output:
    //A B B
    //B A B
    //B B A


    internal class PermutationsWithRepetition
    {
        private static string[] elements;

        public static void Solution()
        {
            elements = new[] { "A", "B", "B" };

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

            var used = new HashSet<string>() { elements[idx] };

            for (int i = idx + 1; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i]))
                {
                    Swap(idx, i);
                    Permute(idx + 1);
                    Swap(idx, i);

                    used.Add(elements[i]);
                }

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
