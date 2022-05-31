namespace ZbW.DesignPatterns.Tests.Singleton.Threading
{
    using Xunit;

    using Zbw.DesignPatterns.Singleton;

    using ZbW.DesignPatterns.Singleton.Threads;

    public class SingletonTests
    {
        [Fact]
        public void PrintJob_WhenAddingPrintJob_ThenPrintPrintJob()
        {
            // Arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            var printSpooler = ThreadingPrintSpooler.GetInstance();
            printSpooler.Start();

            // Act
            printSpooler.Print(new PrintJob("42"));
            printSpooler.Print(new PrintJob("42"));

            printSpooler.Stop();

            var output = sw.ToString();
            // Assert?
        }
    }
}
