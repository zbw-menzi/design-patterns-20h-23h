namespace ZbW.DesignPatterns.Singleton.Threads
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Zbw.DesignPatterns.Singleton;

    public class ThreadingPrintSpooler
    {
        private static ThreadingPrintSpooler? _instance;

        private readonly Queue<PrintJob> _jobs;
        private readonly Thread _thread;
        private volatile bool cancelRequested;
        private readonly AutoResetEvent _autoResetEvent;
        
        private ThreadingPrintSpooler()
        {
            _jobs = new Queue<PrintJob>();
            _thread = new Thread(ProcessPrintJobs);
            _autoResetEvent = new AutoResetEvent(false);
        }

        private void ProcessPrintJobs(object obj)
        {
            while (!cancelRequested)
            {
                if (_autoResetEvent.WaitOne())
                {
                    while (_jobs.Count > 0)
                    {
                        var printJob = _jobs.Dequeue();
                        Console.WriteLine($"Print Job: {printJob}");
                    }
                }
            }
        }

        public void Start()
        {
            _thread.Start();
        }

        public void Stop()
        {
            cancelRequested = true;
            _autoResetEvent.Set();
            _thread.Join();
        }

        public void Print(PrintJob printJob)
        {
            _jobs.Enqueue(printJob);
            _autoResetEvent.Set();
        }

        public static ThreadingPrintSpooler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ThreadingPrintSpooler();
            }

            return _instance;
        }
    }
}
