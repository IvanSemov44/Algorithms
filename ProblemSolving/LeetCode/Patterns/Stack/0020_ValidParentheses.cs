// LeetCode #20 - Valid Parentheses
// Difficulty: Easy | Time: O(n) | Space: O(n)
// Approach: Push opening brackets on stack, pop and match when closing bracket found.
//           Valid if stack is empty at end.
//
// https://leetcode.com/problems/valid-parentheses/

namespace LeetCode.Patterns.Stack;

public class ValidParentheses
{
    public bool IsValid(string s)
    {
       var stack = new Stack<char>();
       var map = new Dictionary<char, char>
       {
              { ')', '(' },
              { '}', '{' },
              { ']', '[' }
       };

       foreach(var c in s)
        {
            if(map.ContainsValue(c))
            {
                stack.Push(c);
            }
            else if(map.ContainsKey(c))
            {
                if(stack.Count == 0 || stack.Pop() != map[c] )
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}