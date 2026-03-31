namespace ExerciseIntroductionToDynamicProgramming
{
    /*
     * 2. Dividing Presents
Alan and Bob are twins. For their birthday they received some presents and now they need to split them amongst
themselves. The goal is to minimize the difference between the values of the presents received by the two brothers,
i.e. to divide the presents as equally as possible.
Assume the presents have values represented by positive integer numbers and that presents cannot be split in half (a
present can only go to one brother or the other).
Find the minimal difference that can be obtained and print which presents each brother has received (you may only
print the presents for one of them, it is obvious that the rest will go to the other brother).
In the examples below Alan always takes a value less than or equal to Bob, but you may do it the other way around.
     */

    //Input
    //3 2 3 2 2 77 89 23 90 11

    //Output
    /*
    Difference: 30
    Alan:136 Bob:166
    Alan takes: 11 90 23 2 2 3 2 3
    Bob takes the rest.
     */

    internal static class DividingPresents
    {
        public static void Solutoin()
        {
            var presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var allSums = FindAllSums(presents);

            var totalSum = presents.Sum();

            var alanSum = totalSum / 2;

            while (true)
            {
                var bobSum = totalSum - alanSum;

                if (allSums.ContainsKey(alanSum))
                {
                    var alanPresents = FindSubset(allSums, alanSum);
                    Console.WriteLine($"Difference: {bobSum - alanSum}");
                    Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
                    Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
                    Console.WriteLine("Bob takes the rest.");
                    break;
                }

                alanSum -= 1;
            }
        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();

            while (target != 0)
            {
                var element = sums[target];
                subset.Add(element);

                target -= element;
            }

            return subset;
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
