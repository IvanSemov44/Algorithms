
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

            Reverse(array, 0);
            Console.WriteLine(string.Join(" ", array));
        }

        private static void Reverse(string[] array, int idx)
        {
            if (array.Length / 2 == idx) return;

            var temp = array[idx];
            array[idx] = array[array.Length - idx - 1];
            array[array.Length - idx - 1] = temp;

            Reverse(array, idx + 1);
        }
    }
}
