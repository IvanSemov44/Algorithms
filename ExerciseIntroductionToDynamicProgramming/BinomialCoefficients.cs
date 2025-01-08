
namespace ExerciseIntroductionToDynamicProgramming
{
    /*
     Write a program that finds the binomial coefficient (n 𝑘) 
    for given non-negative integers n and k. The coefficient can 
    be found recursively
    However, this leads to calculating the same coefficient multiple times (a problem that also occurs when solving the 
    Fibonacci problem recursively). Use memoization to improve performance.
    You can check your answers using the picture below (row and column indices start from 0):
    */

    /*
     Input    Output
     3         
     2        3
     ----------
     4
     0        1
     ----------
     6
     2        15
     ---------
     49
     10       8217822536
    */

    internal static class BinomialCoefficients
    {
        private static Dictionary<string, long> cache;

        public static void Solution()
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            cache = new Dictionary<string, long>();

            Console.WriteLine(GetBinom(row, col));
        }

        private static long GetBinom(long row, long col)
        {
            if (col == 0 || col == row)
                return 1;

            var key = $"{row}-{col}";

            if (cache.ContainsKey(key))
                return cache[key];

            var result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
            cache[key] = result;

            return result;
        }
    }
}
