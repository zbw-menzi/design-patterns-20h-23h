namespace ZbW.DesignPatterns.Singleton.Tpl
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;

    using Zbw.DesignPatterns.Singleton;

    public class TplPrintSpooler : IAsyncDisposable
    {
        private static TplPrintSpooler? _instance;

        private readonly BlockingCollection<PrintJob> _jobs;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly Task _task;

        private TplPrintSpooler()
        {
            _jobs = new BlockingCollection<PrintJob>(new ConcurrentQueue<PrintJob>());
            _cancellationTokenSource = new CancellationTokenSource();
            _task = new Task(ProcessPrintJobs, _cancellationTokenSource.Token);
        }

        private void ProcessPrintJobs()
        {
            foreach (var job in _jobs.GetConsumingEnumerable(_cancellationTokenSource.Token))
            {
                Console.WriteLine(job.ToString());
            }
        }

        public void Start()
        {
            Task.Run(() => _task);
        }

        public void Stop()
        {
            _jobs.CompleteAdding();
        }

        public void Print(PrintJob printJob)
        {
            _jobs.Add(printJob);
        }

        public static TplPrintSpooler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TplPrintSpooler();
            }

            return _instance;
        }

        public async ValueTask DisposeAsync()
        {
            _cancellationTokenSource.Cancel();
            await _task.ConfigureAwait(false);
        }
    }
}
