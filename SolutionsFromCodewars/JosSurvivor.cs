namespace SolutionsFromCodewars
{
    internal static class JosSurvivor
    {
        public static int Solution(int n, int k)
        {
            var list = new List<int>();

            for (int i = 0; i < n; i++)
                list.Add(i + 1);

            var count = 1;
            var pointer = 1;

            while (list.Count > 1)
            {
                if (pointer >= k)
                {
                    list.RemoveAt(count - 1);
                    pointer = 1;
                }
                else
                {
                    count++;
                    pointer++;
                }

                if (count > list.Count)
                    count -= list.Count;
            }
            
            return list[0];
        }
    }
}
