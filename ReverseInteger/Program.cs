// 7. Reverse Integer

public class Solution
{
    public int Reverse(int x)
    {
        int lastResult = 0;
        int currentResult = 0;
        int beginDigitIndex = 0;

        string s = x.ToString();

        if (s[0] != '-')
        {
            currentResult = s[0] - '0';
            lastResult = currentResult;
            beginDigitIndex++;
        }

        for (int i = 1; i < s.Length; i++)
        {
            currentResult += (s[i] - '0') * (int)Math.Pow(10, beginDigitIndex++);
            if (currentResult < lastResult)
                return 0;

            lastResult = currentResult;
        }

        if (s[0] == '-')
            return currentResult * (-1);

        return currentResult;
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

        result = test.TestCase(1534236469, 0);


        result = test.TestCase(-123, -321);
        result = test.TestCase(0, 0);

    }
}