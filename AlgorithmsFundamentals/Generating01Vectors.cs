namespace RecurtionAndBackTracking
{
    //3. Generating 0/1 Vectors
    //Generate all n-bit vectors of 0 and 1 in lexicographic order.

    //Input: 3
    //Output:
    //000
    //001
    //010
    //011
    //100
    //101
    //110
    //111

    //Input 5
    //Output:
    //00000
    //00001
    //00010
    //…
    //11110
    //11111

    internal class Generating01Vectors
    {
        internal static void Generate01()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            Generate01(arr, 0);
        }

        private static void Generate01(int[] arr, int idx)
        {
            if (idx >= arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[idx] = i;
                Generate01(arr, idx + 1);
            }
        }
    }
}
