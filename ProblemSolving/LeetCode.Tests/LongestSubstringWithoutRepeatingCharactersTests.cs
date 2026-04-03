using Xunit;
using LeetCode.Medium;

namespace LeetCode.Tests;

public class LongestSubstringWithoutRepeatingCharactersTests
{
    [Fact]
    public void LongestSubstring_Example1()
    {
        var solution = new LongestSubstringWithoutRepeatingCharacters();
        // "abcabcbb" → "abc" has length 3
        Assert.Equal(3, solution.LengthOfLongestSubstring("abcabcbb"));
    }

    [Fact]
    public void LongestSubstring_Example2()
    {
        var solution = new LongestSubstringWithoutRepeatingCharacters();
        // "bbbbb" → "b" has length 1
        Assert.Equal(1, solution.LengthOfLongestSubstring("bbbbb"));
    }

    [Fact]
    public void LongestSubstring_Example3()
    {
        var solution = new LongestSubstringWithoutRepeatingCharacters();
        // "pwwkew" → "wke" has length 3
        Assert.Equal(3, solution.LengthOfLongestSubstring("pwwkew"));
    }

    [Fact]
    public void LongestSubstring_Empty()
    {
        var solution = new LongestSubstringWithoutRepeatingCharacters();
        Assert.Equal(0, solution.LengthOfLongestSubstring(""));
    }

    [Fact]
    public void LongestSubstring_SingleCharacter()
    {
        var solution = new LongestSubstringWithoutRepeatingCharacters();
        Assert.Equal(1, solution.LengthOfLongestSubstring("a"));
    }

    [Fact]
    public void LongestSubstring_AllUnique()
    {
        var solution = new LongestSubstringWithoutRepeatingCharacters();
        // "abcdefg" all unique → length 7
        Assert.Equal(7, solution.LengthOfLongestSubstring("abcdefg"));
    }

    [Fact]
    public void LongestSubstring_RepeatingAtEnd()
    {
        var solution = new LongestSubstringWithoutRepeatingCharacters();
        // "dvdf" → "vdf" has length 3
        Assert.Equal(3, solution.LengthOfLongestSubstring("dvdf"));
    }

    [Fact]
    public void LongestSubstring_TwoCharacters()
    {
        var solution = new LongestSubstringWithoutRepeatingCharacters();
        Assert.Equal(2, solution.LengthOfLongestSubstring("au"));
    }
}
