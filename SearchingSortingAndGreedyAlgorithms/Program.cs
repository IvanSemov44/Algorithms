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

            //8. Set Cover
            //SetCover.Solution();

            var universe = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToHashSet();

            var n = int.Parse(Console.ReadLine());

            var sets = new List<int[]>();

            for (int i = 0; i < n; i++)
            {
                var set = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                sets.Add(set);
            }
            var selectedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                var set = sets
                    .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                    .FirstOrDefault();

                selectedSets.Add(set);
                sets.Remove(set);

                foreach (var element in set)
                {
                    universe.Remove(element);
                }
            }

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (var set in selectedSets)
            {
                Console.WriteLine(string.Join(", ", set));
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
