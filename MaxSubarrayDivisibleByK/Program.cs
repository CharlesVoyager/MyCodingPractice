using Microsoft.VisualBasic;
using System.Globalization;

public class Solution
{
    // 3381. Maximum subarray sum with length divisible by K.
    public long MaxSubarraySum(int[] nums, int k)
    {
        long firstK = 0;
        long maxSoFar = 0;
        long currentMax = 0;

        int shiftPos = 0;
        int arrayLength = nums.Length;

        long maxSubarray = long.MinValue;

        for (int m = 0; m < k; m++)
        {
            shiftPos = m;
            arrayLength = nums.Length - m;

            if ( arrayLength >= k)
            {
                if (m == 0)
                {
                    for (int i = 0; i < k; i++)       // First subarray
                        maxSoFar += nums[i + shiftPos];

                    firstK = maxSoFar;
                }
                else
                {
                    maxSoFar = firstK - nums[m - 1] + nums[m + k - 1];
                    firstK = maxSoFar;
                }
                currentMax = maxSoFar;

                for (int i = 1; i < arrayLength / k; i++)
                {
                    long chunk = 0;
                    for (int j = 0; j < k; j++)
                        chunk += nums[ i * k + j + shiftPos];

                    currentMax = Math.Max(chunk, currentMax + chunk);
                    maxSoFar = Math.Max(maxSoFar, currentMax);
                }
            }
            maxSubarray = Math.Max(maxSubarray, maxSoFar);

            //Console.Write("m: " + m.ToString() + "\r");
        }
        return maxSubarray;
    }

    public bool TestCase(int[] nums, int k, int expected)
    {
        long result = MaxSubarraySum(nums, k);

        Console.Write("Nums:");
        for (int i = 0; i < Math.Min(nums.Length, 10); i++)
            Console.Write(" " + nums[i]);

        Console.Write(", K: " + k.ToString() + ", Output: " + result + ", Expected: " + expected + ", Result: " + (result == expected ? "PASS" : "FAIL"));

        Console.WriteLine();

        return result == expected;
    }
}


class Program
{
    public static void Main()
    {
        Solution test = new Solution();
        bool result;

        while (true)
        {
            result = test.TestCase(new int[] { -41, -40, 1, -28, -14 }, 3, -41);
            if (result == false) break;

            string fileContent = File.ReadAllText("TestCase657.txt");   // TestCaseBigData.txt
            string[] stringNumbers = fileContent.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] nums = stringNumbers.Select(int.Parse).ToArray();

            result = test.TestCase(nums, 100000, 300354);
            if (result == false) break;

            result = test.TestCase(new int[] { -41, -40, 1, -28, -14 }, 3, -41);
            if (result == false) break;

            result = test.TestCase(new int[] { -47, 24, -18, -4, -23 }, 3, 2);
            if (result == false) break;


            result = test.TestCase(new int[] { -1747, 1443, 1776, 767, -697, -1713, -18, 439, 1680 }, 2, 3677);
            if (result == false) break;


            result = test.TestCase(new int[] { 44, 24, -37, 96, -18, -6, -48 }, 2, 127);
            if (result == false) break;


            result = test.TestCase(new int[] { -791, 576, 262, -770, 823, -153, -419, 393 }, 3, 319);
            if (result == false) break;



            result = test.TestCase(new int[] { -864, -516, -550, 23, 621, -741, -13, -156 }, 1, 644);
            if (result == false) break;


            result = test.TestCase(new int[] { 34, 9, 14, -50, -17 }, 2, 43);
            if (result == false) break;


            result = test.TestCase(new int[] { -43, -49, 34, -46, 32 }, 2, -12);
            if (result == false) break;

            result = test.TestCase(new int[] { -47, 24, -18, -4, -23 }, 3, 2);
            if (result == false) break;

            result = test.TestCase(new int[] { 47, 28, -35, -40, 39 }, 3, 40);
            if (result == false) break;


            result = test.TestCase(new int[] { -11, 8, -17 }, 1, 8);
            if (result == false) break;

            result = test.TestCase(new int[] { 98, 47, -22, -74, 0, 71, 33 }, 2, 145);
            if (result == false) break;

            result = test.TestCase(new int[] { 45, 13, -26, -15, 31, 33, 33 }, 4, 82);
            if (result == false) break;

            result = test.TestCase(new int[] { -50, -78, -44, -57, -61, 39, 29 }, 1, 68);
            if (result == false) break;

            result = test.TestCase(new int[] { -49, -20, 19, 24, -42 }, 5, -68);
            if (result == false) break;

            result = test.TestCase(new int[] { -41, -32, -16, 35, -20 }, 1, 35);
            if (result == false) break;

            result = test.TestCase(new int[] { 98, 47, -22, -74, 0, 71, 33 }, 2, 145);
            if (result == false) break;

            result = test.TestCase(new int[] { 44, 24, -37, 96, -18, -6, -48 }, 2, 127);
            if (result == false) break;

            result = test.TestCase(new int[] { 47, 28, -35, -40, 39 }, 3, 40);
            if (result == false) break;

            result = test.TestCase(new int[] { -37, -37, -35, 7 }, 2, -28);
            if (result == false) break;

            result = test.TestCase(new int[] { -30, 35, -32, -71, 60, -37, 63 }, 5, -17);
            if (result == false) break;

            result = test.TestCase(new int[] { 14, 1, -45, 31 }, 2, 15);
            if (result == false) break;

            result = test.TestCase(new int[] { -66, -4, -83, -29, 99, -49, 63 }, 2, 84);
            if (result == false) break;

            result = test.TestCase(new int[] { -95, -48, -18, -24, -43, -79, -24 }, 2, -42);
            if (result == false) break;

            result = test.TestCase(new int[] { 39, -35, 44, 39, -18 }, 1, 87);
            if (result == false) break;

            result = test.TestCase(new int[] { 22, 24, 40, 26, 34 }, 3, 100);
            if (result == false) break;

            result = test.TestCase(new int[] { 17, -8, 24, 17, -17 }, 2, 50);
            if (result == false) break;

            result = test.TestCase(new int[] { 0, -5 }, 1, 0);
            if (result == false) break;



            result = test.TestCase(new int[] { 24, -29, -7, 5, -6 }, 2, -1);
            if (result == false) break;

            result = test.TestCase(new int[] { -5, 1, 2, -3, 4 }, 2, 4);
            if (result == false) break;

            result = test.TestCase(new int[] { 1, 2 }, 1, 3);
            if (result == false) break;

            result = test.TestCase(new int[] { -10, 4 }, 1, 4);
            if (result == false) break;

            result = test.TestCase(new int[] { -17, -1, 20 }, 3, 2);
            if (result == false) break;

            result = test.TestCase(new int[] { 0, 9, 7 }, 2, 16);
            if (result == false) break;

            result = test.TestCase(new int[] { 11, 3, 8 }, 2, 14);
            if (result == false) break;

            result = test.TestCase(new int[] { -11, -16, 40, 0 }, 2, 40);
            if (result == false) break;

            result = test.TestCase(new int[] { 28, -3, 18, 29 }, 2, 72);
            if (result == false) break;

            result = test.TestCase(new int[] { 29, -5, 42, 18 }, 3, 66);
            if (result == false) break;

            result = test.TestCase(new int[] { 10, -35, 48, -17 }, 1, 48);
            if (result == false) break;

            result = test.TestCase(new int[] { 35, -33, -11, 17 }, 2, 8);
            if (result == false) break;

            result = test.TestCase(new int[] { -48, 35, 22, -31, 7 }, 3, 26);
            if (result == false) break;

            result = test.TestCase(new int[] { -85, 86, 54, -32, -4, 40, -28 }, 3, 116);
            if (result == false) break;

            result = test.TestCase(new int[] { -66, -4, -83, -29, 99, -49, 63 }, 2, 84);
            if (result == false) break;

            result = test.TestCase(new int[] { -72, 45, -27, -62, -14, 63, 32 }, 5, 5);
            if (result == false) break;

            break;
        }

        if (result)
            Console.WriteLine("ALL TEST CASES PASS");
    }
}