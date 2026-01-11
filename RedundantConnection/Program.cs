// 684. Redundant Connection

public class Solution
{
    public int[] FindRedundantConnection(int[][] edges)
    {

        int lastRemoveRowValue0 = 0;
        int lastRemoveRowValue1 = 0;

        for (int removeRow = edges.Length - 1; removeRow >= 0; removeRow--)
        {
            if (removeRow < edges.Length - 1)
            {
                edges[removeRow + 1][0] = lastRemoveRowValue0;
                edges[removeRow + 1][1] = lastRemoveRowValue1;
            }

            lastRemoveRowValue0 = edges[removeRow][0];
            lastRemoveRowValue1 = edges[removeRow][1];

            edges[removeRow][0] = -1;
            edges[removeRow][1] = -1;

            // Check
#if false
            HashSet<int> vertices = BreadthFirstSearch(1, edges);
            if (vertices.Count == edges.Length)
                return new int[2] { lastRemoveRowValue0, lastRemoveRowValue1 };
#else       
            if (IsConnected(lastRemoveRowValue0, lastRemoveRowValue1, edges))
                return new int[2] { lastRemoveRowValue0, lastRemoveRowValue1 };
#endif
        }
        return new int[2] { 0, 0 };
    }

    bool IsConnected(int verticeA, int verticeB, int[][] edges)
    {
        HashSet<int> verticesVisited = new HashSet<int>();
        Stack<int> verticesToProcess = new Stack<int>();
        verticesToProcess.Push(verticeA);

        while (verticesToProcess.Count > 0)
        {
            int v = verticesToProcess.Pop();
            verticesVisited.Add(v);
            if (verticesVisited.Contains(verticeB))
                return true;

            List<int> neighbors = FindNeighborsWithoutVisit(v, edges, verticesVisited);
            foreach (int vertice in neighbors)
            {
                if (verticesToProcess.Contains(vertice) == false)
                    verticesToProcess.Push(vertice);
            }
        }
        return false;
    }


    HashSet<int> BreadthFirstSearch(int startVertice, int[][] edges)
    {
        HashSet<int> verticesVisited = new HashSet<int>();
        Stack<int> verticesToProcess = new Stack<int>();
        verticesToProcess.Push(startVertice);

        while (verticesToProcess.Count > 0)
        {
            int v = verticesToProcess.Pop();
            verticesVisited.Add(v);
            List<int> neighbors = FindNeighborsWithoutVisit(v, edges, verticesVisited);
            foreach (int vertice in neighbors)
            {
                if (verticesToProcess.Contains(vertice) == false)
                    verticesToProcess.Push(vertice);
            }
        }

        return verticesVisited;
    }

    List<int> FindNeighborsWithoutVisit(int vertice, int[][] edges, HashSet<int> verticesVisited)
    {
        List<int> neighbors = new List<int>();
        for (int r = 0; r < edges.Length; r++)
        {
            if (edges[r][0] == vertice)
            {
                if (verticesVisited.Contains(edges[r][1]) == false)
                    neighbors.Add(edges[r][1]);
            }
            else if (edges[r][1] == vertice)
            {
                if (verticesVisited.Contains(edges[r][0]) == false)
                    neighbors.Add(edges[r][0]);
            }
        }
        return neighbors;
    }
}

class Program
{
    public static void Main()
    {
        Solution test = new Solution();

#if true    // Expected output: [2,3]
        int[][] input = new int[][]{ 
            new int[]{ 1, 2 }, 
            new int[]{ 1, 3 }, 
            new int[]{ 2, 3 } };
#endif
#if false    // Expected output: [1,4]   
        int[][] input = new int[][]{ 
            new int[]{ 1, 2 }, 
            new int[]{ 2, 3 }, 
            new int[]{ 3, 4 },
            new int[]{ 1, 4 },
            new int[]{ 1, 5 }
        };
#endif

        int[] output = test.FindRedundantConnection(input);

        if (output.Length == 2)
            Console.WriteLine("[" + output[0].ToString() + ", " + output[1].ToString() + "]" );
        else
            Console.WriteLine("null");
    }
}

