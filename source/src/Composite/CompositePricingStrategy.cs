namespace Zbw.DesignPatterns.Composite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Zbw.DesignPatterns.Strategy;

    public class CompositePricingStrategy : IPricingStrategy
    {
        private readonly List<IPricingStrategy> _strategies;

        public CompositePricingStrategy()
        {
            _strategies = new List<IPricingStrategy>();
        }

        public void Add(IPricingStrategy strategy)
        {
            _strategies.Add(strategy);
        }

        public decimal GetTotal(Sale sale)
        {
            return _strategies.Min(x => x.GetTotal(sale));
        }
    }
}
