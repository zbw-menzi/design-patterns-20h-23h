namespace design_patterns.tests;

using FluentAssertions;

using Zbw.DesignPatterns;

public class SaleTests
{
    [Fact]
    public void GetTotalWith100_When10PercentDiscount_ThenReturn90()
    {
        // Arrange
        var strategy = new PercentagePricingStrategy(10);
        var sale = new Sale(strategy, 100);

        // Act
        var result = sale.GetTotal();
        
        // Assert
        result.Should().Be(90);
    }
}