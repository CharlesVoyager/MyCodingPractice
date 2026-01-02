using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class FooBar
    {
        private readonly SemaphoreSlim _semaphoreFoo = new SemaphoreSlim(0);
        private readonly SemaphoreSlim _semaphoreBar = new SemaphoreSlim(1);
        private int n;

        public FooBar(int n)
        {
            this.n = n;
        }

        public void Foo(Action printFoo)
        {
            for (int i = 0; i < n; i++)
            {
                _semaphoreFoo.Wait();

                printFoo();

                //_semaphoreFoo.Release();
            }
        }

        public void Bar(Action printBar)
        {
            for (int i = 0; i < n; i++)
            {
                _semaphoreFoo.Wait();

                printBar();

                //_semaphoreBar.Release();
            }
        }

        public void ReleaseFoo()
        {
            int count = _semaphoreFoo.Release();
            System.Diagnostics.Trace.WriteLine("ReleaseFoo() ==> Count: " + count);
        }

        public void ReleaseBar()
        {
            int count = _semaphoreBar.Release();
            System.Diagnostics.Trace.WriteLine("ReleaseBar() ==> Count: " + count);
        }
    }

    public partial class MainWindow : Window
    {
        FooBar service;
        public MainWindow()
        {
            InitializeComponent();

          //  Console.WriteLine("Starting FooBar Server...\n");
           // System.Diagnostics.Trace.WriteLine("Starting FooBar Server...\n");
             Main();

        }

        async Task Main()
        {
            System.Diagnostics.Trace.WriteLine("Starting FooBar Server...\n");
            int n = 10; // Number of iterations

            service = new FooBar(n);

            // Create two concurrent tasks (threads)
            Task threadFoo = Task.Run(() =>
            {
                service.Foo(() => PrintLog("foo"));
            });

            Task threadBar = Task.Run(() =>
            {
                service.Bar(() => PrintLog("bar"));
            });

            // Wait for both threads to finish their work
            await Task.WhenAll(threadFoo, threadBar);

            System.Diagnostics.Trace.WriteLine("\n\nExecution finished successfully.");
        }

        void PrintLog(string message)
        {
            this.Dispatcher.Invoke(() =>
            {
                LogTextBox.AppendText(message);
                LogTextBox.ScrollToEnd();
            });
        }

        private void FooRelease_Click(object sender, RoutedEventArgs e)
        {
            service.ReleaseFoo();
        }

        private void BarRelease_Click(object sender, RoutedEventArgs e)
        {
            service.ReleaseBar();
        }
    }
}