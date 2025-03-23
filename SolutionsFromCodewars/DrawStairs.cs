using System.Text;

namespace SolutionsFromCodewars
{
    //https://www.codewars.com/kata/5b4e779c578c6a898e0005c5/
    internal static class DrawStairs
    {
        public static void Solution()
        {
            int n = 7;
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    result.Append(" ");
                }
                if (i == n - 1)
                    result.Append("I");
                else
                    result.Append("I\n");
            }
            Console.WriteLine(result.ToString());
        }
    }
}
