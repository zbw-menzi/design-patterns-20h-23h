namespace Zbw.DesignPatterns.Tests.Factory
{
    using System;
    using System.Collections.Generic;
using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Zbw.DesignPatterns.Factory;
using Zbw.DesignPatterns.Strategy;

    public class FactoryTests
    {
        [Fact]
        public void WhenStrategyInSettings_ThenReturnSpecificStrategy()
        {
            ConfigurationManager.AppSettings["strategy"] = "AbsoluteDiscountOverThreshold";
            var factory = new PricingStrategyFactory();
            var strategy = factory.Create();

            strategy.Should().BeOfType<AbsoluteDiscountOverThresholdStrategy>();
        }
    }
}
