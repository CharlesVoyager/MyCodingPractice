// 1117. Building H2O 

using System.Threading;
using System.Threading.Tasks;

public class H2O
{
    private readonly Barrier _barrier = new Barrier(3);
    private readonly SemaphoreSlim collectH = new SemaphoreSlim(2);
    private readonly SemaphoreSlim collectO = new SemaphoreSlim(1);

    private readonly SemaphoreSlim printHDone = new SemaphoreSlim(0);

    public H2O()
    {

    }

    public void Hydrogen(Action releaseHydrogen)
    {

        collectH.Wait();
        _barrier.SignalAndWait();

        releaseHydrogen();

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

        string input = "OOHHHH";

        Task[] tasks = new Task[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char atom = input[i];
            if (atom == 'O')
            {
                tasks[i] = Task.Run(() =>
                {
                    service.Oxygen(() => System.Diagnostics.Trace.WriteLine("O"));
                    Console.Write("O");
                });
            }
            else if (atom == 'H')
            {
                tasks[i] = Task.Run(() =>
                {
                    service.Hydrogen(() => System.Diagnostics.Trace.WriteLine("H"));
                    Console.Write("H");
                });
            }
        }

        // Wait for both threads to finish their work
        await Task.WhenAll(tasks);

        Console.WriteLine("\n\nExecution finished successfully.");
    }
}