namespace Zbw.DesignPatterns.Strategy
{
    public interface IPricingStrategy
    {
        decimal GetTotal(Sale sale);
    }
}