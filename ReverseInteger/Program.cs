// 7. Reverse Integer

public class Solution
{
    public int Reverse(int x)
    {
        int result = 0;
        int beginDigitIndex = 0;

        string s = x.ToString();

        if (s[0] != '-')
        {
            result = s[0] - '0';
            beginDigitIndex++;
        }

        for (int i = 1; i < s.Length; i++)
            result += (s[i] - '0') * (int)Math.Pow(10, beginDigitIndex++);

        string reverseResult = new string(result.ToString().Reverse().ToArray());

        // cut '0' in the last digits in s.
        int endIndex = -1;
        if (s.Length > 1) 
        { 
            for (int i= s.Length-1; i >= 0;  i--) 
            { 
                if (s[i] != '0')
                {
                    endIndex = i;
                    break;
                }
            }
            if (endIndex != -1)
                s = s.Substring(0, endIndex + 1);
        }

        if (s[0] == '-')
        {
            reverseResult = "-" + reverseResult;
            if (s != reverseResult)
                return 0;

            return result * (-1);
        }
        if (s != reverseResult)
            return 0;

        return result;
    }

    public bool TestCase(int x, int expected)
    {
        int output = Reverse(x);

        Console.WriteLine("Input: " + x + " Output: " + output + " Expected: " + expected + " Result: " + (output == expected ? "PASS" : "FAIL"));
   
        return output == expected; 
    }
}
class Program
{
    public static void Main()
    {
        bool result;
        Solution test = new Solution();

        result = test.TestCase(10, 1);

        result = test.TestCase(-120, -21);

        result = test.TestCase(120, 21);

        result = test.TestCase(1534236469, 0);

        result = test.TestCase(-123, -321);

        result = test.TestCase(0, 0);

    }
}