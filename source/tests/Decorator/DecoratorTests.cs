namespace Zbw.DesignPatterns.Tests.Strategy
{
    using FluentAssertions;

    using Moq;

    using Zbw.DesignPatterns.Adapter;
    using Zbw.DesignPatterns.Composite;
    using Zbw.DesignPatterns.Decorator;
    using Zbw.DesignPatterns.Strategy;

    public class DecoratorTests
    {
        [Fact]
        public void Decorator_PriceBeforeAfterShouldBePrinted()
        {
            // Arrange
            var consoleMock = new Mock<IConsole>();

            var strategy1 = new PercentagePricingStrategy(10);
            var strategy2 = new AbsoluteDiscountOverThresholdStrategy(100, 20);

            var strategy = new CompositePricingStrategy();
            strategy.Add(strategy1);
            strategy.Add(strategy2);

            var decorator = new BeforeAfterPriceDecorator(strategy, consoleMock.Object);
            var sale = new Sale(decorator, 100);

            // Act
            var result = sale.GetTotal();

            // Assert
            consoleMock.Verify(x => x.WriteLine("Before: 100"), Times.Once);
            consoleMock.Verify(x => x.WriteLine("After: 80"), Times.Once);
        }

        [Fact]
        public void Decorator_TimingsShouldBePrinted()
        {
            // Arrange
            var consoleMock = new Mock<IConsole>();

            var strategy1 = new PercentagePricingStrategy(10);
            var strategy2 = new AbsoluteDiscountOverThresholdStrategy(100, 20);

            var strategy = new CompositePricingStrategy();
            strategy.Add(strategy1);
            strategy.Add(strategy2);

            var decorator1 = new BeforeAfterPriceDecorator(strategy, consoleMock.Object);
            var decorator2 = new TimingDecorator(decorator1, consoleMock.Object);
            var sale = new Sale(decorator2, 100);

            // Act
            var result = sale.GetTotal();

            // Assert
            consoleMock.Verify(x => x.WriteLine("Before: 100"), Times.Once);
            consoleMock.Verify(x => x.WriteLine("After: 80"), Times.Once);
            consoleMock.Verify(x => x.WriteLine(It.IsAny<decimal>()), Times.Exactly(2));
        }

        [Fact]
        public void ReflectionDemo()
        {
            Timer t1 = new Timer(OnPrint, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));

            var timingDecoratorType = typeof(TimingDecorator);
            var listDemo = typeof(List<>);

            var timingDecoratorConstructors = timingDecoratorType.GetConstructors();
            var timingDecoratorMethods = timingDecoratorType.GetMethods();
            var stringList = listDemo.MakeGenericType(typeof(string)); // new List<string>
            object? stringInstance = Activator.CreateInstance(stringList);
            var listAddMethod = stringList.GetMethod("Add");
            listAddMethod.Invoke(stringInstance, new[] { "Hallo" });
        }

        private void OnPrint(object? state)
        {
            throw new NotImplementedException();
        }
    }
}