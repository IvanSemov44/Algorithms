namespace CombinatorialProblems
{

    //    4. Variations with Repetition
    //Given a set of elements, find all variations of k elements with repetitions.

    //Examples

    //Input
    //A B C
    //2

    //Output
    //A A
    //A B
    //A C
    //B A
    //B B
    //B C
    //C A
    //C B
    //C C

    internal class VariationsWithRepetition
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

            Variations(0);
        }

        private static void Variations(int idx)
        {
            if (idx >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                    variations[idx] = elements[i];
                    Variations(idx + 1);
            }
        }
    }
}
