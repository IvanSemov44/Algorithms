
namespace SearchingSortingAndGreedyAlgorithms
{
    /* 1. Binary Search
        Implement an algorithm that finds the index of an element in a sorted array of integers in logarithmic time.
        Examples
        Input            Output              Comments
        1 2 3 4 5        1                   0
        -1 0 1 2 4       1                   2
        1
        2 Index of 1 is 2
     */
    internal static class BinarySearchX
    {
        public static void Solution()
        {
            int[] nums = Console.ReadLine()
               .Split()
               .Select(x => int.Parse(x))
               .ToArray();

            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(nums, num));
        }

        private static int BinarySearch(int[] nums, int number)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (nums[mid] == number)
                    return mid;

                if (number > nums[mid])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }
    }
}
