// 200. Number of Islands
public class Solution
{
    Dictionary<(int, int), bool> visitedGrid = new Dictionary<(int, int), bool>();

    int ConnectedGraphCount = 0;

    public int NumIslands(char[][] grid)
    {
        // Debug: Print the grid
        DebugPrintGrid(grid);

        // Initialize visited grid
        for (int i = 0; i < grid.Length; i++)           // matrix.Length gives the number of rows
        {
            if (grid[i] == null) continue;              // Handle potential null rows
            for (int j = 0; j < grid[i].Length; j++)    // matrix[i].Length gives the number of columns in this specific row
                visitedGrid.Add((j, i), false);
        }


        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[y].Length; x++)
            {
                bool visited = visitedGrid[(x, y)];
                if (visited == false && grid[y][x] == '1')
                {
                    // New connected graph found
                    ConnectedGraphCount++;

                    // Find all connected vertices
                    List<(int, int)> ConnectedGraph = FindConnectedGraph(x, y, grid);

                    // Debug: Print connected graph
                    DebugPrintConnectedGraph(ConnectedGraph, grid);

                    // Debug: Print Visited Grid
                    DebugPrintVisitedGrid(grid);
                }
            }
        }
        return ConnectedGraphCount;
    }

    void DebugPrintGrid(char[][] grid)
    {
        // Debug: Print the grid
        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[y].Length; x++)
                Console.Write(grid[y][x] + " ");

            Console.WriteLine();
        }
    }   

    void DebugPrintConnectedGraph(List<(int, int)> ConnectedGraph, char[][] grid)
    {
        Console.WriteLine("\nConnected Graph #" + ConnectedGraphCount + ":");

        char[][] outputChars = new char[grid.Length][];

        for (int y = 0; y < grid.Length; y++)
        {
            outputChars[y] = new char[grid[y].Length];
            for (int x = 0; x < grid[y].Length; x++)
            {
                if (ConnectedGraph.Contains((x, y)))
                    outputChars[y][x] = '1';
                else
                    outputChars[y][x] = ' ';
            }
        }

        for (int y = 0; y < outputChars.Length; y++)
        {
            for (int x = 0; x < outputChars[y].Length; x++)
                Console.Write(outputChars[y][x] + " ");

            Console.WriteLine();
        }
    }

    void DebugPrintVisitedGrid(char[][] grid)
    {
        Console.WriteLine("\nVisited Grid:");
        char[][] outputChars = new char[grid.Length][];
        for (int y = 0; y < grid.Length; y++)
        {
            outputChars[y] = new char[grid[y].Length];
            for (int x = 0; x < grid[y].Length; x++)
            {
                if (visitedGrid[(x, y)])
                    outputChars[y][x] = 'V';
                else
                    outputChars[y][x] = ' ';
            }
        }

        for (int y = 0; y < outputChars.Length; y++)
        {
            for (int x = 0; x < outputChars[y].Length; x++)
                Console.Write(outputChars[y][x] + " ");

            Console.WriteLine();
        }
    }

    List<(int, int)> FindConnectedGraph(int startPointX, int startPointY, char[][] grid)
    {
        List<(int, int)> ConnectedGraph = new List<(int, int)>();

        Stack<(int, int)> queue = new Stack<(int, int)>();  // x, y

        queue.Push((startPointX, startPointY));

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
                    ConnectedGraph.Add((x, y));

                // Marking as visited
                visitedGrid[(x, y)] = true;

                // Adding neighbors
                List<(int, int)> neighbors = FindNeighbors(x, y, grid);

                foreach (var neighbor in neighbors)
                {
                    if (visitedGrid[neighbor] == false)
                        queue.Push(neighbor);
                }
            }
        }

        return ConnectedGraph;
    }

    List<(int, int)> FindNeighbors(int x, int y, char[][] grid)
    {
        List<(int, int)> neighbors = new List<(int, int)>();
        // Up
        if (y - 1 >= 0)
        {
            if (grid[y-1][x] == '1')
                neighbors.Add((x, y - 1));
        }

        // Down
        if (y + 1 < grid.Length)
        {
            if (grid[y + 1][x] == '1')
                neighbors.Add((x, y + 1));
        }

        // Left
        if (x - 1 >= 0)
        {
            if (grid[y][x - 1] == '1')
                neighbors.Add((x - 1, y));
        }
 
        // Right
        if (x + 1 < grid[y].Length)
        {
            if (grid[y][x + 1] == '1')
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

#if false   // Test Case 1, Expected Output: 1   
        char[][] grid = new char[][] {
            new char[] { '1', '1', '1', '1', '0' },
            new char[] { '1', '1', '0', '1', '0' },
            new char[] { '1', '1', '0', '0', '0' },
            new char[] { '0', '0', '0', '0', '0' }
        };
#endif

#if false    // Test Case 2, Expected Output: 3
        char[][] grid = new char[][] {
            new char[] { '1', '1', '0', '0', '0' },
            new char[] { '1', '1', '0', '0', '0' },
            new char[] { '0', '0', '1', '0', '0' },
            new char[] { '0', '0', '0', '1', '1' }
        };

#endif

#if true    // Test Case 3
        char[][] grid = new char[][] {
            new char[] { '0', '0', '0', '0', '0' },
            new char[] { '0', '0', '0', '0', '0' },
            new char[] { '0', '0', '0', '0', '0' },
            new char[] { '0', '0', '0', '1', '1' }
        };

#endif

        test.NumIslands(grid);
    }
}