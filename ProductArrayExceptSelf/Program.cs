public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int[] prefix =new int[nums.Length];
        int[] suffix = new int[nums.Length];
        int[] output = new int[nums.Length];

        // prefix
        prefix[0] = nums[0];
        for (int i = 1; i < prefix.Length - 1; i++) 
            prefix[i] = prefix[i - 1] * nums[i];

        // suffix
        suffix[suffix.Length - 1] = nums[nums.Length - 1];
        for (int i = suffix.Length - 2; i > 0; i--)
            suffix[i] = suffix[i + 1] * nums[i];

        // output
        for (int i = 0; i < output.Length; i++) 
        {
            if (i == 0) 
                output[i] = suffix[0 + 1];
            else if ( i == output.Length - 1)
                output[i] = prefix[prefix.Length - 2];
            else
                output[i] = prefix[i - 1] * suffix[i + 1];
        }
        return output;
    }

    public bool TestCase(int[] nums, int[] expected)
    {
#if false
        int maxSum = MaxSubArray(nums);
#else
        int[] output = ProductExceptSelf(nums);
#endif

        Console.Write("Input:");
        for (int i = 0; i < Math.Min(nums.Length, 10); i++)
            Console.Write(" " + nums[i]);

        Console.WriteLine("");

        Console.Write("Output:");
        for (int i = 0; i < Math.Min(output.Length, 10); i++)
            Console.Write(" " + output[i]);

        Console.WriteLine("");

        Console.Write("Expected:");
        for (int i = 0; i < Math.Min(expected.Length, 10); i++)
            Console.Write(" " + expected[i]);

        Console.WriteLine("");

        Console.Write("Result: ");
        Console.Write(output.SequenceEqual(expected) ? "PASS" : "FAIL");
        
        Console.WriteLine("");
        Console.WriteLine("");

        if (output.SequenceEqual(expected)) return true;
        else return false;
    }
}


class Program
{
    static void Main()
    {
        bool result = false;
        Solution solution = new Solution();

        while (true)
        {
            result = solution.TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6});
            if (!result) break;

            result = solution.TestCase(new int[] { -1, 1, 0, -3, 3 }, new int[] { 0, 0, 9, 0, 0 });
            if (!result) break;

            Console.WriteLine("All Test Cases Passed.");

            break;
        }
        Console.ReadLine();
    }
}