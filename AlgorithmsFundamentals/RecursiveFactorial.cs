namespace RecurtionAndBackTracking
{
    //4. Recursive Factorial
    //Write a program that calculates the recursively factorial of a given number
    //exams:
    //input: 5 -> output: 120
    //input: 4 -> output: 24

    internal static class RecursiveFactorial
    {
        internal static void FactorialRecursively()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateFactorialRecursively(n));
        }

        private static int CalculateFactorialRecursively(int n)
        {
            if (n == 0) return 1;
            return n * CalculateFactorialRecursively(n - 1);
        }
    }
}
