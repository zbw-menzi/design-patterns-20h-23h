namespace design_patterns.tests;

using FluentAssertions;

using Moq;

using Zbw.DesignPatterns;

using ZbW.DesignPatterns.Strategy;

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

    [Theory]
    [InlineData("100", "100", "90")]
    [InlineData("100", "99", "99")]
    [InlineData("100", "101", "91")]
    public void AbsoluteDiscountOverThresholdStrategy(string threshold, string amount, string expectedResult)
    {
        // Arrange
        var absoluteDiscountOverThresholdStrategy = new AbsoluteDiscountOverThresholdStrategy(decimal.Parse(threshold), 10m);

        // Act
        var result = new Sale(absoluteDiscountOverThresholdStrategy, decimal.Parse(amount)).GetTotal();

        // Assert
        result.Should().Be(decimal.Parse(expectedResult));
    }

    [Fact]
    public void DoubleDiscountAfterLunchStrategy_WhenBefore12_ThenSingleDiscount()
    {
        // Arrange
        var timeSourceMock = new Mock<ITimeSource>();
        timeSourceMock.Setup(x => x.Now).Returns(new DateTime(2018, 1, 1, 11, 59, 59));

        var doubleDiscountAfterLunchStrategy = new DoubleDiscountAfterLunchStrategy(timeSourceMock.Object, 10m);

        // Act
        var result = new Sale(doubleDiscountAfterLunchStrategy, 100).GetTotal();

        timeSourceMock.Verify(x => x.Now, Times.Once);
        result.Should().Be(90);
    }

    [Fact]
    public void DoubleDiscountAfterLunchStrategy_WhenAfter12_ThenDoubleDiscount()
    {
        // Arrange
        var timeSourceMock = new Mock<ITimeSource>();
        timeSourceMock.Setup(x => x.Now).Returns(new DateTime(2018, 1, 1, 12, 01, 00));

        var doubleDiscountAfterLunchStrategy = new DoubleDiscountAfterLunchStrategy(timeSourceMock.Object, 10m);

        // Act
        var result = new Sale(doubleDiscountAfterLunchStrategy, 100).GetTotal();

        // Assert
        result.Should().Be(80);
    }
}