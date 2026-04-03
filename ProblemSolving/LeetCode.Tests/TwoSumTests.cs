using Xunit;
using LeetCode.Easy;

namespace LeetCode.Tests;

public class TwoSumTests
{
    [Fact]
    public void TwoSum_Example1()
    {
        var solution = new TwoSum();
        var result = solution.Solve([2, 7, 11, 15], 9);

        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Contains(0, result);
        Assert.Contains(1, result);
    }

    [Fact]
    public void TwoSum_Example2()
    {
        var solution = new TwoSum();
        var result = solution.Solve([3, 2, 4], 6);

        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
    }

    [Fact]
    public void TwoSum_Example3()
    {
        var solution = new TwoSum();
        var result = solution.Solve([3, 3], 6);

        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Contains(0, result);
        Assert.Contains(1, result);
    }

    [Fact]
    public void TwoSum_LargeNumbers()
    {
        var solution = new TwoSum();
        var result = solution.Solve([1000000, 2000000, 3000000], 5000000);

        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
    }
}
