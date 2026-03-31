using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingSortingAndGreedyAlgorithms
{
    internal class Quicksort
    {
        /*
         * 5. Quicksort
         Sort an array of elements using the famous quicksort.
         Examples
         Input               Output
         5 4 3 2 1           1 2 3 4 5
         1 4 2 -1 0         -1 0 1 2 4
         */
        public static void Solution()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            //int[] numbers = { 5, 4, 3, 2, 1, };

            QuickSort(numbers, 0, numbers.Length - 1);


            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void QuickSort(int[] numbers, int start, int end)
        {
            if (start >= end) return;

            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (numbers[left] > numbers[pivot] &&
                    numbers[right] < numbers[pivot])
                {
                    Swap(numbers, left, right);
                }

                if (numbers[left] <= numbers[pivot]) left++;

                if (numbers[right] >= numbers[pivot]) right--;
            }
            Swap(numbers, pivot, right);

            QuickSort(numbers, start, right - 1);
            QuickSort(numbers, right + 1, end);
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            int temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }

    }
}
