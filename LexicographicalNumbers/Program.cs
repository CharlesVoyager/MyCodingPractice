// 386. Lexicographical Numbers

public class Solution
{
    public IList<int> LexicalOrder(int n)
    {
        Trie trie = new Trie();
        for (int i = 1; i <= n; i++)
            trie.Insert(i.ToString());

        List<int> output = new List<int>();
        trie.GetAllNumbers(output);

        return output;
    }
}

public class TrieNode
{
    public TrieNode[] Children = new TrieNode[10];   // 0, 1, 2,..., 9
    public bool IsEnd = false;

    public TrieNode Set(char letter)
    {
        int index = letter - 0x30;

        if (Children[index] == null)
            Children[index] = new TrieNode();

        return Children[index];
    }
    public TrieNode Get(char letter)
    {
        return Children[letter - 0x30];
    }
}

public class Trie
{
    public TrieNode root = new TrieNode();
    public Trie()
    {
    }

    public void Insert(string word)
    {
        TrieNode node = root;

        foreach (char c in word)
            node = node.Set(c);

        node.IsEnd = true;
    }

    public bool Search(string word)
    {
        TrieNode node = root;

        foreach (char c in word)
        {
            node = node.Get(c);
            if (node == null)
                return false;
        }

        return node.IsEnd;
    }

    public bool StartsWith(string prefix)
    {
        TrieNode node = root;

        foreach (char c in prefix)
        {
            node = node.Get(c);
            if (node == null)
                return false;
        }
        return true;
    }

    public void GetAllNumbers(List<int> output)
    {
        DeepFirstSearch(root, "", output);
    }

    void DeepFirstSearch(TrieNode node, string num, List<int> output)
    {
        if (node == null)
            return;

        if (node.IsEnd)
            output.Add(Convert.ToInt32(num));

        DeepFirstSearch(node.Get('0'), num + "0", output);
        DeepFirstSearch(node.Get('1'), num + "1", output);
        DeepFirstSearch(node.Get('2'), num + "2", output);
        DeepFirstSearch(node.Get('3'), num + "3", output);
        DeepFirstSearch(node.Get('4'), num + "4", output);
        DeepFirstSearch(node.Get('5'), num + "5", output);
        DeepFirstSearch(node.Get('6'), num + "6", output);
        DeepFirstSearch(node.Get('7'), num + "7", output);
        DeepFirstSearch(node.Get('8'), num + "8", output);
        DeepFirstSearch(node.Get('9'), num + "9", output);
    }
}

class Program
{
    static bool TestCase(int n, IList<int> expected)
    {
        Solution test = new Solution();
        IList<int> output = test.LexicalOrder(n);
        bool result = true;
        if (output.Count != expected.Count)
            result = false;
        else
        {
            for (int i = 0; i < output.Count; i++)
            {
                if (output[i] != expected[i])
                {
                    result = false;
                    break;
                }
            }
        }
        Console.WriteLine(" Output: [" + string.Join(", ", output) + "] Expected: [" + string.Join(", ", expected) + "] Result: " + (result ? "PASS" : "FAIL"));
        return result;
    }
    public static void Main()
    {
        TestCase(13, new List<int> { 1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9 });
        TestCase(2, new List<int> { 1, 2 });
    }
}