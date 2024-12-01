using System;
using System.Linq;
using System.Collections.Generic;

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

            //6. Merge Sort
            //MergeSort.Solution();
            
            //7. Sum of Coins
            //SumOfCoins.Solution();
        }



        private static void Swap(int[] numbers, int first, int second)
        {
            int temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}
