// 139. Word Break
public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        Stack<(string, int)> currentWords = new Stack<(string, int)>();

        foreach (string word in wordDict)
        {
            if (s.StartsWith(word))
                currentWords.Push((word, word.Length));
        }

        while (currentWords.Count > 0)
        {
            (string w, int pos) = currentWords.Pop();
            if (pos == s.Length)
                return true;

            foreach (string word in wordDict)
            {
                if (pos < s.Length && s.Substring(pos).StartsWith(word))
                    currentWords.Push((word, pos + word.Length));
            }
        }
        return false;
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

