namespace SearchingSortingAndGreedyAlgorithms
{
    /*
     * 8. Set Cover
    Write a program that finds the smallest subset of sets, which contains all elements from a given sequence.
    You are given two sets - a set of sets (we’ll call it sets) and a universe (a sequence). The sets contain only
    elements from the universe, however, some elements are repeated. Your task is to find the smallest subset of 
    sets that contains all elements in-universe. 

    Examples

    Input:
    1, 2, 3, 4, 5
   
    4

    1
    2, 4
    5
    3

    Output:
    Sets to take (4):
    2, 4
    1
    5
    3
  
    Input:
    1, 3, 5, 7, 9, 11, 20, 30, 40

    6

    20
    1, 5, 20, 30
    3, 7, 20, 30, 40
    9, 30
    11, 20, 30, 40
    3, 7, 40

    Output:
    Sets to take (4):
    3, 7, 20, 30, 40
    1, 5, 20, 30
    9, 30
    11, 20, 30, 40
   
    Greedy Approach
    
    Using the greedy approach, at each step, we’ll take the set which contains the most elements present in the universe 
    which we haven’t yet taken. At the first step, we’ll always take the set with the largest number of elements, but it gets 
    a bit more complicated afterward. To simplify our job (and not check against two sets at the same time), when taking 
    a set, we can remove all elements in it from the universe. We can also remove the set from the sets we’re considering.
   
    Greedy Algorithm Implementation
    
    First, initialize the resulting list:
   
    As discussed in the previous section, we’ll be removing elements from the universe, so we’ll be repeating the next 
    steps until the universe is empty:
    
    The hardest part is selecting a set. We need to get the set that has the most elements contained in the universe. We 
    can use LINQ to sort the sets and then take the first set (the one with the most elements in the universe):
    Sorting the sets at each step is probably not the most efficient approach, but it’s simple enough to understand. The 
    above LINQ query tests each element in a set to see if it is contained in the universe and sorts the sets (in descending 
    order, from largest to smallest) based on the number of elements in each set that are in the universe. 
    Once we have the set we’re looking for, the next steps are trivial. Complete the TODOs below:
    After implementing TODOs, you should be done with this problem
     */
    internal class SetCover
    {
        public static void Solution()
        {
            var universe = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToHashSet();

            var n = int.Parse(Console.ReadLine());

            var sets = new List<int[]>();

            for (int i = 0; i < n; i++)
            {
                var set = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                sets.Add(set);
            }
            var selectedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                var set = sets
                    .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                    .FirstOrDefault();

                selectedSets.Add(set);
                sets.Remove(set);

                foreach (var element in set)
                {
                    universe.Remove(element);
                }
            }

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (var set in selectedSets)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }
    }
}
