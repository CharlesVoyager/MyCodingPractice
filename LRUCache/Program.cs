// 146. LRU Cache

// Wrong Answer
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

    int RecentlyUsedKeysCount()
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
    }
}