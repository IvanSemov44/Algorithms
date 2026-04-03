// LeetCode #2 - Add Two Numbers
// Difficulty: Medium | Time: O(max(m,n)) | Space: O(max(m,n))
// Approach: Simulate digit-by-digit addition with a carry, like grade-school math.
//
// https://leetcode.com/problems/add-two-numbers/

namespace LeetCode.Medium;

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var dummy = new ListNode(0);  // placeholder head
        var current = dummy;
        int carry = 0;

        while (l1 != null || l2 != null || carry != 0)
        {
            int sum = carry;

            if (l1 != null)
            {
                sum += l1.val;
                l1 = l1.next;
            }
            if (l2 != null)
            {
                sum += l2.val;
                l2 = l2.next;
            }

            carry = sum / 10;
            current.next = new ListNode(sum % 10);
            current = current.next;
        }

        return dummy.next;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null!)
    {
        this.val = val;
        this.next = next;
    }
}
