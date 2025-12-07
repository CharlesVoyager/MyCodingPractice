// 6. Zigzag Conversion.
public class Solution
{
    struct COORDINATE
    {
        public char C;
        public int X;
        public int Y;

        public COORDINATE(char _c, int _x, int _y)
        {
            C = _c;
            X = _x;
            Y = _y;
        }
    }
    public string Convert(string s, int numRows)
    {
        int zigZagLength = (numRows - 1) * 2;
        if (zigZagLength <= 0) return s;
        int numZigZags = s.Length / zigZagLength;

        if (s.Length % zigZagLength > 0)
            numZigZags++;

        List<COORDINATE> coordinates = new List<COORDINATE>();

        int currentZigZagX = 0;

        for (int i = 0; i < numZigZags; i++)
        {
            for ( int j = 0; j < zigZagLength; j++)
            {
                int reminder = j % zigZagLength;
                int positionInStr = i * zigZagLength + j;
                if (positionInStr >= s.Length)
                    break;
                if (reminder < numRows)
                {
                    coordinates.Add(new COORDINATE(s[positionInStr], currentZigZagX, reminder));
                }
                else
                {
                    int y = (reminder - (numRows - 1)) % (numRows - 1);
                    coordinates.Add(new COORDINATE(s[positionInStr], ++currentZigZagX, (numRows - 1) - y));
                }

            }
            currentZigZagX++;
        }

        var sorted = coordinates.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();

        string result = "";
        foreach (var item in sorted)
            result += item.C;

        return result;
    }

    public bool Test(string s, int numRows, string expected)
    {
        string output = Convert(s, numRows);
        Console.WriteLine("Input: " + s + " numRows: " + numRows);
        Console.WriteLine("Output:   " + output);
        Console.WriteLine("Expected: " + expected);
        Console.WriteLine("Result: " + (output == expected ? "PASS" : "FAIL"));
        return output == expected;  
    }
}
class Program
{
    public static void Main()
    {
        bool result;
        Solution test = new Solution();
        result = test.Test("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR");
        result = test.Test("PAYPALISHIRING", 4, "PINALSIGYAHRPI");
        result = test.Test("A", 1, "A");
    }
}