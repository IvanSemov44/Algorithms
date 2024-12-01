using System;
using System.Linq;

namespace SearchingSortingAndGreedyAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Binary Search
            //BinarySearchX.Solution();

            // 2. Selection Sort
            //SelectionSortX.Solution();

            //3. Bubble Sort 
            //BubbleSort.Solution();

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            //int[] numbers = { 5, 4, 3, 2, 1, };

            BubleSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void BubleSort(int[] numbers)
        {
            var sortedCount = 0;
            var isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                for (int j = 1; j < numbers.Length-sortedCount; j++)
                {
                    int i = j - 1;

                    if(numbers[i] > numbers[j])
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
