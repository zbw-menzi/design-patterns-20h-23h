namespace ZbW.DesignPatterns.Singleton.Threads
{
    using System;
    using System.Threading;

    using Zbw.DesignPatterns.Singleton;

    public class TextPrinter : IDisposable
    {
        private const string Text = "The answer is 42";
        private readonly Timer _timer;

        public TextPrinter()
        {
            _timer = new Timer(OnPrint, null, 0, 3000);
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        private void OnPrint(object state)
        {
            ThreadingPrintSpooler.GetInstance().Print(new PrintJob(Text));
        }
    }
}
