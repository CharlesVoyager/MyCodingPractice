// 1226. The Dining Philosophers

public class DiningPhilosophers
{

    private readonly SemaphoreSlim[] semaphores = new SemaphoreSlim[5] { new SemaphoreSlim(1), new SemaphoreSlim(1), new SemaphoreSlim(1), new SemaphoreSlim(1), new SemaphoreSlim(1) };


    public DiningPhilosophers()
    {
    }

    public void wantsToEat( int philosopher,
                            Action pickLeftFork,
                            Action pickRightFork,
                            Action eat,
                            Action putLeftFork,
                            Action putRightFork
        )
    {
        Console.WriteLine($"Philosopher {philosopher} is trying to eat.");

        int leftPhilospher = (philosopher + 1) % 5;
        int rightPhilospher = (philosopher == 0) ? 4 : philosopher - 1;

        semaphores[philosopher].Wait();

        semaphores[leftPhilospher].Wait();
        pickLeftFork();

        semaphores[rightPhilospher].Wait();
        pickRightFork();

        eat();

        putRightFork();
        semaphores[rightPhilospher].Release();

        putLeftFork();
        semaphores[leftPhilospher].Release();

        semaphores[philosopher].Release();
    }

}
class Program
{
    public static async Task Main(string[] args)
    {
        var service = new DiningPhilosophers();

        int n = 1;
            
        Console.WriteLine("Output:");

        Task[] tasks = new Task[5];

        for (int i = 0; i < 5; i++)
        {
            int philosopher = i;
            tasks[philosopher] = Task.Run(() =>
            {
                service.wantsToEat(philosopher,
                    () => Console.Write("[" + philosopher + ",1,1]"),   // Pick left fork
                    () => Console.Write("[" + philosopher + ",2,1]"),   // Pick right fork
                    () => Console.Write("[" + philosopher + ",0,3]"),   // Eat
                    () => Console.Write("[" + philosopher + ",1,2]"),   // Put left fork
                    () => Console.Write("[" + philosopher + ",2,2]")    // Put right fork
                    );
                //System.Diagnostics.Trace.WriteLine("O");
            });

        }

        // Wait for both threads to finish their work
        await Task.WhenAll(tasks);

        Console.WriteLine("\n\nExecution finished successfully.");
    }
}