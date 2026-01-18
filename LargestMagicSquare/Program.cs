// 1895. Largest Magic Square
public class Solution
{
    int rowLength;
    int colLength;

    public int LargestMagicSquare(int[][] grid)
    {

        rowLength = grid.Length;
        colLength = grid[0].Length;
        int curMaxSquareLength = 1;

        //curMaxSquareLength = FindLargestMagicSquare(1, 1, grid);
#if true
        for (int r = 0; r < rowLength - 1; r++)
        {
            for (int c = 0; c < colLength - 1; c++)
            {
                curMaxSquareLength = Math.Max(curMaxSquareLength, FindLargestMagicSquare(r, c, grid));
                if (curMaxSquareLength >= rowLength - r)
                    return curMaxSquareLength;
            }
        }
#endif
        return curMaxSquareLength;
    }

    int FindLargestMagicSquare(int rowIndex, int colIndex, int[][] grid)
    {
        int maxSquareLength = Math.Min(rowLength - rowIndex, colLength - colIndex);

        for (int i = maxSquareLength; i >= 1; i--)
        {
            int lastRowIndex = rowIndex + i - 1;
            int lastColIndex = colIndex + i - 1;

            int sumOfFirstRow = 0;
            for (int n = colIndex; n <= lastColIndex; n++)
                sumOfFirstRow += grid[rowIndex][n];

            int sum = 0;
            // Check rows.
            bool isRowsMagic = true;
            for (int m = rowIndex + 1; m <= lastRowIndex; m++)
            {
                sum = 0;
                for (int n = colIndex; n <= lastColIndex; n++)
                    sum += grid[m][n];

                if (sum != sumOfFirstRow)
                {
                    isRowsMagic = false;
                    break;  // Check next square length
                }
            }

            if (isRowsMagic == false)
                continue;

            // Check columns.
            bool isColsMagic = true;
            for (int n = colIndex; n <= lastColIndex; n++)
            {
                sum = 0;
                for (int m = rowIndex; m <= lastRowIndex; m++)
                    sum += grid[m][n];

                if (sum != sumOfFirstRow)
                {
                    isColsMagic = false;
                    break;  // Check next square length
                }
            }

            if (isColsMagic == false)
                continue;

            // Check diagnoal: \
            sum = 0;
            for (int d = 0; d < i; d++)
                sum += grid[rowIndex + d][colIndex + d];

            if (sum != sumOfFirstRow)
                continue;

            // Check diagnoal: /
            sum = 0;
            for (int d = 0; d < i; d++)
                sum += grid[rowIndex + d][lastColIndex - d];

            if (sum != sumOfFirstRow)
                continue;

            // Pass all checks
            return i;
        }
        return 1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

#if true
        int[][] grid1 = new int[][]
        {
            new int[] {7,1,4,5,6},
            new int[] {2,5,1,6,4},
            new int[] {1,5,4,3,2},
            new int[] {1,2,7,3,4}
        };
        Console.WriteLine(solution.LargestMagicSquare(grid1));  // Output: 3
#endif
#if false
        int[][] grid2 = new int[][]
        {
            new int[] {5,1,3,1},
            new int[] {9,3,3,1},
            new int[] {1,3,3,8}
        };
        Console.WriteLine(solution.LargestMagicSquare(grid2));  // Output: 2
#endif
    }
}