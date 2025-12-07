public class Solution
{
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