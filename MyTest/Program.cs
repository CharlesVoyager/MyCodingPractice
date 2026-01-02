using System.Threading;
using System.Threading.Tasks;

public class H2O
{

    private readonly Barrier _barrier = new Barrier(2);
    private readonly SemaphoreSlim _semaphore2HDone = new SemaphoreSlim(0);

    static int HydrogenCalledCount = 0;

    public H2O()
    {

    }

    public void Hydrogen(Action releaseHydrogen)
    {

        HydrogenCalledCount++;

        while (HydrogenCalledCount > (_barrier.CurrentPhaseNumber + 1) * 2)
            Thread.Sleep(10);

        _barrier.SignalAndWait();

        releaseHydrogen();

        Console.WriteLine("HydrogenCalledCount: " + HydrogenCalledCount);

        if (HydrogenCalledCount % 2 == 0)
            _semaphore2HDone.Release();
    }

    public void Oxygen(Action releaseOxygen)
    {

        _semaphore2HDone.Wait();

        // releaseOxygen() outputs "O". Do not change or remove this line.
        releaseOxygen();
    }
}


class Program
{
    public static async Task Main(string[] args)
    {
        var service = new H2O();

        Task[] tasks = new Task[3];

        tasks[0] = Task.Run(() =>
        {
            service.Hydrogen(() => Console.Write("H"));
        });

        tasks[1] = Task.Run(() =>
        {
            service.Oxygen(() => Console.Write("O"));
        });

        tasks[2] = Task.Run(() =>
        {
            service.Hydrogen(() => Console.Write("H"));
        });

        // Wait for both threads to finish their work
        await Task.WhenAll(tasks);

        Console.WriteLine("\n\nExecution finished successfully.");
    }
}