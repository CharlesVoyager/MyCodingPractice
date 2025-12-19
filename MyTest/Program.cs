class Program
{
    public static void Main()
    {
        float a = 1.239f;

        Console.WriteLine(a);


        float b = 1234567890123f;

        float c = 12345678901999f;
        Console.WriteLine(b);

        if (b == c)
            Console.WriteLine("b equals c");
        else
        {
            Console.WriteLine("b NOT equals c");
        }
    }
}