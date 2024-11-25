namespace RecurtionAndBackTracking
{
    internal static class RecursiveFibonacci
    {
        internal static void CalculateFibonnacci()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFib(number));
        }

        private static long CalcFib(int number)
        {
            if (number <= 1) return 1;

            return CalcFib(number - 1) + CalcFib(number - 2);
        }
    }
}
