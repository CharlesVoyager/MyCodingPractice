// 146. LRU Cache

// Time Limit Exceeded on large input - test case 22.
public class LRUCache
{
    int capacity = 0;
    ListNode recentlyUsedKeyHead = null;
    ListNode recentlyUsedKeyTail = null;
    Dictionary<int, int> cache = new Dictionary<int, int>();

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
    }

    public int Get(int key)
    {
        if (cache.ContainsKey(key))
        {
            RecentlyUsedKeysEnqueue(key);
            if (RecentlyUsedKeysCount() > capacity)
                RecentlyUsedKeysDequeue();
            return cache[key];
        }
        else
            return -1;
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            cache[key] = value;
            RecentlyUsedKeysEnqueue(key);
            if (RecentlyUsedKeysCount() > capacity)
                RecentlyUsedKeysDequeue();
        }
        else
        {
            int leastRecentlyUsedKey;
            if (RecentlyUsedKeysCount() < capacity)
            {
                RecentlyUsedKeysEnqueue(key);
                leastRecentlyUsedKey = RecentlyUsedKeysPeek();
            }
            else
            {
                RecentlyUsedKeysEnqueue(key);
                leastRecentlyUsedKey = RecentlyUsedKeysDequeue();
            }

            cache[key] = value;
            if (cache.Count > capacity)
                cache.Remove(leastRecentlyUsedKey);
        }
    }

    public void DisplayCache()
    {
        Console.WriteLine("Cache contents:");
        foreach (var kvp in cache)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }

    public string RecentlyUsedKeysToString()
    {
        string result = "";
        ListNode node = recentlyUsedKeyHead;
        while (node != null)
        {
            result += node.val + " ";
            node = node.next;
        }
        return result;
    }

    int RecentlyUsedKeysPeek()
    {
        return recentlyUsedKeyHead.val;
    }

    void RecentlyUsedKeysEnqueue(int val)
    {
        // Remove the ListNode with value val.
        ListNode node = recentlyUsedKeyHead;

        while (node != null)
        {
            if (node.val == val)
            {
                if (node.next == null)  // It means last node. Dont need to process.
                {
                    return;
                }
                else
                {
                    if (node != recentlyUsedKeyHead)
                    {
                        node.val = node.next.val;
                        node.next = node.next.next;

                        if (node.next == null)
                            recentlyUsedKeyTail = node;
                    }
                    else
                    {
                        recentlyUsedKeyHead = recentlyUsedKeyHead.next;
                    }
                    break;
                }
            }
            else
                node = node.next;
        }

        ListNode nodeNew = new ListNode(val);
        if (recentlyUsedKeyHead == null && recentlyUsedKeyTail == null)
        {
            recentlyUsedKeyHead = nodeNew;
            recentlyUsedKeyTail = nodeNew;
        }
        else
        {
            recentlyUsedKeyTail.next = nodeNew;
            recentlyUsedKeyTail = nodeNew;
        }
    }

    int RecentlyUsedKeysDequeue()
    {
        if (recentlyUsedKeyHead == null || recentlyUsedKeyTail == null)
            return 0;

        int val = recentlyUsedKeyHead.val;
        ListNode node = recentlyUsedKeyHead.next;
        recentlyUsedKeyHead = node;
        return val;
    }

    public int RecentlyUsedKeysCount()
    {
        int count = 0;
        ListNode node = recentlyUsedKeyHead;
        while (node != null)
        {
            count++;
            node = node.next;
        }
        return count;
    }
}

//Definition for singly-linked list.
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


/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

class Program
{
    static void Main()
    {

        string[] inputOperator = new string[] { "LRUCache", "put", "put", "put", "put", "put", "get", "put", "get", "get", "put", "get", "put", "put", "put", "get", "put", "get", "get", "get", "get", "put", "put", "get", "get", "get", "put", "put", "get", "put", "get", "put", "get", "get", "get", "put", "put", "put", "get", "put", "get", "get", "put", "put", "get", "put", "put", "put", "put", "get", "put", "put", "get", "put", "put", "get", "put", "put", "put", "put", "put", "get", "put", "put", "get", "put", "get", "get", "get", "put", "get", "get", "put", "put", "put", "put", "get", "put", "put", "put", "put", "get", "get", "get", "put", "put", "put", "get", "put", "put", "put", "get", "put", "put", "put", "get", "get", "get", "put", "put", "put", "put", "get", "put", "put", "put", "put", "put", "put", "put" };
        string tempInputVal = "[10], [10, 13], [3, 17], [6, 11], [10, 5], [9, 10], [13], [2, 19], [2], [3], [5, 25], [8], [9, 22], [5, 5], [1, 30], [11], [9, 12], [7], [5], [8], [9], [4, 30], [9, 3], [9], [10], [10], [6, 14], [3, 1], [3], [10, 11], [8], [2, 14], [1], [5], [4], [11, 4], [12, 24], [5, 18], [13], [7, 23], [8], [12], [3, 27], [2, 12], [5], [2, 9], [13, 4], [8, 18], [1, 7], [6], [9, 29], [8, 21], [5], [6, 30], [1, 12], [10], [4, 15], [7, 22], [11, 26], [8, 17], [9, 29], [5], [3, 4], [11, 30], [12], [4, 29], [3], [9], [6], [3, 4], [1], [10], [3, 29], [10, 28], [1, 20], [11, 13], [3], [3, 12], [3, 8], [10, 9], [3, 26], [8], [7], [5], [13, 17], [2, 27], [11, 15], [12], [9, 19], [2, 15], [3, 16], [1], [12, 17], [9, 1], [6, 19], [4], [5], [5], [8, 1], [11, 7], [5, 2], [9, 28], [1], [2, 2], [7, 4], [4, 22], [7, 24], [9, 26], [13, 28], [11, 26";
        string tempExpected = "null,null,null,null,null,null,-1,null,19,17,null,-1,null,null,null,-1,null,-1,5,-1,12,null,null,3,5,5,null,null,1,null,-1,null,30,5,30,null,null,null,-1,null,-1,24,null,null,18,null,null,null,null,-1,null,null,18,null,null,-1,null,null,null,null,null,18,null,null,-1,null,4,29,30,null,12,-1,null,null,null,null,29,null,null,null,null,17,22,18,null,null,null,-1,null,null,null,20,null,null,null,-1,18,18,null,null,null,null,20,null,null,null,null,null,null,null";
        string[] inputValue = tempInputVal.Replace("[","").Split("], ");
        string[] expected = tempExpected.Split(",");

        //    inputOperator[i], inputValue[i], expected[i]
        List<(string, string, string)> inputs = new List<(string, string, string)>();
        for (int i = 0; i < inputOperator.Length; i++)
        {
            inputs.Add((inputOperator[i], inputValue[i], expected[i]));
        }

        Console.WriteLine("LRU Cache Test");
        LRUCache lRUCache = new LRUCache(10);

        for (int i = 1; i < inputs.Count; i++)
        {
            var (operation, value, exp) = inputs[i];
            if (operation == "put")
            {
                string[] vals = value.Split(", ");
                int key = int.Parse(vals[0]);
                int val = int.Parse(vals[1]);
                lRUCache.Put(key, val);
                Console.Write($"Put({key},{val})");
                Console.Write(" => " + lRUCache.RecentlyUsedKeysToString());
                Console.Write(" => Count: " + lRUCache.RecentlyUsedKeysCount().ToString());
                Console.WriteLine();
            }
            else if (operation == "get")
            {
                int key = int.Parse(value);
                int result = lRUCache.Get(key);
                if (result == Convert.ToInt32(exp))
                {
                    Console.Write($"Get {key}: {result}");
                    Console.Write(" => " + lRUCache.RecentlyUsedKeysToString());
                    Console.Write(" => Count: " + lRUCache.RecentlyUsedKeysCount().ToString());
                    Console.WriteLine();
                }
                else
                {
                    Console.Write($"Get {key}: {result} | Expected: {exp}");
                    Console.Write(" => " + lRUCache.RecentlyUsedKeysToString());
                    Console.Write(" => Count: " + lRUCache.RecentlyUsedKeysCount().ToString());
                    Console.WriteLine();
                }
          
            }
        }

#if false
        LRUCache lRUCache = new LRUCache(2);
        lRUCache.Put(1, 1); // cache is {1=1}
        Console.WriteLine("Put(1,1)");
        lRUCache.Put(2, 2); // cache is {1=1, 2=2}
        Console.WriteLine("Put(2,2)");
        Console.WriteLine("Get 1: " + lRUCache.Get(1));    // return 1

        lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        Console.WriteLine("Put(3,3)");
        lRUCache.DisplayCache();

        Console.WriteLine("Get 2: " + lRUCache.Get(2));    // returns -1 (not found)
      
        lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        Console.WriteLine("Put(4,4)");
        lRUCache.DisplayCache();

        Console.WriteLine("1: " + lRUCache.Get(1));    // return -1 (not found)
        Console.WriteLine("3: " + lRUCache.Get(3));    // return 3
        Console.WriteLine("4: " + lRUCache.Get(4));    // return 4
#endif
    }
}