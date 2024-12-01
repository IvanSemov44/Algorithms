namespace SearchingSortingAndGreedyAlgorithms
{
    /*7. Sum of Coins
    Write a program, which receives a set of coins and a target sum. The goal is to reach the sum using as few coins as 
    possible. You should use a greedy approach.
    Constraints
    • We’ll assume that each coin value and the desired sum are integers. 
    Output
    • If the target sum can be reached:
    o First, print the number of used coins in the following format: "Number of coins to take: 
    {coins}".
    o For each used coin print its value and how many times has been used in the following format: 
    "{counter} coin(s) with value {coinValue}".
    • Otherwise, print "Error".

    Examples

    Input
    1, 2, 5, 10, 20, 50
    923

    Output
    Number of coins to take: 21
    18 coin(s) with value 50
    1 coin(s) with value 20
    1 coin(s) with value 2
    1 coin(s) with value 1

    Comments
    18*50 + 1*20 + 1*2 + 1*1 = 900 + 20 + 2 + 1 = 
    923

    Input
    3, 7
    11

    Output
    Error 

    Comments
    Cannot reach desired sum with these coin values.
     */

    internal class SumOfCoins
    {
        public static void Solution()
        {
            var coins = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderByDescending(x => x));

            int target = int.Parse(Console.ReadLine());
            var selectedCoins = new Dictionary<int, int>();
            var totalCoint = 0;

            while (target > 0 && coins.Count > 0)
            {
                var currentCoin = coins.Dequeue();
                var count = target / currentCoin;

                if (count == 0) continue;

                selectedCoins[currentCoin] = count;
                totalCoint += count;

                target %= currentCoin;
            }

            if (target == 0)
            {
                Console.WriteLine($"Number of coins to take: {totalCoint}");

                foreach (var coin in selectedCoins)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
