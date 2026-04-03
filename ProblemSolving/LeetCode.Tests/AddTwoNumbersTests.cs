using Xunit;
using LeetCode.Medium;

namespace LeetCode.Tests;

public class AddTwoNumbersTests
{
    [Fact]
    public void AddTwoNumbers_Example1()
    {
        var solution = new Solution();
        // [2, 4, 3] + [5, 6, 4] = [7, 0, 8]
        // represents: 342 + 465 = 807
        var l1 = TestHelper.ArrayToListNode([2, 4, 3])!;
        var l2 = TestHelper.ArrayToListNode([5, 6, 4])!;

        var result = solution.AddTwoNumbers(l1, l2);

        Assert.NotNull(result);
        Assert.Equal(new int[] { 7, 0, 8 }, TestHelper.ListNodeToArray(result));
    }

    [Fact]
    public void AddTwoNumbers_Example2()
    {
        var solution = new Solution();
        // [0] + [0] = [0]
        var l1 = TestHelper.ArrayToListNode([0])!;
        var l2 = TestHelper.ArrayToListNode([0])!;

        var result = solution.AddTwoNumbers(l1, l2);

        Assert.NotNull(result);
        Assert.Equal(new int[] { 0 }, TestHelper.ListNodeToArray(result));
    }

    [Fact]
    public void AddTwoNumbers_Example3()
    {
        var solution = new Solution();
        // [9, 9, 9, 9, 9, 9, 9] + [9, 9, 9, 9] = [8, 9, 9, 9, 0, 0, 0, 1]
        // represents: 9999999 + 9999 = 10009998
        var l1 = TestHelper.ArrayToListNode([9, 9, 9, 9, 9, 9, 9])!;
        var l2 = TestHelper.ArrayToListNode([9, 9, 9, 9])!;

        var result = solution.AddTwoNumbers(l1, l2);

        Assert.NotNull(result);
        Assert.Equal(new int[] { 8, 9, 9, 9, 0, 0, 0, 1 }, TestHelper.ListNodeToArray(result));
    }

    [Fact]
    public void AddTwoNumbers_DifferentLengths()
    {
        var solution = new Solution();
        // [2, 4] + [5, 6, 4] = [7, 0, 5]
        // represents: 42 + 465 = 507
        var l1 = TestHelper.ArrayToListNode([2, 4])!;
        var l2 = TestHelper.ArrayToListNode([5, 6, 4])!;

        var result = solution.AddTwoNumbers(l1, l2);

        Assert.NotNull(result);
        Assert.Equal(new int[] { 7, 0, 5 }, TestHelper.ListNodeToArray(result));
    }
}
