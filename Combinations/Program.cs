// 77. Combinations

public class Solution
{

    IList<IList<int>> results = new List<IList<int>>();
    List<int> current = new List<int>();
    int[] nums;
    int requiredLength;

    public IList<IList<int>> Combine(int n, int k)
    {
        nums = new int[n];
        for (int i = 0; i < n; i++)
            nums[i] = i + 1;

        requiredLength = k;

        BackTracking(0, current);
        return results;
    }

    void BackTracking(int index, List<int> current)
    {
        if (index == nums.Length)
        {
            if (current.Count() == requiredLength)
            results.Add(new List<int>(current));
            return;
        }

        current.Add(nums[index]);
        BackTracking(index + 1, current);
        current.RemoveAt(current.Count() - 1);
        BackTracking(index + 1, current);
    }

}

class Program
{
    public static void Main()
    {
        Solution test = new Solution();

        IList<IList<int>> results = test.Combine(4, 2);

        foreach (IList<int> combin in results) 
        { 
            foreach(int i in combin)
                Console.Write(" " + i);

            Console.WriteLine();    
        }

    }
}