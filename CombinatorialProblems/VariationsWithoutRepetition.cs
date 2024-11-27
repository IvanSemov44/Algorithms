using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CombinatorialProblems
{
    //    3. Variations without Repetitions
    //Given a set of elements, find all variations of k elements without repetitions.

    //Examples

    //Input:
    //A B C
    //2

    //Output:
    //A B
    //A C
    //B A
    //B C
    //C A
    //C B

    internal class VariationsWithoutRepetition
    {
        private static int k;
        private static string[] elements;
        private static string[] variations;
        private static bool[] used;

        public static void Solution()
        {
            //elements = new[] { "A", "B", "B" };
            //k = 2;
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
                    used[i] = false;
                }
            }
        }
    }
}
