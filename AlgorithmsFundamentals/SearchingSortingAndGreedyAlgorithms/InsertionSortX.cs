
namespace SearchingSortingAndGreedyAlgorithms
{
    internal static class InsertionSortX
    {
        /*
        4. Insertion Sort
        Write an implementation of Insertion Sort. You should read an array of integers and sort them.
        Output
        • You should print out the sorted list in the format described below.

        Examples

        Input           Output
        5 4 3 2 1       1 2 3 4 5

         */

        public static void Solution()
        {
            int[] nums = Console.ReadLine()
               .Split()
               .Select(x => int.Parse(x))
               .ToArray();

            InsertionSort(nums);

            Console.WriteLine(string.Join(" ", nums));
        }

        private static void InsertionSort(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                var j = i;
                while (j > 0 && numbers[j - 1] > numbers[j])
                {
                    Swap(numbers, j, j - 1);
                    j--;
                }
            }
        }
        private static void Swap(int[] numbers, int first, int second)
        {
            int temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}
