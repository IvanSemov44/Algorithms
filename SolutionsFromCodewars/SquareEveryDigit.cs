namespace SolutionsFromCodewars
{
    internal static class SquareEveryDigit
    {
        //https://www.codewars.com/kata/546e2562b03326a88e000020/solutions/csharp
        public static int Solution(int number)
        {
            return int.Parse(
                string.Join("",
                 number.ToString()
                .ToCharArray()
                .Select(x => x - '0')
                .Select(x => x = x * x)
                .ToArray()));
        }
    }
}
