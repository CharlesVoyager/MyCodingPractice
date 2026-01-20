// 67. Add Binary

public class Solution
{
    public string AddBinary(string a, string b)
    {
        int maxLen = Math.Max(a.Length, b.Length);
        ReverseStringInplace(ref a);
        ReverseStringInplace(ref b);

        char carry = '0';
        string output = "";
        char sum;
        for (int i = 0; i < maxLen; i++)
        {
            if (i >= a.Length)
                sum = ComputeSum('0', b[i], ref carry);
            else if (i >= b.Length)
                sum = ComputeSum(a[i], '0', ref carry);
            else
                sum = ComputeSum(a[i], b[i], ref carry);

            output += sum;
        }
        if (carry == '1')
            output += carry;

        ReverseStringInplace(ref output);
        return output;
    }

    void ReverseStringInplace(ref string s)
    {
        char[] charArray = s.ToCharArray();

        int left = 0;
        int right = s.Length - 1;
        while (left < right)
        {
            char temp = s[left];
            charArray[left] = s[right];
            charArray[right] = temp;
            left++;
            right--;
        }
        s = new string(charArray);
    }   

    char ComputeSum(char a, char b, ref char carry)
    {
        int sum = (a - 0x30) + (b - 0x30) + (carry - 0x30);
        if (sum == 0)
        {
            carry = '0';
            return '0';
        }
        else if (sum == 1)
        {
            carry = '0';
            return '1';
        }
        else if (sum == 2)
        {
            carry = '1';
            return '0';
        }
        else if (sum == 3)
        {
            carry = '1';
            return '1';
        }
        return ' ';  // Should never happen here.      
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        string a = "10";
        string b = "10";
        string result = solution.AddBinary(a, b);
        Console.WriteLine($"AddBinary({a}, {b}) = {result}");  // Expected output: "100"

        a = "11";
        b = "1";
        result = solution.AddBinary(a, b);
        Console.WriteLine($"AddBinary({a}, {b}) = {result}");  // Expected output: "100"

        a = "1010";
        b = "1011";
        result = solution.AddBinary(a, b);
        Console.WriteLine($"AddBinary({a}, {b}) = {result}");  // Expected output: "10101"
    }
}