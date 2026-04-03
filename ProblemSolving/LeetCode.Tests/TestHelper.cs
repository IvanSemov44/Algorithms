using LeetCode.Medium;

namespace LeetCode.Tests;

public static class TestHelper
{
    /// <summary>
    /// Converts an array to a linked list (least significant digit first).
    /// Example: [2, 4, 3] → 2 -> 4 -> 3 (represents 342)
    /// </summary>
    public static ListNode? ArrayToListNode(int[] arr)
    {
        if (arr.Length == 0)
            return null;

        var head = new ListNode(arr[0]);
        var current = head;

        for (int i = 1; i < arr.Length; i++)
        {
            current.next = new ListNode(arr[i]);
            current = current.next;
        }

        return head;
    }

    /// <summary>
    /// Converts a linked list back to an array for assertion.
    /// </summary>
    public static int[] ListNodeToArray(ListNode? head)
    {
        var result = new List<int>();
        var current = head;

        while (current != null)
        {
            result.Add(current.val);
            current = current.next;
        }

        return result.ToArray();
    }
}
