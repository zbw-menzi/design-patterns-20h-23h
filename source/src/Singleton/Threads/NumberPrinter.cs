namespace ZbW.DesignPatterns.Singleton.Threads
{
    using System;
    using System.Threading;

    using Zbw.DesignPatterns.Singleton;

    public class NumberPrinter : IDisposable
    {
        private readonly Timer _timer;
        private int count;

        public NumberPrinter()
        {
            _timer = new Timer(OnPrint, null, 0, 2000);
        }

        public void Dispose()
        {
            _timer.Dispose();
        }







































































        private void OnPrint(object state)
        {
            ThreadingPrintSpooler.GetInstance().Print(new PrintJob($"{count}"));
            count++;
        }
    }
}
