﻿namespace ExamPreparation
{
    internal class TwoMinutesToMidnight
    {
        public static void Solution()
        {

            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            Console.WriteLine(GetBinom(n, k));
        }

        private static int GetBinom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
                return 1;

            return GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
        }
    }
}
