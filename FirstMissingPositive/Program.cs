public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        if (nums == null || nums.Length == 0) return 1;

        List<int> listNums = nums.ToList();

        listNums.Sort();

        // Remove negative and 0.
        while (listNums.Count > 0)
        {
            if (listNums[0] <= 0)
                listNums.RemoveAt(0);
            else
                break;
        }

        if (listNums.Count == 0)
            return 1;

        int curMissingPostive = 1;
        while (listNums.Count > 0) 
        {
            if (listNums[0] == curMissingPostive)
            {
                listNums.RemoveAt(0);

                // Remove duplicates.
                while (listNums.Count > 0 && listNums[0] == curMissingPostive)
                        listNums.RemoveAt(0);

                curMissingPostive++;
            }
            else
                break;
        }

        return curMissingPostive;
    }

    public bool TestCase(int[] nums, int expected)
    {
#if false
        int maxSum = MaxSubArray(nums);
#else
        int output = FirstMissingPositive(nums);
#endif

        Console.Write("Nums:");
        for (int i = 0; i < Math.Min(nums.Length, 10); i++)
            Console.Write(" " + nums[i]);

        Console.Write(", Output: " + output + ", Expected: " + expected + ", Result: " + (output == expected ? "PASS" : "FAIL"));

        Console.WriteLine("");

        if (output == expected) return true;
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
            result = solution.TestCase(new int[] { 1, 2, 3 }, 4);
            if (!result) break;

            result = solution.TestCase(new int[] { 0, 2, 2, 1, 1 }, 3);
            if (!result) break;

            result = solution.TestCase(new int[] { 1, 2, 0 }, 3);
            if (!result) break;

            result = solution.TestCase(new int[] { 3, 4, -1, 1 }, 2);
            if (!result) break;

            result = solution.TestCase(new int[] { 7, 8, 9, 11, 12 }, 1);
            if (!result) break;

            Console.WriteLine("All Test Cases Passed.");

            break;
        }
        Console.ReadLine();
    }
}