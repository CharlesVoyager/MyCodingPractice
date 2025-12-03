
using System.Xml.Linq;

class Solution
{
    void DivideConquer(int[] arr, out int subArrIndex, out int subArrLen)
    {
        if (arr.Length <= 1)
        {
            subArrIndex = 0;
            subArrLen = 1;
            return;
        }

        int mid = arr.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[arr.Length - mid];

        Array.Copy(arr, 0, left, 0, mid);
        Array.Copy(arr, mid, right, 0, arr.Length - mid);

        int leftSubArrIndex;
        int leftSubArrLen;
        int rightSubArrIndex;
        int rightSubArrLen;
        DivideConquer(left, out leftSubArrIndex, out leftSubArrLen);
        DivideConquer(right, out rightSubArrIndex, out rightSubArrLen);

        Merge(arr, out subArrIndex, out subArrLen,
            left, leftSubArrIndex, leftSubArrLen,
            right, rightSubArrIndex, rightSubArrLen);
    }

    struct SubArrayRange 
    {
        public int StartIndex;
        public int Length;

        public SubArrayRange(int startIndex, int length)
        {
            StartIndex = startIndex;
            Length = length;
        }
    }

    void Merge(int[] arr, out int subArrIndex, out int subArrLen,
        int[] left, int leftSubArrIndex, int leftSubArrLen,
        int[] right, int rightSubArrIndex, int rightSubArrLen)
    {
        int leftSubArrMaxSum = 0;
        int rightSubArrMaxSum = 0;

        for (int i = leftSubArrIndex; i < leftSubArrIndex + leftSubArrLen; i++)
            leftSubArrMaxSum += left[i];

        for (int i = rightSubArrIndex; i < rightSubArrIndex + rightSubArrLen; i++)
            rightSubArrMaxSum += right[i];

        int gapLength = left.Length - (leftSubArrIndex + leftSubArrLen) + rightSubArrIndex;

        int mergeSubArrSum = 0;
        int mergeSubArrLen = leftSubArrLen + gapLength + rightSubArrLen;
        Dictionary<SubArrayRange, int> tempSubSums = new Dictionary<SubArrayRange, int>();
        KeyValuePair<SubArrayRange, int> mergeMaxSumSub = new KeyValuePair<SubArrayRange, int>();

        // Fix startIndex
        // startIndex: leftSubArrIndex
        // length: 1 up to mergeSubArrLen
        for (int i = leftSubArrIndex; i < leftSubArrIndex + mergeSubArrLen; i++)
        {
            mergeSubArrSum += arr[i];
            SubArrayRange subArrayRange = new SubArrayRange(leftSubArrIndex, i - leftSubArrIndex + 1);
            tempSubSums.Add(subArrayRange, mergeSubArrSum);
        }

        // Fix endIndex
        // startIndex: leftSubArrIndex
        // endIndex: leftSubArrIndex + mergeSubArrLen - 1
        for (int i = leftSubArrIndex + 1; i < leftSubArrIndex + leftSubArrLen + gapLength; i++)
        {
            int tempSum = 0;
            for (int j = i;  j < leftSubArrIndex + mergeSubArrLen; j++)
                tempSum += arr[j];

            SubArrayRange subArrayRange = new SubArrayRange(i, leftSubArrIndex + mergeSubArrLen - i);
            tempSubSums.Add(subArrayRange, tempSum);
        }

        if (tempSubSums.Count() > 0)
            mergeMaxSumSub = tempSubSums.MaxBy(kvp => kvp.Value);
        else
        {
            Console.WriteLine("Error");
        }

        if (leftSubArrMaxSum >= rightSubArrMaxSum && leftSubArrMaxSum >= mergeSubArrSum)
        {
            subArrIndex = leftSubArrIndex;
            subArrLen = leftSubArrLen;
        }
        else if (rightSubArrMaxSum >= leftSubArrMaxSum && rightSubArrMaxSum >= mergeSubArrSum)
        {
            subArrIndex = left.Length + rightSubArrIndex;
            subArrLen = rightSubArrLen;
        }
        else
        {
            subArrIndex = mergeMaxSumSub.Key.StartIndex;
            subArrLen = mergeMaxSumSub.Key.Length;
        }
    }

    public int MaxSubArray(int[] nums)
    {
        int subArrIndex;
        int subArrLen;
        int maxSum = 0;

        DivideConquer(nums, out subArrIndex, out subArrLen);

        for (int i = subArrIndex; i < subArrIndex + subArrLen; i++)
            maxSum += nums[i];

        return maxSum;
    }

    public int MaxSubArrayKadane(int[] nums)
    {
        int maxSoFar = nums[0];
        int currentMax = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            currentMax = Math.Max(nums[i], currentMax + nums[i]);
            maxSoFar = Math.Max(maxSoFar, currentMax);
        }
        return maxSoFar;
    }


    public bool TestCase(int[] nums, int expected)
    {
#if false
        int maxSum = MaxSubArray(nums);
#else
        int maxSum = MaxSubArrayKadane(nums);
#endif

        Console.Write("Nums:");
        for (int i = 0; i < Math.Min(nums.Length, 10); i++)
            Console.Write(" " + nums[i]);

        Console.Write(", Output: " + maxSum + ", Expected: " + expected + ", Result: " + (maxSum == expected ? "PASS" : "FAIL"));

        Console.WriteLine("");

        if (maxSum == expected) return true;
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
            string fileContent = File.ReadAllText("BigIntArray.txt");   // Expected: 11,081 // Output: 10,732
            string[] stringNumbers = fileContent.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] nums = stringNumbers.Select(int.Parse).ToArray();

            result = solution.TestCase(nums, 11081);
            if (!result) break;

            result = solution.TestCase(new int[] { -2, 3, 1, 5 }, 9);
            if (!result) break;

            result = solution.TestCase(new int[] { 0, -3, -2, -3, -2, 2, -3, 0, 1, -1 }, 2);
            if (!result) break;

            result = solution.TestCase(new int[] { 5, 4, -1, 7, 8 }, 23);
            if (!result) break;

            result = solution.TestCase(new int[] { 0, -3, -2, -3, -2, 2, -3, 0, 1, -1 }, 2);
            if (!result) break;

            result = solution.TestCase(new int[] { 2, -1, -1, 2, 0, -3, 3 }, 3);
            if (!result) break;

            result = solution.TestCase(new int[] { 3, -3, 2, -3 }, 3);
            if (!result) break;

            result = solution.TestCase(new int[] { 2, -1, -1, 2, 0, -3, 3 }, 3);
            if (!result) break;

            result = solution.TestCase(new int[] { 1, -1, -2 }, 1);
            if (!result) break;

            result = solution.TestCase(new int[] { -2, 3, 1, 5 }, 9);
            if (!result) break;

            result = solution.TestCase(new int[] { 2, 3, 1, 5 }, 11);
            if (!result) break;

            result = solution.TestCase(new int[] { -2, -3, -1, -1 }, -1);
            if (!result) break;

            //                        MaxSumIndex: 0,                                                         MinSumIndex: 17
            result = solution.TestCase(new int[] { 9, 0, -2, -2, -3, -4, 0, 1, -4, 5, -8, 7, -3, 7, -6, -4, -7, -8 }, 11);
            if (!result) break;


            //0  1   .. ..MinIndex: 6 
            result = solution.TestCase(new int[] { -1, 1, -3, -2, 2, -1, -2, 1, 2, -3 }, 3);
            if (!result) break;

            //0   .. ......4..................9
            result = solution.TestCase(new int[] { 7, -2, 6, 2, 4, -5, -9, -8, -4, -3 }, 17);
            if (!result) break;

            result = solution.TestCase(new int[] { -3, 1, -2, 2 }, 2);
            if (!result) break;

            result = solution.TestCase(new int[] { 2, -3, 1, 1 }, 2);
            if (!result) break;

            result = solution.TestCase(new int[] { 1 }, 1);
            if (!result) break;


            result = solution.TestCase(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6);
            if (!result) break;

            result = solution.TestCase(new int[] { 0, -3, 1, 1 }, 2);
            if (!result) break;

            Console.WriteLine("All Test Cases Passed.");

            break;
        }



        Console.ReadLine();
    }
}