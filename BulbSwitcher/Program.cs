// 319. Bulb Switcher

public class Solution
{
    public int BulbSwitch(int n)
    {
        if (n == 0)
            return 0;

        int steps = 3;
        int curBulbId = 1;
        int bulbsOnCount = 1;
        while (true)
        {
            curBulbId += steps;

            if (n < curBulbId)
                return bulbsOnCount;
            else
            {
                bulbsOnCount++;
                steps += 2;
            }
        }
    }
}

class Program
{
    public static void Main()
    {
        Solution test = new Solution();

        int n;

        n = 0;         // Expected output: 0
        Console.WriteLine(n + ": " + test.BulbSwitch(n));

        n = 10;         // Expected output: 3
        Console.WriteLine(n + ": " + test.BulbSwitch(n));

        n = 10000;      // Expected output: 100
        Console.WriteLine(n + ": " + test.BulbSwitch(n));

        n = 100000;     // Expected output: 316
        Console.WriteLine(n + ": " + test.BulbSwitch(n));

        n = 1000000;    // Expected output: 1000
        Console.WriteLine(n + ": " + test.BulbSwitch(n));

        n = 1000000000; // Expected output: 31622
        Console.WriteLine(n + ": " + test.BulbSwitch(n));

    }
}