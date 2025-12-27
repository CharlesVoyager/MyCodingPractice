class Program
{
    public static void Main()
    {
        List<int> list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        list.Add(6);
        list.Add(7);
        list.Add(8);
        list.Add(9);
        list.Add(10);

        int currentIndex = 0;
        while (list.Count > 0)
        {
            Console.WriteLine(list[currentIndex]);
            list.RemoveAt(0);

        }

        Console.WriteLine("Exit");  
    }
}