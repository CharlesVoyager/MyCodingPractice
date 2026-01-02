// 1117. Building H2O 

public class H2O
{

    private readonly Barrier _barrier = new Barrier(3);
    private readonly SemaphoreSlim collectH = new SemaphoreSlim(2);
    private readonly SemaphoreSlim collectO = new SemaphoreSlim(1);

    private readonly SemaphoreSlim printHDone = new SemaphoreSlim(0);

    private readonly object _lockObject = new object();

    public H2O()
    {
    }

    public void Hydrogen(Action releaseHydrogen)
    {
        collectH.Wait();
        _barrier.SignalAndWait();

        lock (_lockObject)
        {
            // releaseHydrogen() outputs "H". Do not change or remove this line.
            releaseHydrogen();
        }

        printHDone.Release();
        collectH.Release();
    }

    public void Oxygen(Action releaseOxygen)
    {

        collectO.Wait();
        _barrier.SignalAndWait();

        printHDone.Wait();
        printHDone.Wait();

        // releaseOxygen() outputs "O". Do not change or remove this line.
        releaseOxygen();

        collectO.Release();
    }
}
class Program
{
    public static async Task Main(string[] args)
    {
        var service = new H2O();

        //string input = "OOHHHH";
        string input = "HOHOHH";
        //string input = "OOHHHHOOHHHHOOHHHHOOHHHH";


        Console.WriteLine("Output:");

        Task[] tasks = new Task[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == 'O')
            {
                tasks[i] = Task.Run(() =>
                {
                    service.Oxygen(() => Console.Write("O"));
                    //System.Diagnostics.Trace.WriteLine("O");
                });
            }
            else if (input[i] == 'H')
            {
                tasks[i] = Task.Run(() =>
                {
                    service.Hydrogen(() => Console.Write("H"));
                    //System.Diagnostics.Trace.WriteLine("H");
                });
            }
        }

        // Wait for both threads to finish their work
        await Task.WhenAll(tasks);

        Console.WriteLine("\n\nExpected:");

        for(int i = 0; i < input.Length / 3; i++)
            Console.Write("HHO");

        Console.WriteLine("\n\nExecution finished successfully.");
    }
}