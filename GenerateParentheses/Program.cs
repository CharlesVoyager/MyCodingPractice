// 22. Generate Parentheses

public class Solution
{
    int targetN = 0;
    List<string> results = new List<string>();

    void AddLeftParenthes(string currentStr)
    {
        int leftCount = 0;
        foreach (char c in currentStr)
            if (c == '(')
                leftCount++;

        if (leftCount < targetN)
        {
            AddLeftParenthes(currentStr + "(");

            int rightCount = 0;
            foreach (char c in currentStr)
                if (c == ')')
                    rightCount++;

            if (rightCount < targetN)
                AddRightParenthes(currentStr + ")");
        }
        else
            AddRightParenthes(currentStr + ")");

    }

    void AddRightParenthes(string currentStr)
    {
        int leftCount = 0;
        foreach (char c in currentStr)
            if (c == '(')
                leftCount++;

        int rightCount = 0;
        foreach (char c in currentStr)
            if (c == ')')
                rightCount++;

        if (leftCount < targetN)
            AddLeftParenthes(currentStr + "(");

        if (rightCount < leftCount)
            AddRightParenthes(currentStr + ")");
      
        if (rightCount == targetN)
            results.Add(currentStr);
    }

    public IList<string> GenerateParenthesis(int n)
    {
        targetN = n;
        AddLeftParenthes("(");
        return results;
    }
}

class Program
{
    static void Main()
    {
        Solution test = new Solution();

        IList<string> results = test.GenerateParenthesis(8);  

        foreach (string s in results)
            Console.WriteLine(s);
    }
}