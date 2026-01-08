// 187. Repeated DNA Sequences

public class Solution
{

    HashSet<string> sequences = new HashSet<string>();

    public IList<string> FindRepeatedDnaSequences(string s)
    {
        HashSet<string> output = new HashSet<string>();

        for (int i = 0; i <= s.Length - 10; i++)
        {
            string dna = s.Substring(i, 10);
            if (sequences.Add(dna) == false)
                output.Add(dna);
        }
        return output.ToList();
    }
}

class Program
{
    public static void Main()
    {
        IList<string> results;
        Solution test = new Solution();

        //results = test.FindRepeatedDnaSequences("AAAAAAAAAAAAA");
        results = test.FindRepeatedDnaSequences("AAAAAAAAAAA");

        foreach (var result in results)
            Console.WriteLine(result);
    }
}
