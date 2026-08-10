// LeetCode #155 - Min Stack
// Difficulty: Medium | Time: O(1) | Space: O(n)
// Approach: Maintain two stacks—one for values, one for minimums.
//           Track min at each level so getMin() is O(1).
//
// https://leetcode.com/problems/min-stack/

namespace LeetCode.Patterns.Stack;

public class MinStack
{
    private Stack<int> stack = new Stack<int>();
    private Stack<int> minStack = new Stack<int>();

    public MinStack()
    {

    }

    public void Push(int val)
    {
        stack.Push(val);
        if (minStack.Count == 0 || val <= minStack.Peek())
        {
            minStack.Push(val);
        }
    }

    public void Pop()
    {
        if (stack.Count == 0) return;

        int top = stack.Pop();
        if (top == minStack.Peek())
        {
            minStack.Pop();
        }
    }

    public int Top()
    {
        if (stack.Count == 0) throw new InvalidOperationException("Stack is empty");
        return stack.Peek();
    }

    public int GetMin()
    {
        if (minStack.Count == 0) throw new InvalidOperationException("Stack is empty");
        return minStack.Peek();
    }
}
