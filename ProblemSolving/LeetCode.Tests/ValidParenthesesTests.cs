using Xunit;
using LeetCode.Patterns.Stack;

namespace LeetCode.Tests;

public class ValidParenthesesTests
{
    [Fact]
    public void IsValid_BalancedParentheses()
    {
        var solution = new ValidParentheses();
        Assert.True(solution.IsValid("()"));
    }

    [Fact]
    public void IsValid_BalancedMixed()
    {
        var solution = new ValidParentheses();
        Assert.True(solution.IsValid("()[]{}"));
    }

    [Fact]
    public void IsValid_BalancedNested()
    {
        var solution = new ValidParentheses();
        Assert.True(solution.IsValid("([{}])"));
    }

    [Fact]
    public void IsValid_InvalidUnmatched()
    {
        var solution = new ValidParentheses();
        Assert.False(solution.IsValid("(]"));
    }

    [Fact]
    public void IsValid_InvalidMissingClose()
    {
        var solution = new ValidParentheses();
        Assert.False(solution.IsValid("([)]"));
    }

    [Fact]
    public void IsValid_InvalidOnlyClose()
    {
        var solution = new ValidParentheses();
        Assert.False(solution.IsValid("}"));
    }

    [Fact]
    public void IsValid_Empty()
    {
        var solution = new ValidParentheses();
        Assert.True(solution.IsValid(""));
    }

    [Fact]
    public void IsValid_OddLength()
    {
        var solution = new ValidParentheses();
        Assert.False(solution.IsValid("("));
    }
}
