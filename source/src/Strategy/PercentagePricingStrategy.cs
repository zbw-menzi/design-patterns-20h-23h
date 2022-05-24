namespace Zbw.DesignPatterns.Strategy
{
    public class PercentagePricingStrategy : IPricingStrategy
    {
        private readonly decimal _percentage;

        public PercentagePricingStrategy(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal GetTotal(Sale sale)
        {
            return sale.Amount - sale.Amount / 100m * _percentage;
        }
    }
}