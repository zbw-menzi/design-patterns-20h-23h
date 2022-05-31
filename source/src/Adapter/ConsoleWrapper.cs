namespace Zbw.DesignPatterns.Adapter
{
    using System;

    internal class ConsoleWrapper : IConsole
    {
        public void WriteLine(decimal value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
