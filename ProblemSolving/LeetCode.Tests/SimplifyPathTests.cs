using Xunit;
using LeetCode.Patterns.Stack;

namespace LeetCode.Tests;

public class SimplifyPathTests
{
    [Fact]
    public void SimplifyPath_Example1()
    {
        var solution = new SimplifyPath();
        Assert.Equal("/home/user/Pictures", solution.SimplifyUnixPath("/home/user/Documents/../Pictures"));
    }

    [Fact]
    public void SimplifyPath_Example2()
    {
        var solution = new SimplifyPath();
        Assert.Equal("/", solution.SimplifyUnixPath("/../"));
    }

    [Fact]
    public void SimplifyPath_Example3()
    {
        var solution = new SimplifyPath();
        Assert.Equal("/home/foo", solution.SimplifyUnixPath("/home//foo/"));
    }

    [Fact]
    public void SimplifyPath_RootOnly()
    {
        var solution = new SimplifyPath();
        Assert.Equal("/", solution.SimplifyUnixPath("/"));
    }

    [Fact]
    public void SimplifyPath_SingleDirectory()
    {
        var solution = new SimplifyPath();
        Assert.Equal("/a", solution.SimplifyUnixPath("/a/"));
    }

    [Fact]
    public void SimplifyPath_DotDotAtRoot()
    {
        var solution = new SimplifyPath();
        Assert.Equal("/", solution.SimplifyUnixPath("/a/../../"));
    }

    [Fact]
    public void SimplifyPath_ComplexPath()
    {
        var solution = new SimplifyPath();
        // /a → push, /b → push, /c → push, /. → skip, /.. → pop, /.. → pop
        Assert.Equal("/a", solution.SimplifyUnixPath("/a/b/c/./../../"));
    }

    [Fact]
    public void SimplifyPath_MultipleSlashes()
    {
        var solution = new SimplifyPath();
        // /a → push, /b → push, /c → push, /d → push, /. → skip, /. → skip, /.. → pop
        Assert.Equal("/a/b/c", solution.SimplifyUnixPath("/a//b////c/d//././/.."));
    }
}
