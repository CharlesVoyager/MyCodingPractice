// 542. 01 Matrix

public class Solution
{
    List<(int, int)> verticesToProcess = new List<(int, int)>();
    int currentDistance = 1;
    public int[][] UpdateMatrix(int[][] mat)
    {
        // Initialize verticesToProcess
        for (int row = 0; row < mat.Length; row++)
        {
            for (int col = 0; col < mat[row].Length; col++)
            {
                if (mat[row][col] == 1)
                {
                    verticesToProcess.Add((row, col));
                    mat[row][col] = -1;
                }
                  
            }
        }

        List<(int, int)> verticesProcessed = new List<(int, int)>();
        while (verticesToProcess.Count() > 0)
        {
            verticesProcessed.Clear();
            foreach (var (r, c) in verticesToProcess)
            {
                if (doesNeighborExist(r, c, currentDistance - 1, mat))
                {
                    mat[r][c] = currentDistance;
                    verticesProcessed.Add((r, c));
                }
            }

            foreach (var (r, c) in verticesProcessed)
                verticesToProcess.Remove((r, c));

            currentDistance++;
        }
        return mat;
    }

    bool doesNeighborExist(int r, int c, int neighborValue, int[][] mat)
    {
        // up
        if (r - 1 >= 0)
        {
            if (mat[r - 1][c] == neighborValue)
                return true;
        }

        // down
        if (r + 1 < mat.Length)
        {
            if (mat[r + 1][c] == neighborValue)
                return true;
        }

        // left
        if (c - 1 >= 0)
        {
            if (mat[r][c - 1] == neighborValue)
                return true;
        }

        // down
        if (c + 1 < mat[r].Length)
        {
            if (mat[r][c + 1] == neighborValue)
                return true;
        }

        return false;
    }
}


class Program
{
    static void DebugPrintMatrix(int[][] mat)
    {
        for (int row = 0; row < mat.Length; row++)
        {
            for (int col = 0; col < mat[row].Length; col++)
            {
                Console.Write(mat[row][col] + " ");
            }
            Console.WriteLine();
        }
    }

    public static bool TestCase(int[][] input, int[][] expected)
    {
        Solution test = new Solution();

        Console.WriteLine("Input: ");
        DebugPrintMatrix(input);

        int[][] output = test.UpdateMatrix(input);
    
        Console.WriteLine();

        Console.WriteLine("Output: ");
        DebugPrintMatrix(output);

        Console.WriteLine();

        Console.WriteLine("Expected: ");
        DebugPrintMatrix(expected);


        for (int row = 0; row < expected.Length; row++)
        {
            for (int col = 0; col < expected[row].Length; col++)
            {
                if (output[row][col] != expected[row][col])
                    return false;
            }
        }
        return true;
    }

    public static void Main()
    {
        bool result;

        while (true)
        {
            // Test Case 1, Expected Output: 2   
            int[][] input1 = new int[][] {
                new int[] { 0, 1, 1  },
                new int[] { 1, 1, 1  },
                new int[] { 1, 1, 1  },
            };

            int[][] expected = new int[][] {
                new int[] { 0, 1, 2  },
                new int[] { 1, 2, 3  },
                new int[] { 2, 3, 4  },
            };

            result = TestCase(input1, expected);
            if (!result)
            {
                Console.WriteLine("Test case 1 failed");
                break;
            }

            Console.WriteLine("All test cases passed!");
            break;
        }

        Console.ReadLine();
    }
}
