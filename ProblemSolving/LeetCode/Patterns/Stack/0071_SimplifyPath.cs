// LeetCode #71 - Simplify Path
// Difficulty: Hard | Time: O(n) | Space: O(n)
// Approach: Use stack to track valid directory names.
//           Skip ".", pop for "..", add regular names.
//
// https://leetcode.com/problems/simplify-path/

namespace LeetCode.Patterns.Stack;

public class SimplifyPath
{
    public string SimplifyUnixPath(string path)
    {
        var stack = new Stack<string>();
        var parts = path.Split('/');

        foreach (var part in parts)
        {
            if (string.IsNullOrEmpty(part) || part == ".")
                continue;

            if (part == "..")
            {
                if (stack.Count > 0)
                    stack.Pop();
            }
            else
            {
                stack.Push(part);
            }
        }

        return "/" + string.Join("/", stack.Reverse());
    }
}
