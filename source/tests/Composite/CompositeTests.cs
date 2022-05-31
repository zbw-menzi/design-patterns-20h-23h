namespace Zbw.DesignPatterns.Tests.Strategy
{
    using FluentAssertions;

    using Moq;

    using Zbw.DesignPatterns.Composite;
    using Zbw.DesignPatterns.Strategy;

    public class CompositeTests
    {
        [Fact]
        public void GetTotal_ReturnLowestStrategyTotal()
        {
            // Arrange
            var strategy1 = new PercentagePricingStrategy(10);
            var strategy2 = new AbsoluteDiscountOverThresholdStrategy(100, 20);

            var strategy = new CompositePricingStrategy();
            strategy.Add(strategy1);
            strategy.Add(strategy2);

            var sale = new Sale(strategy, 100);

            var x = sale?.Amount;

            if (sale != null)
            {
                var y = sale.Amount;
            }

            // Act
            var result = sale.GetTotal();

            // Assert
            result.Should().Be(80);
        }
    }
}