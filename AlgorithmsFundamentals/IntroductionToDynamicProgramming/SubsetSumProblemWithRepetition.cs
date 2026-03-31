namespace IntroductionToDynamicProgramming
{
    /*
▪ Given a set of integers and an integer S, find a subset whose 
sum is S
▪ Repetitions are allowed
▪ E.g. {3, 5, 2}, S=17
▪ {5, 5, 5, 2}
▪ {3, 3, 3, 3, 3, 2}
▪ {5, 5, 2, 2, 3}
▪ ...
    */
    internal static class SubsetSumProblemWithRepetition
    {
        public static void Solution()
        {
            var nums = new int[] { 3, 5, 2 };
            var target = 17;

            var sums = new bool[target + 1];
            sums[0] = true;

            for (int sum = 0; sum < sums.Length; sum++)
            {
                if (!sums[sum])
                    continue;

                foreach (int num in nums)
                {
                    var newSum = sum + num;

                    if (newSum > target)
                        continue;

                    sums[newSum] = true;
                }
            }

            var subset = new List<int>();

            while (target > 0)
            {
                foreach (var num in nums)
                {
                    var prevSum = target - num;

                    if (prevSum >= 0 && sums[prevSum])
                    {
                        subset.Add(num);
                        target = prevSum;

                        if (target == 0)
                            break;
                    }

                }
            }
            Console.WriteLine(string.Join(" ", subset));

        }
    }
}
