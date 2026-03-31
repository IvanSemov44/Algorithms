namespace IntroductionToDynamicProgramming
{
    /*
     * Subset Sum Problem and Its Variations
Subset sum problem (zero subset sum problem)
▪ Given a set of integers, find a non-empty subset whose 
sum 0
▪ E.g. {8, 3, -50, 1, -2, -1, 15, -2} -> {3, 1, -2, -2}
▪ Given a set of integers and an integer S,
find a subset whose sum is S
▪ E.g. {8, 3, 2, 1, 12, 1}, S=16 -> {3, 1, 12}
▪ Given a set of integers, find all possible sums
     */

    // This problem is not included in Lab because of meny different solution - From the presentator.
    internal static class SubsetSumNoRepeats
    {
        public static void Solution()
        {
            var nums = new[] { 3, 5, 1, 4, 2 };
            var target = 6;

            var possibleSums = GetAllPossinbleSum(nums);
            if (possibleSums.ContainsKey(target))
            {
                var includedNums = FindSubset(possibleSums, target);

                Console.WriteLine(string.Join(" ", includedNums));
            }
            else
                Console.WriteLine("Sum was not possible");
        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();
            while (target > 0)
            {
                var num = sums[target];
                subset.Add(num);

                target -= num;
            }

            return subset;
        }

        private static Dictionary<int, int> GetAllPossinbleSum(int[] nums)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var num in nums)
            {
                var currentSums = sums.Keys.ToArray();

                foreach (var sum in currentSums)
                {
                    var newSum = sum + num;
                    if (sums.ContainsKey(newSum))
                        continue;

                    sums.Add(newSum, num);
                }
            }

            return sums;
        }
    }
}
