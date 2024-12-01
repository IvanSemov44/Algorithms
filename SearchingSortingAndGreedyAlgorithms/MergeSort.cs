namespace SearchingSortingAndGreedyAlgorithms
{
    /*
     * 6. Merge Sort
        Sort an array of elements using the famous merge sort.
        Examples
        Input        Output
        5 4 3 2 1    1 2 3 4 5
     */
    internal static class MergeSort
    {
        public static void Solution()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var sorted = MergeSortX(numbers);


            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSortX(int[] numbers)
        {
            if (numbers.Length <= 1) return numbers;

            var left = numbers.Take(numbers.Length / 2).ToArray();
            var right = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MergeSortX(left), MergeSortX(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];

            var mergedIdx = 0;
            var leftIdx = 0;
            var rightIdx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
                if (left[leftIdx] < right[rightIdx])
                    merged[mergedIdx++] = left[leftIdx++];
                else
                    merged[mergedIdx++] = right[rightIdx++];

            for (int i = leftIdx; i < left.Length; i++)
                merged[mergedIdx++] = left[i];


            for (int i = rightIdx; i < right.Length; i++)
                merged[mergedIdx++] = right[i];

            return merged;
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            int temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}
