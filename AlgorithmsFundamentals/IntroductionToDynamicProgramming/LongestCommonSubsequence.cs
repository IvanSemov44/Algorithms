namespace IntroductionToDynamicProgramming
{
    /*
     3. Longest Common Subsequence
Considering two sequences S1 and S2, the longest common subsequence is a sequence that is a subsequence of both 
S1 and S2. For instance, if we have two strings (sequences of characters), "abc" and "adb", the LCS is "ab" – it is a 
subsequence of both sequences and it is the longest (there are two other subsequences – "a" and "b").
Input
• On the first line, you will receive a string – str1 – first string.
• On the second line, you will receive a string – str2 – second string.
Output
• Print the length of the longest common subsequence
    */
    internal static class LongestCommonSubsequence
    {
        public static void Solution()
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var lcs = new int[str1.Length + 1, str2.Length + 1];

            for (int r = 1; r < lcs.GetLength(0); r++)
                for (int c = 1; c < lcs.GetLength(1); c++)
                    if (str1[r - 1] == str2[c - 1])
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    else
                        lcs[r, c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);

            Console.WriteLine(lcs[str1.Length, str2.Length]);
        }
    }
}
