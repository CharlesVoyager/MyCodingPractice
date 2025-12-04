// 21. Merge two sorted lists

//Definition for singly - linked list.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null && list2 == null)
            return null;

        if (list1 != null && list2 == null)
            return list1;

        if (list1 == null && list2 != null)
            return list2;

        ListNode result = new ListNode();
        ListNode resultHead = result;

        if (list1.val < list2.val)
        {
            result.val = list1.val;
            list1 = list1.next;
        }
        else
        {
            result.val = list2.val;
            list2 = list2.next;
        }

        result.next = null;

        while (list1 != null && list2 != null)
        {
            ListNode node = new ListNode();
            if (list1.val < list2.val) 
            {
                node.val = list1.val;
                list1 = list1.next;
            }
            else
            {
                node.val = list2.val;
                list2 = list2.next;
            }
            node.next = null;
            result.next = node;
            result = result.next;
        }

        while (list1 != null)
        {
            ListNode node = new ListNode(list1.val, null);
            result.next = node;
            result = result.next;
            list1 = list1.next;
        }

        while (list2 != null)
        {
            ListNode node = new ListNode(list2.val, null);
            result.next = node;
            result = result.next;
            list2 = list2.next;
        }

        return resultHead;
    }
}

class Program
{
    public static void Main()
    {
        int[] nums1 = new int[] { 1, 2, 4 };
        int[] nums2 = new int[] { 1, 3, 4 };

        ListNode list1 = new ListNode(nums1[0], null);
        ListNode list2 = new ListNode(nums2[0], null);

        ListNode list1Head = list1;
        ListNode list2Head = list2;

        for (int i = 1; i<nums1.Length; i++) 
        { 
            ListNode node = new ListNode(nums1[i], null);
            list1.next = node;
            list1 = list1.next;
        }

        for (int i = 1; i < nums1.Length; i++)
        {
            ListNode node = new ListNode(nums2[i], null);
            list2.next = node;
            list2 = list2.next;
        }

        Solution s = new Solution();
        ListNode result = s.MergeTwoLists(list1Head, list2Head);

        while (result != null) 
        {
            Console.WriteLine(result.val);
            result = result.next;
        }

    }
}