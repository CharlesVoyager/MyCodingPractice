// 208: Implement Trie (Prefix Tree)

using System.Xml.Linq;

public class TrieNode
{
    public TrieNode[] Children = new TrieNode[26];   // only lowercase English letters.
    public bool IsEnd = false;

    public TrieNode Set(char letter)
    {
        int index = letter - 0x61;

        if (Children[index] == null)
            Children[index] = new TrieNode();

        return Children[index];
    }
    public TrieNode Get(char letter)
    {
        return Children[letter - 0x61];
    }
}

public class Trie
{
    TrieNode root = new TrieNode();
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
}

class Program
{
    public static void Main()
    {
        Trie obj = new Trie();

        // ["app"],["apple"],["beer"],["add"],["jam"],["rental"],["apps"]
        obj.Insert("app");
        obj.Insert("apple");
        obj.Insert("beer");
        obj.Insert("add");
        obj.Insert("jam");
        obj.Insert("rental");
        obj.Insert("apps");


        bool param_2 = obj.Search("app");
        bool param_3 = obj.StartsWith("badx");
        bool param_4 = obj.StartsWith("bee");

        Console.WriteLine("Search app: " + param_2.ToString());

    }
}


/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */