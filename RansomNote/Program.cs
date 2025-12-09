// 383. Ransom Note

public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        foreach (char ransom in ransomNote)
        {
            int index = magazine.IndexOf(ransom);
            if (index != -1)
                magazine = magazine.Remove(index,1);
            else
                return false;
        }
        return true;
    }

    public bool Test(string ransomNote, string magazine, bool expected)
    {
        bool output = CanConstruct(ransomNote, magazine);
        Console.WriteLine("ransomNote: " + ransomNote + " magazine: " + magazine + " Output: " + output + ", Expected: " + expected + ", Result: " + (output == expected ? "PASS" : "FAIL"));
        return output == expected;
    }
}


class Program
{
    public static void Main()
    {
        bool result;
        Solution test = new Solution();

        while (true)
        {
            result = test.Test("aa", "ab", false);
            if (result == false) break;

            result = test.Test("aa", "aab", true);
            if (result == false) break;

            result = test.Test("a", "b", false);
            if (result == false) break;

            result = test.Test("HELLO", "23432fsdHsdgE4352L34rLLgrOefg434", true);
            if (result == false) break;

            break;
        }
    }
}