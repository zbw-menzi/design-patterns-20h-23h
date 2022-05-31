namespace Zbw.DesignPatterns.Decorator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Zbw.DesignPatterns.Adapter;
    using Zbw.DesignPatterns.Strategy;

    public class BeforeAfterPriceDecorator : IPricingStrategy
    {
        private readonly IPricingStrategy _strategy;
        private readonly IConsole _console;

        public BeforeAfterPriceDecorator(IPricingStrategy strategy, IConsole console)
        {
            _strategy = strategy;
            _console = console;
        }

        public decimal GetTotal(Sale sale)
        {
            _console.WriteLine($"Before: {sale.Amount}");
            
            var result =  _strategy.GetTotal(sale);
            
            _console.WriteLine($"After: {result}");
            return result;
        }
    }
}
