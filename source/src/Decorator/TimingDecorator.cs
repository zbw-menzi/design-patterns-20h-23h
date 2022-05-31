namespace Zbw.DesignPatterns.Decorator
{
    using System.Diagnostics;

    using Zbw.DesignPatterns.Adapter;
    using Zbw.DesignPatterns.Strategy;

    public class TimingDecorator : IPricingStrategy
    {
        private readonly IPricingStrategy _strategy;
        private readonly IConsole _console;

        public TimingDecorator(IPricingStrategy strategy, IConsole console)
        {
            _strategy = strategy;
            _console = console;
        }

        public decimal GetTotal(Sale sale)
        {
            var swatch = Stopwatch.StartNew();
            _console.WriteLine(swatch.ElapsedMilliseconds);
            var result = _strategy.GetTotal(sale);
            _console.WriteLine(swatch.ElapsedMilliseconds);
            return result;
        }
    }
}
