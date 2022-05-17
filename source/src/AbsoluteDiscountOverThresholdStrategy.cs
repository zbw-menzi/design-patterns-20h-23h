namespace ZbW.DesignPatterns.Strategy
{
    using Zbw.DesignPatterns;

    public class AbsoluteDiscountOverThresholdStrategy : IPricingStrategy
    {
        private readonly decimal _threshold;
        private readonly decimal _absoluteDiscount;

        public AbsoluteDiscountOverThresholdStrategy(decimal threshold, decimal absoluteDiscount)
        {
            _threshold = threshold;
            _absoluteDiscount = absoluteDiscount;
        }

        public decimal GetTotal(Sale sale)
        {
            if (sale.Amount >= _threshold)
            {
                return sale.Amount - _absoluteDiscount;
            }

            return sale.Amount;
        }
    }
}
