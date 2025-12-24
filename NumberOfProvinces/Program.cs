// 547. Number of Provinces

public class Solution
{
    bool[] IsVisited;
    HashSet<(int, int)> Edges = new HashSet<(int, int)>();
    int ConnectedGraphCount = 0;

    public int FindCircleNum(int[][] isConnected)
    {
        // Initialize Visited array
        IsVisited = new bool[isConnected.Length];

        // Initialize Edges
        for (int y = 0; y < isConnected.Length; y++)
        {
            for (int x = 0; x < isConnected[y].Length; x++)
            {
                if (isConnected[y][x] == 1)
                    Edges.Add((y, x));
            }
        }

        for (int v = 0; v < isConnected.Length; v++)
        {
            if (IsVisited[v] == false)
            {
                // New connected graph found
                ConnectedGraphCount++;
                List<int> ConnectedGraph = FindConnectedGraph(v);
            }
        }
        return ConnectedGraphCount;
    }

    List<int> FindConnectedGraph(int startVertex)
    {
        List<int> ConnectedGraph = new List<int>();
        Stack<int> vertices = new Stack<int>();

        vertices.Push(startVertex);

        while (vertices.Count > 0)
        {
            var v = vertices.Pop();

            // Visiting the vertex
            ConnectedGraph.Add(v);

            // Marking as visited
            IsVisited[v] = true;

            // Adding neighbors
            List<int> neighbors = FindNeighbors(v);
            foreach (var neighbor in neighbors)
                vertices.Push(neighbor);
        }
        return ConnectedGraph;
    }

    List<int> FindNeighbors(int v)
    {
        List<int> neighbors = new List<int>();

        foreach (var e in Edges)
        {
            if (e.Item1 == v && IsVisited[e.Item2] == false)
                neighbors.Add(e.Item2);
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
        int[][] grid = new int[][] {
            new int[] { 1, 1, 0  },
            new int[] { 1, 1, 0  },
            new int[] { 0, 0, 1  },
        };
#endif

#if false    // Test Case 2, Expected Output: 3   
        int[][] grid = new int[][] {
            new int[] { 1, 0, 0  },
            new int[] { 0, 1, 0  },
            new int[] { 0, 0, 1  },
        };
#endif

#if true    // Test Case 2, Expected Output: 1   
        int[][] grid = new int[][] {
            new int[] { 1, 0, 0, 1 },
            new int[] { 0, 1, 1, 0 },
            new int[] { 0, 1, 1, 1 },
            new int[] { 1, 0, 1, 1 },
        };
#endif


        int result = test.FindCircleNum(grid);

        Console.WriteLine("Number of Provinces: " + result);
    }
}
