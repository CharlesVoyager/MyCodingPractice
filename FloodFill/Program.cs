// 733. Flood Fill
public class Solution
{
    int SourceColor = 0;
    int DestinationColor = 0;
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        SourceColor = image[sr][sc];
        DestinationColor = color;

        if (SourceColor == DestinationColor)
            return image;   

        HashSet<(int, int)> vertices = new HashSet<(int, int)>(); //row, column

        vertices.Add((sr, sc));
        while (vertices.Count > 0)
        {
            var (r, c) = vertices.Last();
            vertices.Remove((r, c));
            image[r][c] = DestinationColor;
            List<(int, int)> neighbors = FindNeighborsWithSourceColor(r, c, image);

            foreach (var v in neighbors)
                vertices.Add((v.Item1, v.Item2));
        }
        return image;
    }

    List<(int, int)> FindNeighborsWithSourceColor(int r, int c, int[][] image)
    {
        List<(int, int)> neighbors = new List<(int, int)>();

        // up
        if (r - 1 >= 0)
        {
            if (image[r - 1][c] == SourceColor)
                neighbors.Add((r - 1, c));
        }

        // down
        if (r + 1 <= image.Length - 1)
        {
            if (image[r + 1][c] == SourceColor)
                neighbors.Add((r + 1, c));
        }

        // left
        if (c - 1 >= 0)
        {
            if (image[r][c - 1] == SourceColor)
                neighbors.Add((r, c - 1));
        }

        // down
        if (c + 1 <= image[r].Length - 1)
        {
            if (image[r][c + 1] == SourceColor)
                neighbors.Add((r, c + 1));
        }
        return neighbors;
    }
}

class Program
{
    static bool FastCompare(int[][] a, int[][] b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a == null || b == null || a.Length != b.Length) return false;

        for (int i = 0; i < a.Length; i++)
        {
            int[] rowA = a[i];
            int[] rowB = b[i];

            if (ReferenceEquals(rowA, rowB)) continue;
            if (rowA == null || rowB == null || rowA.Length != rowB.Length) return false;

            for (int j = 0; j < rowA.Length; j++)
            {
                if (rowA[j] != rowB[j]) return false;
            }
        }
        return true;
    }

    public static bool TestCase(int[][] input, int sr, int sc, int color, int[][] expected)
    {
        Solution test = new Solution();

        int[][] output = test.FloodFill(input, sr, sc, color);
        return FastCompare(output, expected);
    }

    public static void Main()
    {
        bool result;

        while (true)
        {
            // Test Case 1:
            int[][] input1 = new int[][] {
                new int[] { 1, 1, 1  },
                new int[] { 1, 1, 0  },
                new int[] { 1, 0, 1  },
            };

            int[][] expected1 = new int[][] {
                new int[] { 2, 2, 2  },
                new int[] { 2, 2, 0  },
                new int[] { 2, 0, 1  },
            };

            result = TestCase(input1, 1, 1, 2, expected1);
            if (!result)
            {
                Console.WriteLine("Test case 1 failed");
                break;
            }

            // Test Case 2:
            int[][] input2 = new int[][] {
                new int[] { 0, 0, 0  },
                new int[] { 0, 0, 0  },
            };

            int[][] expected2 = new int[][] {
                new int[] { 0, 0, 0  },
                new int[] { 0, 0, 0  },
            };

            result = TestCase(input2, 0, 0, 0, expected2);
            if (!result)
            {
                Console.WriteLine("Test case 2 failed");
                break;
            }

            Console.WriteLine("All Test Passed!");
            break;
        }

        Console.ReadLine();
    }
}

