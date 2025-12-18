// 371. Sum of two integers.

public class Solution
{
    public int GetSum(int a, int b)
    {
        int xorSum = a ^ b;
        int carry = (a & b) << 1;
        while (carry != 0)
        {
            int tempSum = xorSum ^ carry;
            carry = (xorSum & carry) << 1;
            xorSum = tempSum;
        }
        return xorSum;
    }
}

class Program
{
    public static void Main()
    {
        Solution test = new Solution();
        int result;
        result = test.GetSum(1, 3); // Output: 14, Expected: 16
        //result = test.GetSum(9, 7); // Output: 14, Expected: 16
        Console.WriteLine(result);
    }
}