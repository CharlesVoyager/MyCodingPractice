// 200. Number of Islands

public class Solution
{
    public int NumIslands(char[][] grid)
    {
        // test
        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[y].Length; x++)
            {
                Console.Write(grid[y][x] + " ");
            }
            Console.WriteLine();
        }




        Stack<(int, int)> queue = new Stack<(int, int)>();  // x, y, visited
        Dictionary<(int, int), bool> visitedGrid = new Dictionary<(int, int), bool>();

        for (int i = 0; i < grid.Length; i++)           // matrix.Length gives the number of rows
        {
            if (grid[i] == null) continue;              // Handle potential null rows
            for (int j = 0; j < grid[i].Length; j++)    // matrix[i].Length gives the number of columns in this specific row
                visitedGrid.Add((j, i), false);
        }

        queue.Push((0, 0));

        while (queue.Count > 0)
        {
            var (x, y) = queue.Pop();
            bool visited = visitedGrid[(x, y)];

            if (visited == false)
            {
                if (x < 0 || y < 0 || y >= grid.Length || x >= grid[y].Length)
                    continue;

                // Visiting the vertex
                if (grid[y][x] == '1')
                {
                    Console.WriteLine($"Visiting node: ({x}, {y})");    
                }

                // Marking as visited
                visitedGrid[(x, y)] = true;

                // Adding neighbors
                List<(int, int)> neighbors = FindNeighbors(x, y, grid);

                foreach(var neighbor in neighbors)
                    queue.Push(neighbor);
            }
        }


        return 0;
    }

    List<(int, int)> FindNeighbors(int x, int y, char[][] grid)
    {
        List<(int, int)> neighbors = new List<(int, int)>();
        // Up
        if (y - 1 >= 0)
        {
            if (grid[x][y - 1] == '1')
                neighbors.Add((x, y - 1));
        }

        // Down
        if (y + 1 < grid.Length)
        {
            if (grid[x][y + 1] == '1')
                neighbors.Add((x, y + 1));
        }

        // Left
        if (x - 1 >= 0)
        {
            if (grid[x - 1][y] == '1')
                neighbors.Add((x - 1, y));
        }
 
        // Right
        if (x + 1 < grid[y].Length)
        {
            if (grid[x + 1][y] == '1')
                neighbors.Add((x + 1, y));
        }
        return neighbors;
    }
}

class Program
{
    public static void Main()
    {
        Solution test = new Solution();

        char[][] grid = new char[][] {
            new char[] { '1', '1', '1', '1', '0' },
            new char[] { '1', '1', '0', '1', '0' },
            new char[] { '1', '1', '0', '0', '0' },
            new char[] { '0', '0', '0', '0', '0' }
        };

        test.NumIslands(grid);
    }
}