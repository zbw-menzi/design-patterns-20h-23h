namespace Zbw.DesignPatterns.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    using Zbw.DesignPatterns.Strategy;

    public class PricingStrategyFactory
    {
        public IPricingStrategy Create(string name)
        {
            if (name == "AbsoluteDiscountOverThreshold")
            {
                return new AbsoluteDiscountOverThresholdStrategy(100, 10);
            }

            if (name == "PercentagePricingStrategy")
            {
                return new PercentagePricingStrategy(10);
            }

            return new PercentagePricingStrategy(0);
        }

        public IPricingStrategy Create()
        {
            var strategyName = ConfigurationManager.AppSettings.Get("strategy");
            var className = $"Zbw.DesignPatterns.Strategy.{strategyName}Strategy";
            var type = Type.GetType(className);
            var instance = Activator.CreateInstance(type, new object[] { 100m, 10m });
            return (IPricingStrategy)instance;
        }
    }
}
