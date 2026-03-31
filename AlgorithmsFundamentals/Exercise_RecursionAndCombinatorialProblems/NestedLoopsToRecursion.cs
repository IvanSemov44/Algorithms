namespace Exercise_RecursionAndCombinatorialProblems
{
    //2. Nested Loops To Recursion
    //Write a program that simulates the execution of n nested loops from 1 to n which prints the values of all its iteration
    //variables at any given time on a single line.Use recursion.

    //Examples

    //Input
    //2                 

    //Output
    //1 1
    //1 2
    //2 1
    //2 2

    //-----

    //Input
    //3

    //Output
    //1 1 1
    //1 1 2
    //1 1 3
    //1 2 1
    //1 2 2
    //…
    //3 2 3
    //3 3 1
    //3 3 2
    //3 3 3

    internal static class NestedLoopsToRecursion
    {
        private static int[] arr;
        public static void Solution()
        {
            int n = int.Parse(Console.ReadLine());
            arr = new int[n];
            Recurtion(0);
        }

        private static void Recurtion(int n)
        {
            if (n >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[n] = i;
                Recurtion(n + 1);
            }
        }
    }
}
