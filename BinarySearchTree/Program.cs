// 98. Validate Binary Search Tree 

//Definition for a binary tree node.
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
    List<int> orderedNums = new List<int>();
    public bool IsValidBST(TreeNode root)
    {
        orderedNums.Clear();
        InorderBinarySearchTree(root);

        if (orderedNums == null || orderedNums.Count <= 1)
            return true;

        for (int i = 0; i < orderedNums.Count - 1; i++)
        {
            if (orderedNums[i] >= orderedNums[i + 1])
                return false;
        }
        return true;
    }

    public void InorderBinarySearchTree(TreeNode node)
    {
        if (node == null)
            return;

        InorderBinarySearchTree(node.left);
        orderedNums.Add(node.val);        //Console.Write(" " + node.val.ToString());
        InorderBinarySearchTree(node.right);

        return;
    }


    public TreeNode CreateTreeNodes(int[] nums)
    {
        List<TreeNode> nodes = new List<TreeNode>();

        foreach(int n in nums) 
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

    public void PrintOrderedNums()
    {
        foreach (int n in orderedNums)
            Console.Write(" " + n);
    }

    public bool TestCase(int[] nums, bool expected)
    {
        TreeNode root = CreateTreeNodes(nums);
        bool output = IsValidBST(root);
        PrintOrderedNums();

        Console.WriteLine(" Output: " + output + " Expected: " + expected +  " Result: " + (expected==output ? "PASS" : "FAIL"));
      
        return expected == output;
    }
}

class Program
{
    public static void Main()
    {
        bool result;
        Solution test = new Solution();

        while (true)
        {
            result = test.TestCase(new int[] { 5, 1, 4, int.MinValue, int.MinValue, 3, 6 }, false);
            if (result == false) break;  
           
            result = test.TestCase(new int[] { 5, 1, 6, int.MinValue, int.MinValue, 3, 7 }, false);
            if (result == false) break;

            result = test.TestCase(new int[] { 5, 1, 7, int.MinValue, int.MinValue, 6, 8 }, true);
            if (result == false) break;
       
            result = test.TestCase(new int[] { 2, 1, 3 }, true);
            if (result == false) break;

            result = test.TestCase(new int[] { 2 }, true);
            if (result == false) break;

            result = test.TestCase(new int[] { 5, 1, 7, 0, 2, 6, 8 }, true);
            if (result == false) break;

            Console.WriteLine("ALL TESTS PASS");
            break;
        }
    }
}