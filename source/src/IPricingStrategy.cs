namespace Zbw.DesignPatterns
{
    public interface IPricingStrategy
    {
        decimal GetTotal(Sale sale);
    }
}