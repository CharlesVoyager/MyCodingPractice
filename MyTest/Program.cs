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
    public static void Main()
    {
        Dictionary<int, bool> curPos = new Dictionary<int, bool>();

        curPos[0] = false;
        curPos[1] = true;

        curPos[0] = true;


        Console.WriteLine("\n\nExecution finished successfully.");
    }
}