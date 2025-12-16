// 208: Implement Trie (Prefix Tree)

public class Node
{
    public Node[] Nodes = new Node[52];    // 0:A, 1:B, ... 
    public int Value = 0;

    public Node Set(char letter)
    {
        int index = LetterToIndex(letter);

        if (Nodes[index] == null)
            Nodes[index] = new Node();

        return Nodes[index];
    }

    public Node Get(char letter)
    {
        int index = LetterToIndex(letter);
        return Nodes[index];
    }

    int LetterToIndex(char c)
    {
        if (c >= 'A' && c <= 'Z')
            return c - 0x41;
        else if (c >= 'a' && c <= 'z')
            return c - 0x61 + 26;
        else
            return 0;
    }
}


public class Trie
{
    int NumberOfString = 1;
    Node root = new Node();
    public Trie()
    {
    }

    public void Insert(string word)
    {
        Node node = root;

        foreach (char c in word)
            node = node.Set(c);

        node.Value = NumberOfString++;
    }

    public bool Search(string word)
    {
        Node node = root;

        foreach (char c in word)
        {   
            node = node.Get(c);
            if (node == null)
                return false;
        }

        if (node.Value == 0)
            return false;
        else
            return true;
    }

    public bool StartsWith(string prefix)
    {
        Node node = root;

        foreach (char c in prefix)
        {
            node = node.Get(c);
            if (node == null)
                return false;
        }
        return true;
    }

    int LetterToIndex(char c)
    {
        if (c >= 'A' && c <= 'Z')
            return c - 0x41;
        else if (c >= 'a' && c <= 'z')
            return c - 0x61 + 26;
        else
            return 0;
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
        //obj.Insert("beer");
        //obj.Insert("add");
        //obj.Insert("jam");
        //obj.Insert("rental");
        //obj.Insert("apps");


        bool param_2 = obj.Search("app");
     //   bool param_3 = obj.StartsWith("App");

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