namespace ExerciseIntroductionToDynamicProgramming
{
    /*
     4. Sum with Limited Amount of Coins
In the previous problem, the coins represented values, not actual coins (we could take as many coins of a certain value
as we wanted). In this problem, we’ll regard the coins as actual coins, e.g. 1, 2, 5 are three coins and we can use each
of them only once. We can, of course, have more coins of a given value, e.g. – 1, 1, 2, 2, 10.
The task is the same - find the number of ways we can combine the coins to obtain a certain sum S.
    */

    //Input                 Output
    //1 2 2 3 3 4 6         4
    //6
    //----------------------------
    //1 2 2 5 5 10          2
    //13

    internal static class SumWithLimitedAmountOfCoins
    {
        public static void Solution()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var target = int.Parse(Console.ReadLine());

            Console.WriteLine(CountSum(numbers, target));
        }

        private static int CountSum(int[] numbers, int target)
        {
            var count = 0;
            var sums = new HashSet<int> { 0 };

            foreach (var number in numbers)
            {
                var newSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    var newSum = sum + number;

                    if (newSum == target)
                        count++;

                    newSums.Add(newSum);
                }

                sums.UnionWith(newSums);
            }

            return count;
        }
    }
}
