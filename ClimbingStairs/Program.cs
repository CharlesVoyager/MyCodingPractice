// 70. Climbing Stairs

/*
Testcase:
n: 2, Expected: 2
n: 3, Expected: 3
n: 4, Expected: 5
n: 44, Expected: 1,134,903,170
n: 45, Expected: 1,836,311,903
 */

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


        distinctWays = test.ClimbStairs(5);    // Expected: 8
        Console.WriteLine("Steps 5: " + distinctWays.ToString());

        distinctWays = test.ClimbStairs(4);    // Expected: 5
        Console.WriteLine("Steps 4: " + distinctWays.ToString());

        //distinctWays = test.ClimbStairs(44);    // Expected: 1,134,903,170
        //Console.WriteLine("Steps 44: " + distinctWays.ToString());
    }
}
