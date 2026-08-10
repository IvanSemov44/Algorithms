using Xunit;
using LeetCode.Patterns.Stack;

namespace LeetCode.Tests;

public class MinStackTests
{
    [Fact]
    public void MinStack_Basic()
    {
        var minStack = new MinStack();
        minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);

        Assert.Equal(-3, minStack.GetMin());

        minStack.Pop();
        Assert.Equal(0, minStack.Top());
        Assert.Equal(-2, minStack.GetMin());
    }

    [Fact]
    public void MinStack_SingleElement()
    {
        var minStack = new MinStack();
        minStack.Push(1);

        Assert.Equal(1, minStack.GetMin());
        Assert.Equal(1, minStack.Top());

        minStack.Pop();
    }

    [Fact]
    public void MinStack_AllSame()
    {
        var minStack = new MinStack();
        minStack.Push(5);
        minStack.Push(5);
        minStack.Push(5);

        Assert.Equal(5, minStack.GetMin());

        minStack.Pop();
        Assert.Equal(5, minStack.GetMin());

        minStack.Pop();
        minStack.Pop();
    }

    [Fact]
    public void MinStack_Decreasing()
    {
        var minStack = new MinStack();
        minStack.Push(10);
        minStack.Push(5);
        minStack.Push(3);

        Assert.Equal(3, minStack.GetMin());

        minStack.Pop();
        Assert.Equal(5, minStack.GetMin());

        minStack.Pop();
        Assert.Equal(10, minStack.GetMin());
    }

    [Fact]
    public void MinStack_Increasing()
    {
        var minStack = new MinStack();
        minStack.Push(1);
        minStack.Push(2);
        minStack.Push(3);

        Assert.Equal(1, minStack.GetMin());

        minStack.Pop();
        Assert.Equal(1, minStack.GetMin());

        minStack.Pop();
        minStack.Pop();
    }

    [Fact]
    public void MinStack_NegativeNumbers()
    {
        var minStack = new MinStack();
        minStack.Push(-1);
        minStack.Push(-2);
        minStack.Push(-3);

        Assert.Equal(-3, minStack.GetMin());

        minStack.Pop();
        Assert.Equal(-2, minStack.GetMin());
    }
}
