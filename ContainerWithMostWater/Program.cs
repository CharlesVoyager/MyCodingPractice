// 11. Container With Most Water
public class Solution
{
    public int MaxArea(int[] height)
    {
        int maxSoFar = 0;
        int leftLineIndex = 0;
        int rightLineIndex = height.Length - 1;

        while (leftLineIndex < rightLineIndex)
        { 
            maxSoFar = Math.Max(maxSoFar, (rightLineIndex - leftLineIndex) * Math.Min(height[leftLineIndex], height[rightLineIndex]));
       
            if (height[leftLineIndex] < height[rightLineIndex]) 
                leftLineIndex++; 
            else if (height[leftLineIndex] > height[rightLineIndex])
                rightLineIndex--;
            else
                leftLineIndex++;
        }
        
        return maxSoFar;
    }

#if false   // Fail: Time limit exceeded.
    public int MaxArea(int[] height)
    {
        int maxSoFar = 0;

        for (int i = 0; i < height.Length; i++) 
        { 
            for (int j = i + 1; j < height.Length; j++)
            {
                maxSoFar = Math.Max(maxSoFar, (j - i) * Math.Min(height[i], height[j]));
                if (height[j] > height[i])
                    break;
            }
        }
        return maxSoFar;
    }

#endif

    public bool Test(int[] height, int expected)
    {
        int output = MaxArea(height);

        Console.Write("Input:");
        for (int i = 0; i < Math.Min(height.Length, 10); i++)
            Console.Write(" " + height[i]);

        Console.WriteLine(", Output: " + output + ", Expected: " + expected + ", Result: " + (output == expected ? "PASS" : "FAIL"));
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
            result = test.Test(new int[] { 1, 2, 1 }, 2);
            if (result == false) break;
            result = test.Test(new int[] { 1, 2 }, 1);
            if (result == false) break;
            result = test.Test(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49);
            if (result == false) break;
            result = test.Test(new int[] { 1, 1 }, 1);
            if (result == false) break;

            break;
        }
    }
}