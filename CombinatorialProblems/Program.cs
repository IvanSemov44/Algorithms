﻿
using System;
using System.Collections.Generic;

namespace CombinatorialProblems
{
    //Problems Description here: https://judge.softuni.org/Contests/Practice/DownloadResource/33716
    internal class Program
    {
        private static int k;
        private static string[] elements;
        private static string[] variations;
        private static bool[] used;

        static void Main(string[] args)
        {
            //1.Permutations without Repetitions
            //PermutationsWithoutRepetition.Solution();
            //PermutationsWithoutRepetitionWithUsingExtraMemory.Solution();

            //2. Permutations with Repetitions
            //PermutationsWithRepetition.Solution();

            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            variations = new string[k];
            used = new bool[elements.Length];

            Variations(0);
        }

        private static void Variations(int idx)
        {
            if (idx >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[idx] = elements[i];
                    Variations(idx + 1);
                    used[i]=false;
                }
            }
        }
    }
}
