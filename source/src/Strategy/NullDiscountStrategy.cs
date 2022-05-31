namespace ZbW.DesignPatterns.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Zbw.DesignPatterns.Strategy;

    public class NullDiscountStrategy : IPricingStrategy
    {
        public decimal GetTotal(Sale sale)
        {
            return sale.Amount;
        }
    }
}
