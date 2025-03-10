﻿namespace ExerciseDynamicProgrammingAdvanced
{
    internal class BattlePoints
    {
        public static void Solution()
        {
            var energy = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var battlePoint = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var maxEnergy = int.Parse(Console.ReadLine());

            var dp = new int[energy.Length + 1, maxEnergy + 1];

            for (int enemyIdx = 1; enemyIdx < dp.GetLength(0); enemyIdx++)
            {
                var enemyEnergy = energy[enemyIdx - 1];
                var enemyBattlePoints = battlePoint[enemyIdx - 1];

                for (int capacity = 0; capacity < dp.GetLength(1); capacity++)
                {
                    var excluding = dp[enemyIdx - 1, capacity];

                    if (enemyEnergy > capacity)
                    {
                        dp[enemyIdx, capacity] = excluding;
                        continue;
                    }

                    var including = enemyBattlePoints +
                        dp[enemyIdx - 1, capacity - enemyEnergy];

                    dp[enemyIdx, capacity] = Math.Max(including, excluding);
                }
            }

            Console.WriteLine(dp[energy.Length, maxEnergy]);
        }
    }
}