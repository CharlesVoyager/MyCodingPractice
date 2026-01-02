using System.Threading;
using System.Threading.Tasks;

public class H2O
{

    private readonly Barrier _barrier = new Barrier(3);
    private readonly SemaphoreSlim collectH = new SemaphoreSlim(2);
    private readonly SemaphoreSlim collectO = new SemaphoreSlim(1);



    public H2O()
    {

    }

    public void Hydrogen(Action releaseHydrogen)
    {

        collectH.Wait();
        _barrier.SignalAndWait();

        releaseHydrogen();

        collectH.Release();
    }

    public void Oxygen(Action releaseOxygen)
    {

        collectO.Wait();
        _barrier.SignalAndWait();

        Thread.Sleep(10);   

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

        Task[] tasks = new Task[6];

        tasks[0] = Task.Run(() =>
        {
            service.Oxygen(() => System.Diagnostics.Trace.WriteLine("O"));
            Console.Write("O");
        });

        tasks[1] = Task.Run(() =>
        {
            service.Oxygen(() => System.Diagnostics.Trace.WriteLine("O"));
            Console.Write("O");
        });

        tasks[2] = Task.Run(() =>
        {
            service.Hydrogen(() => System.Diagnostics.Trace.WriteLine("H"));
            Console.Write("H");
        });


        tasks[3] = Task.Run(() =>
        {
            service.Hydrogen(() => System.Diagnostics.Trace.WriteLine("H"));
            Console.Write("H");
        });

        tasks[4] = Task.Run(() =>
        {
            service.Hydrogen(() => System.Diagnostics.Trace.WriteLine("H"));
            Console.Write("H");
        });

        tasks[5] = Task.Run(() =>
        {
            service.Hydrogen(() => System.Diagnostics.Trace.WriteLine("H"));
            Console.Write("H");
        });


        // Wait for both threads to finish their work
        await Task.WhenAll(tasks);

        Console.WriteLine("\n\nExecution finished successfully.");
    }
}