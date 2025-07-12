namespace SolutionsFromCodewars
{
    //https://www.codewars.com/kata/54da5a58ea159efa38000836

    /*
    Given an array of integers, find the one that appears an odd number of times.
    
    There will always be only one integer that appears an odd number of times.
    
    Examples
    [7] should return 7, because it occurs 1 time (which is odd).
    [0] should return 0, because it occurs 1 time (which is odd).
    [1,1,2] should return 2, because it occurs 1 time (which is odd).
    [0,1,0,1,0] should return 0, because it occurs 3 times (which is odd).
    [1,2,2,3,3,3,4,3,3,3,2,2,1] should return 4, because it appears 1 time (which is odd).
    */

    public static class FindTheOddInt
    {
        public static void Solution(int[] seq)
        {
            var prevResult = new Dictionary<int, int>();

            for (int i = 0; i < seq.Length; i++)
            {
                if (prevResult.ContainsKey(seq[i]))
                    prevResult[seq[i]]++;
                else
                    prevResult[seq[i]] = 1;

            }

            int result = prevResult.Where(x => x.Value % 2 == 1).OrderBy(kvp => kvp.Value).First().Key;
            Console.WriteLine(result);

            //foreach (var kvp in prevResult)
            //{
            //    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            //    if (kvp.Value % 2 != 0)
            //    {
            //        Console.WriteLine(kvp.Key);
            //        return;
            //    }
            //}
        }
    }
}
