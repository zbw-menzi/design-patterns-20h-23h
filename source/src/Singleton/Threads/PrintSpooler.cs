namespace ZbW.DesignPatterns.Singleton.Threads
{
    using System;
    using System.Collections.Generic;

    using Zbw.DesignPatterns.Singleton;

    public class PrintSpooler
    {
        private static PrintSpooler? _instance;

        private readonly Queue<PrintJob> _jobs;
        private volatile bool cancelRequested;

        private PrintSpooler()
        {
            _jobs = new Queue<PrintJob>();
        }

        private void ProcessPrintJobs(object obj)
        {
            while (!cancelRequested)
            {
                if (_jobs.Count > 0)
                {
                    var printJob = _jobs.Dequeue();
                    Console.WriteLine($"Print Job: {printJob}");
                }
            }
        }

        public void Start()
        {
            ProcessPrintJobs(null);
        }

        public void Stop()
        {
            cancelRequested = true;
        }

        public void Print(PrintJob printJob)
        {
            _jobs.Enqueue(printJob);
        }

        public static PrintSpooler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PrintSpooler();
            }

            return _instance;
        }
    }
}
