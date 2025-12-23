// 836. Rectangle Overlap

public class Solution
{
    bool AreTwoLinesOverlap(int[] line1, int[] line2)
    {
        if(line1.SequenceEqual(line2)) return true;

        // Check line1[0] is in line2
        if (line2[0] < line1[0] && line1[0] < line2[1]) return true;

        // Check line1[1] is in line2
        if (line2[0] < line1[1] && line1[1] < line2[1]) return true;

        // Check line2[0] is in line1
        if (line1[0] < line2[0] && line2[0] < line1[1]) return true;

        // Check line2[1] is in line1
        if (line1[0] < line2[1] && line2[1] < line1[1]) return true;

        return false;
    }

    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {

        int[] rec1RangeX = new int[2] { rec1[0], rec1[2] };
        int[] rec1RangeY = new int[2] { rec1[1], rec1[3] };

        int[] rec2RangeX = new int[2] { rec2[0], rec2[2] };
        int[] rec2RangeY = new int[2] { rec2[1], rec2[3] };

        if (AreTwoLinesOverlap(rec1RangeX, rec2RangeX) && AreTwoLinesOverlap(rec1RangeY, rec2RangeY))
            return true;
        else
            return false;
    }
}

class Program
{
    public static void Main()
    {
        bool result;
        Solution test = new Solution();

        //result = test.IsRectangleOverlap(new int[] { 7, 8, 13, 15 }, new int[] { 10, 8, 12, 20 });  // Expected: true

        // result = test.IsRectangleOverlap(new int[] { 4, 4, 14, 7 }, new int[] { 4, 3, 8, 8 });  // Expected: true

        //result = test.IsRectangleOverlap(new int[] { 4, 4, 14, 7 }, new int[] { 4, 4, 14, 7 });  // Expected: true


        result = test.IsRectangleOverlap(new int[] { 4, 4, 14, 7 }, new int[] { 0, 0, 1, 1 });  // Expected: false
        Console.WriteLine(result);
    }
}