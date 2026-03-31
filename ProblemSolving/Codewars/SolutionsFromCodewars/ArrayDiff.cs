using System.Collections.Generic;
using System.Linq;

namespace SolutionsFromCodewars
{
    //https://www.codewars.com/kata/523f5d21c841566fde000009
    /*
     Implement a function that computes the difference between two lists. 
     The function should remove all occurrences of elements from the first list (a) that are present in the second list (b). 
     The order of elements in the first list should be preserved in the result.

     Examples
     If a = [1, 2] and b = [1], the result should be [2].
     
     If a = [1, 2, 2, 2, 3] and b = [2], the result should be [1, 3].
     */

    public static class ArrayDiff
    {
        public static int[] Solution(int[] a, int[] b)
        {
            //var first = a.ToList();
            for (int j = 0; j < b.Length; j++)
            {
                if (a.Contains(b[j]))
                {
                    a = a.Where(x => x != b[j]).ToArray();
                }
            }


            //Console.WriteLine(string.Join(",", a));
            return a;

        }
    }
}
