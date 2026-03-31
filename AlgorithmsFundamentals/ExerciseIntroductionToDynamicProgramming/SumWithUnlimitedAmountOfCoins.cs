namespace ExerciseIntroductionToDynamicProgramming
{
    /*
     3. Sum with Unlimited Amount of Coins
We have a set of coins with predetermined values, e.g. 1, 2, 5, 10, 20, 50. Given a sum S, the task is to find how many
combinations of coins will sum up to S. For each value, we can use an unlimited number of coins, e.g. we can use S
coins of value 1 or S/2 coins of value 2 (if S is even), etc.
    */

    //Input         Output
    //1 2 3 4 6     10
    //6
    //-----------------
    //1 2 5         4
    //5
    internal static class SumWithUnlimitedAmountOfCoins
    {
        public static void Solution()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var target = int.Parse(Console.ReadLine());

            Console.WriteLine(CountSums(numbers, target));
        }

        private static int CountSums(int[] numbers, int target)
        {
            var sums = new int[target + 1];

            sums[0] = 1;

            foreach (var number in numbers)
                for (int sum = number; sum <= target; sum++)
                    sums[sum] += sums[sum - number];

            return sums[target];
        }
    }
}
