// LeetCode #3 - Longest Substring Without Repeating Characters
// Difficulty: Medium | Time: O(n) | Space: O(min(m, n))
// Approach: Sliding window with HashSet; expand right, shrink left when duplicate found.
//
// https://leetcode.com/problems/longest-substring-without-repeating-characters/

namespace LeetCode.Medium;

public class LongestSubstringWithoutRepeatingCharacters
{
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;
        
        var set = new HashSet<char>();
        int left = 0, right = 0, maxLength = 0;
        while (right < s.Length)
        {
            if (!set.Contains(s[right]))
            {
                set.Add(s[right]);
                maxLength = Math.Max(maxLength, right - left + 1);
                right++;
            }
            else
            {
                set.Remove(s[left]);
                left++;
            }
        }
        return maxLength;
    }
}
