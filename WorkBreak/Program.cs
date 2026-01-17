// 139. Word Break
using System.Collections.Generic;

public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        Dictionary<int, bool> curPos = new Dictionary<int, bool>();

        foreach (string word in wordDict)
        {
            if (s.StartsWith(word))
                curPos.Add(word.Length, false);
        }

        while (curPos.ContainsValue(false))
        {
            // Find first unvisited position
            int pos = 0;
            foreach (var kvp in curPos)
            {
                if (kvp.Value == false)
                {
                    pos = kvp.Key;
                    curPos[pos] = true;
                    break;
                }
            }

            if (pos == s.Length)
                return true;

            foreach (string word in wordDict)
            {
                if (pos < s.Length && s.Substring(pos).StartsWith(word))
                {
                    if (curPos.ContainsKey(pos + word.Length) == false)
                        curPos[pos + word.Length] = false;
                }
            }
        }
        return false;

#if false   // Time Limit Exceeded
        Stack<int> currentLegth = new Stack<int>();

        foreach (string word in wordDict)
        {
            if (s.StartsWith(word))
                currentLegth.Push(word.Length);
        }

        while (currentLegth.Count > 0)
        {
            int pos = currentLegth.Pop();
            if (pos == s.Length)
                return true;

            foreach (string word in wordDict)
            {
                if (pos < s.Length && s.Substring(pos).StartsWith(word))
                {
                    if (currentLegth.Contains(pos + word.Length) == false)
                        currentLegth.Push(pos + word.Length);
                }
            }
        }
        return false;
#endif
    }
}

class Program
{
    static bool TestCase(string s, IList<string> wordDict, bool expected)
    {
        Solution test = new Solution();
        bool output = test.WordBreak(s, wordDict);
        Console.WriteLine(" Output: " + output + " Expected: " + expected + " Result: " + (expected == output ? "PASS" : "FAIL"));
        return expected == output;
    }
    public static void Main()
    {
        bool result;
        while (true)
        {
            // Time Limit Exceeded
            result = TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab",
                new List<string> { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" }, false);
            if (result == false) break;

            result = TestCase("ccbb", new List<string> { "bc", "cb" }, false);
            if (result == false) break;

            result = TestCase("aaaaaaa", new List<string> { "aaaa", "aa" }, false);
            if (result == false) break;

            result = TestCase("leetcode", new List<string> { "leet", "code" }, true);
            if (result == false) break;

            result = TestCase("applepenapple", new List<string> { "apple", "pen" }, true);
            if (result == false) break;

            result = TestCase("catsandog", new List<string> { "cats", "dog", "sand", "and", "cat" }, false);
            if (result == false) break;

            break;
        }
    }
}

