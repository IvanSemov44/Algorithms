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

            //4.Insertion Sort
            //InsertionSortX.Solution();

            //5. Quicksort
            //Quicksort.Solution();


            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            //int[] numbers = { 5, 4, 3, 2, 1, };


            Console.WriteLine(string.Join(" ", numbers));
        }


        private static void Swap(int[] numbers, int first, int second)
        {
            int temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }

    }
}
