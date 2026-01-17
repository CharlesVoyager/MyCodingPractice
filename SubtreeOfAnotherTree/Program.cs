// 572. Subtree of Another Tree

// Status: failed test cases

/*
root =
[10,5,null,4]

subRoot =
[10,4,null,null,5]
 * 
 */
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    List<int> outputValues = new List<int>();
    TreeNode outputNode;

    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        outputNode = null;
        FindNodeWithValue(root, subRoot.val);

        outputValues.Clear();
        InorderTraverse(outputNode);
        List<int> valuesFromRoot = new List<int>(outputValues);

        outputValues.Clear();
        InorderTraverse(subRoot);
        List<int> valuesFromSubRoot = new List<int>(outputValues);

        return valuesFromRoot.SequenceEqual(valuesFromSubRoot);
    }

    void FindNodeWithValue(TreeNode node, int targetVal)
    {
        if (node.val == targetVal)
            outputNode = node;

        if (node.left == null && node.right == null)
            return;

        if (node.left != null)
            FindNodeWithValue(node.left, targetVal);
        if (node.right != null)
            FindNodeWithValue(node.right, targetVal);
    }

    void InorderTraverse(TreeNode node)
    {
        if (node.left == null && node.right == null)
        {
            outputValues.Add(node.val);
            return;
        }
        if (node.left != null)
            InorderTraverse(node.left);
        outputValues.Add(node.val);
        if (node.right != null)
            InorderTraverse(node.right);
    }
}

class Program
{

    static TreeNode CreateTreeNodes(int[] nums)
    {
        List<TreeNode> nodes = new List<TreeNode>();

        foreach (int n in nums)
        {
            if (n == int.MinValue)
                nodes.Add(null);
            else
                nodes.Add(new TreeNode(n));
        }

        for (int i = 0; i < nums.Length / 2; i++)
        {
            nodes[i].left = nodes[i * 2 + 1];
            if (i * 2 + 2 < nums.Length)
                nodes[i].right = nodes[i * 2 + 2];
        }
        return nodes[0];
    }



    static bool TestCase(int[] numsRoot, int[] numsSubRoot, bool expected)
    {
        Solution test = new Solution();

        TreeNode root = CreateTreeNodes(numsRoot);
        TreeNode subRoot = CreateTreeNodes(numsSubRoot);
        bool output = test.IsSubtree(root, subRoot);

        Console.WriteLine(" Output: " + output + " Expected: " + expected + " Result: " + (expected == output ? "PASS" : "FAIL"));

        return expected == output;
    }

    public static void Main()
    {
        bool result;

        while (true)
        {
            //result = TestCase(new int[] { 3, 4, 5, 1, 2 }, new int[] { 4, 1, 2 }, true);
            //if (result == false) break;

            //result = TestCase(new int[] { 3, 4, 5, 1, 2, int.MinValue, int.MinValue, int.MinValue, int.MinValue, 0 }, new int[] { 4, 1, 2 }, false);
            //if (result == false) break;

            result = TestCase(new int[] { 10, 5, int.MinValue, 4 }, new int[] { 10, 4, int.MinValue, int.MinValue, 5 }, false);
            if (result == false) break;

            Console.WriteLine("ALL TESTS PASS");
            break;
        }
    }
}