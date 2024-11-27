
using System.ComponentModel;

namespace Exercise_RecursionAndCombinatorialProblems
{
    //1. Reverse Array
    //Write a program that reverses and prints an array.Use recursion.

    //Examples

    //Input             Output
    //1 2 3 4 5 6       6 5 4 3 2 1
    //-1 0 1            1 0 -1
    internal static class ReverseArray
    {
        internal static void Solution()
        {
            //int[] array = { 1, 2, 3, 4, 5, 6 };
            string[] array = Console.ReadLine().Split();

            Reverse(array, array.Length - 1);
        }

        private static void Reverse(string[] array, int idx)
        {
            if (idx < 0) return;

            Console.Write(array[idx] + " ");
            Reverse(array, idx - 1);
        }
    }
}
