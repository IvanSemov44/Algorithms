using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionsFromCodewars
{
    internal static class DescendingOrder
    {
        public static int Solution(int number)
        {
            return int.Parse(string.Concat(number
                .ToString()
                .Where(char.IsNumber)
                .Select(c => int.Parse(c.ToString()))
                .ToArray()
                .OrderDescending()));
        }
    }
}