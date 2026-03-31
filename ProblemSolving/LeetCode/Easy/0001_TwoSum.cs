// LeetCode #1 - Two Sum
// Difficulty: Easy | Time: O(n) | Space: O(n)
// Approach: Hash map stores each value's index; for every element check if
//           its complement (target - nums[i]) was already seen.
//
// https://leetcode.com/problems/two-sum/

namespace LeetCode.Easy;

public class TwoSum
{
    public int[] Solve(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (map.TryGetValue(complement, out int j))
                return [j, i];

            map[nums[i]] = i;
        }

        return [];
    }
}
