// 98. Validate Binary Search Tree 

//Definition for a binary tree node.
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

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
    public bool IsValidBST(TreeNode root)
    {
        TreeNode leftNode = root.left;
        TreeNode rightNode = root.right;

        while (leftNode != null || rightNode != null)
        {
            if (leftNode != null)
                if (leftNode.val < root.val)
                    leftNode = leftNode.left;
                else
                    return false;

            if (rightNode != null)
                if (rightNode.val > root.val)
                    rightNode = rightNode.right;
                else
                    return false;
        }

        return true;
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

        for (int i = 0; i < (nums.Length - 1) / 2; i++) 
        {
            nodes[i].left = nodes[i * 2 + 1];
            nodes[i].right = nodes[i * 2 + 2];
        }
        return nodes[0];
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
            TreeNode root = test.CreateTreeNodes(new int[] { 5, 1, 4, int.MinValue, int.MinValue, 3, 6 });
            break;
        }
    }
}