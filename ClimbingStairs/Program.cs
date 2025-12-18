// 70. Climbing Stairs

/*
Testcase:
n: 2, Expected: 2
n: 3, Expected: 3
n: 4, Expected: 5
n: 44, Expected: 1,134,903,170
n: 45, Expected: 1,836,311,903
 */

public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n == 1) return 1;

        int[] ways = new int[n + 1];
        ways[0] = 1;
        ways[1] = 1;

        for (int i = 2; i < n + 1; i++)
            ways[i] = ways[i - 1] + ways[i - 2];

        return ways[n];
    }
}

#if false
// Submission is accepeted: Runtime 0ms, Beats 100%.
public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n == 1) return 1;

        int currentSteps = 2;
        int currentDistinctWays = 2;
        int peviousDistinctWaysEndsWithOneStep = 0;
        int currentDistinctWaysEndsWithOneStep = 1;

        currentSteps++;
        while (currentSteps <= n)
        {
            int peviousDistinctWaysEndsWithOneStepSave = currentDistinctWaysEndsWithOneStep;
            currentDistinctWaysEndsWithOneStep += peviousDistinctWaysEndsWithOneStep;
            currentDistinctWays += currentDistinctWaysEndsWithOneStep;
            peviousDistinctWaysEndsWithOneStep = peviousDistinctWaysEndsWithOneStepSave;
            currentSteps++;

        }

        return currentDistinctWays;
    }
}
#endif

#if false
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

#endif


class Program
{
    public static void Main()
    {
        Solution test = new Solution();
        int distinctWays;

        for (int i = 2; i < 46; i++)
        {
            distinctWays = test.ClimbStairs(i);   
            Console.WriteLine( i + " Stairs: " + distinctWays.ToString());
        }

        //distinctWays = test.ClimbStairs(5);    // Expected: 8
        //Console.WriteLine("5 Stairs: " + distinctWays.ToString());

        //distinctWays = test.ClimbStairs(4);    // Expected: 5
        //Console.WriteLine("4 Stairs: " + distinctWays.ToString());

        ////distinctWays = test.ClimbStairs(44);    // Expected: 1,134,903,170
        ////Console.WriteLine("44 Stairs: " + distinctWays.ToString());
    }
}
