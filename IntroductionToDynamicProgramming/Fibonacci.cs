namespace IntroductionToDynamicProgramming
{
    /*
    1. Fibonacci
    Write a dynamic programming solution for finding nth Fibonacci members.
    • F0 = 0
    • F1 = 1
     */
    //Input Output
    /*
    20 ---- 6765
    50 ---- 12586269025
    */

    internal static class Fibonacci
    {
        private static Dictionary<int, long> cache = new Dictionary<int, long>();

        public static void Solution()
        {

            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFib(n));
        }

        private static long CalcFib(int n)
        {
            if (cache.ContainsKey(n))
                return cache[n];

            if (n < 2)
                return n;

            var result = CalcFib(n - 1) + CalcFib(n - 2);
            cache[n] = result;

            return CalcFib(n - 1) + CalcFib(n - 2);
        }
    }
}
