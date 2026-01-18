// 648. Replace Words

public class Solution
{
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        Trie trie = new Trie();
        foreach (string s in dictionary)
            trie.Insert(s);

        string[] words = sentence.Split(" ");
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = trie.FindReplaceWord(words[i]);
        }
        return string.Join(" ", words);
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

    // If no replace word is found, return original input string.
    public string FindReplaceWord(string input)
    {
        TrieNode node = root;
        string replaceWord = "";

        foreach (char c in input)
        {
            node = node.Get(c);

            if (node == null)
                break;
            else
            {
                replaceWord += c;

                if (node.IsEnd)
                    return replaceWord;
            }
        }
        return input;
    }
}

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

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        IList<string> dictionary1 = new List<string>() { "cat", "bat", "rat" };
        string sentence1 = "the cattle was rattled by the battery";
        Console.WriteLine(solution.ReplaceWords(dictionary1, sentence1));
        // Output: "the cat was rat by the bat"

#if true
        // Output: "the cat was rat by the bat"
        IList<string> dictionary2 = new List<string>() { "a", "b", "c" };
        string sentence2 = "aadsfasf absbs bbab cadsfafs";
        Console.WriteLine(solution.ReplaceWords(dictionary2, sentence2));
        // Output: "a a b c"
#endif
    }
}