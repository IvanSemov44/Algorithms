
namespace SearchingSortingAndGreedyAlgorithms
{
    /*
    * 3. Bubble Sort
    Write an implementation of Bubble Sort. You should read an array of integers and sort them.
    Output

    • You should print out the sorted list in the format described below.

    Examples

    Input               Output
    5 4 3 2 1           1 2 3 4 5
    */
    internal class BubbleSort
    {
        public static void Solution()
        {
            int[] nums = Console.ReadLine()
               .Split()
               .Select(x => int.Parse(x))
               .ToArray();

            int num = int.Parse(Console.ReadLine());

            BubleSort(nums);

            Console.WriteLine(string.Join(" ", nums));
        }
        private static void BubleSort(int[] numbers)
        {
            var sortedCount = 0;
            var isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                for (int j = 1; j < numbers.Length - sortedCount; j++)
                {
                    int i = j - 1;

                    if (numbers[i] > numbers[j])
                    {
                        Swap(numbers, i, j);
                        isSorted = false;
                    }
                }
                sortedCount++;
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
