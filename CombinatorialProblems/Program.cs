
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CombinatorialProblems
{
    //Problems Description here: https://judge.softuni.org/Contests/Practice/DownloadResource/33716
    internal class Program
    {
        private static int k;
        private static string[] elements;
        private static string[] variations;

        static void Main(string[] args)
        {
            //1. Permutations without Repetitions
            //PermutationsWithoutRepetition.Solution();
            //PermutationsWithoutRepetitionWithUsingExtraMemory.Solution();

            //2. Permutations with Repetitions
            //PermutationsWithRepetition.Solution();

            //3. Variations without Repetitions
            //VariationsWithoutRepetition.Solution();

            //4. Variations with Repetition
            //VariationsWithRepetition.Solution();

            //elements = new[] { "A", "B", "C" };
            //k = 2;

            //5. Combinations without Repetition
            //CombinationsWithoutRepetition.Solution();

            //elements = Console.ReadLine().Split();
            //k = int.Parse(Console.ReadLine());

            variations = new string[k];

            Combinations(0, 0);

        }
        private static void Combinations(int idx, int elementsStartIdx)
        {
            if (idx >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = elementsStartIdx; i < elements.Length; i++)
            {
                variations[idx] = elements[i];
                Combinations(idx + 1, i + 1);
            }
        }

    }
}
