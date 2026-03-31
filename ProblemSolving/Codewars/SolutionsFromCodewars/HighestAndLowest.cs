using System.Linq;

namespace SolutionsFromCodewars
{
    public static class HighestAndLowest
    {
        public static string HighAndLow(string number)
        {
            var numbers = number.Split(' ').Select(int.Parse).ToArray();

            var min = int.MaxValue;
            var max = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                    min = numbers[i];

                if (numbers[i] > max)
                    max = numbers[i];
            }

            return max + " " + min;
        }
    }
}
