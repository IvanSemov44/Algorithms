namespace ExamPreparation
{
    internal class BankRobbery
    {
        public static void Solution()
        {
            var safeDeposit = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var allSum = FindAllSums(safeDeposit);

            var totalSum = safeDeposit.Sum();

            var JoshSum = totalSum / 2;

            while (true)
            {
                var PrakashSum = totalSum - JoshSum;

                if (allSum.ContainsKey(JoshSum))
                {
                    var JoshSafe = FindSubset(allSum, JoshSum);
                    var PrakashSafe = GetOtherSubset(safeDeposit, JoshSafe);
                    Console.WriteLine(string.Join(" ", JoshSafe.OrderBy(x => x)));
                    Console.WriteLine(string.Join(" ", PrakashSafe.OrderBy(x => x)));
                    break;
                }
                JoshSum--;
            }
        }

        private static List<int> GetOtherSubset(int[] elements, List<int> deference)
        {
            var otherSubset = new List<int>();

            foreach (var element in elements)
                if (!deference.Contains(element))
                    otherSubset.Add(element);

            return otherSubset;
        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subSet = new List<int>();

            while (target != 0)
            {
                var element = sums[target];
                subSet.Add(element);

                target -= element;
            }

            return subSet;
        }

        private static Dictionary<int, int> FindAllSums(int[] elements)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var element in elements)
            {
                var currentSums = sums.Keys.ToArray();

                foreach (var sum in currentSums)
                {
                    var newSum = sum + element;

                    if (sums.ContainsKey(newSum))
                        continue;

                    sums.Add(newSum, element);
                }
            }

            return sums;
        }
    }
}
