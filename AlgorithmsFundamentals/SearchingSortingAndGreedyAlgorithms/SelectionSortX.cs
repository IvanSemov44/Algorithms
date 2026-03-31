
namespace SearchingSortingAndGreedyAlgorithms
{
    internal class SelectionSortX
    {
        /*
        2. Selection Sort
        Write an implementation of Selection Sort. You should read an array of integers and sort them.
        Output
        • You should print out the sorted list in the format described below.
        Examples
        Input               Output
        5 4 3 2 1           1 2 3 4 3
         */

        public static void Solution()
        {

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            //int[] numbers = { 5, 4, 3, 2, 1, };

            SelectionSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
        private static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var min = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[min])
                    {
                        min = j;
                    }
                }

                Swap(numbers, i, min);
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
