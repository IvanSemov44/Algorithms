namespace RecurtionAndBackTracking
{
    //1. Recursive Array Sum
    // Write a program that finds the sum of all elements in an integer array.Use recursion
    //exams:
    //input: 1 2 3 4  -> output: 10
    //input: -1 0 1 -> output: 0

    internal static class RecursiveArraySum
    {
        internal static void SumRecursicely()
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(SumRecursively(numbers, 0));
        }

        private static int SumRecursively(int[] numbers, int idx)
        {
            if (idx == numbers.Length - 1)
            {
                return numbers[idx];
            }
            return numbers[idx] + SumRecursively(numbers, idx + 1);
        }
    }
}
