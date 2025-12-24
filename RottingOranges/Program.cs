// 994. Rotting Oranges

public class Solution
{
    int minElapsed = 0;

    public int OrangesRotting(int[][] grid)
    {
        Stack<(int, int)> curRottens = new Stack<(int, int)>();

        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[y].Length; x++)
            {
                if (grid[y][x] == 2)
                    curRottens.Push((x, y));
            }
        }

        HashSet<(int, int)> FreshToRotten = new HashSet<(int, int)>();
        while (curRottens.Count > 0)
        {
            var (x, y) = curRottens.Pop();

            // Mark the vertex is visited.
            grid[y][x] = 3;

            List<(int, int)> neighbors = FindNeighborsWithValueOne(x, y, grid);
            foreach (var v in neighbors)
            {
                FreshToRotten.Add((v.Item1, v.Item2));
                grid[v.Item2][v.Item1] = 2;   // Mark the vertex is rotten.
            }
 
            if (curRottens.Count == 0 && FreshToRotten.Count > 0)
            {
                minElapsed++;
                foreach (var v in FreshToRotten)
                    curRottens.Push((v.Item1, v.Item2));

                FreshToRotten.Clear();
            }
        }

        DebugPrintGrid(grid);

        // Check if there is any fresh orange left.
        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[y].Length; x++)
            {
                if (grid[y][x] == 1)
                    return -1;
            }
        }
        return minElapsed;
    }

    List<(int, int)> FindNeighborsWithValueOne(int x, int y, int[][] grid)
    {
        List<(int, int)> neighbors = new List<(int, int)>();
        // Up
        if (y - 1 >= 0)
        {
            if (grid[y - 1][x] == 1)
                neighbors.Add((x, y - 1));
        }

        // Down
        if (y + 1 < grid.Length)
        {
            if (grid[y + 1][x] == 1)
                neighbors.Add((x, y + 1));
        }

        // Left
        if (x - 1 >= 0)
        {
            if (grid[y][x - 1] == 1)
                neighbors.Add((x - 1, y));
        }

        // Right
        if (x + 1 < grid[y].Length)
        {
            if (grid[y][x + 1] == 1)
                neighbors.Add((x + 1, y));
        }
        return neighbors;
    }

    void DebugPrintGrid(int[][] grid)
    {
        // Debug: Print the grid
        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[y].Length; x++)
                Console.Write(grid[y][x] + " ");

            Console.WriteLine();
        }
    }
}

class Program
{
    public static void Main()
    {
        Solution test = new Solution();

#if true   // Test Case 1, Expected Output: 4  
        int[][] grid = new int[][] {
            new int[] { 2, 1, 1 },
            new int[] { 1, 1, 0 },
            new int[] { 0, 1, 1 },
        };
#endif

#if false   // Test Case 2, Expected Output: -1  
        int[][] grid = new int[][] {
            new int[] { 2, 1, 1 },
            new int[] { 0, 1, 1 },
            new int[] { 1, 0, 1 },
        };
#endif

#if false   // Test Case 3, Expected Output: 0  
        int[][] grid = new int[][] {
            new int[] { 0, 2 }
        };
#endif

#if false   // Test Case 4, Expected Output: 1 
        int[][] grid = new int[][] {
            new int[] { 2, 2 },
            new int[] { 1, 1 },
            new int[] { 0, 0 },
            new int[] { 2, 0 }
        };
#endif

        int result = test.OrangesRotting(grid);

        Console.WriteLine("Elpased Minutes: " + result);
    }
}
