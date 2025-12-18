// 70. Climbing Stairs

/*
Testcase:
n: 2, Expected: 2
n: 3, Expected: 3
n: 4, Expected: 5
n: 44, Expected: 1,134,903,170
*/

// Test case n: 44. The output is correct but time limit exceeded.
public class Solution
{
    int targetSteps = 0;
    int distinctWaysCount = 0;
    bool WalkOneStep(int stpesSoFar)
    {
        stpesSoFar++;
        if (stpesSoFar == targetSteps)
        {
            distinctWaysCount++;
            return true;
        }

        WalkOneStep(stpesSoFar);
        WalkTwoSteps(stpesSoFar);

        return false;
    }

    bool WalkTwoSteps(int stpesSoFar)
    {
        stpesSoFar++;
        stpesSoFar++;
        if (stpesSoFar == targetSteps)
        {
            distinctWaysCount++;
            return true;
        }

        if (stpesSoFar > targetSteps)
            return true;

        WalkOneStep(stpesSoFar);
        WalkTwoSteps(stpesSoFar);

        return false;
    }


    public int ClimbStairs(int n)
    {
        targetSteps = n;

        if (targetSteps == 1)
            return 1;

        WalkOneStep(0);
        WalkTwoSteps(0);
        return distinctWaysCount;
    }
}

class Program
{
    public static void Main()
    {
        Solution test = new Solution();
        int distinctWays = test.ClimbStairs(44);

        Console.WriteLine("Steps 44: " + distinctWays.ToString());
    }
}
