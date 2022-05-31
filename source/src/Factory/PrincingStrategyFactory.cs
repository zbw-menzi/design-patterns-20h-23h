namespace ZbW.DesignPatterns.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    using Zbw.DesignPatterns.Strategy;

    using ZbW.DesignPatterns.Strategy;

    public class PrincingStrategyFactory
    {
        public IPricingStrategy Create(string strategyName)
        {
            if (strategyName.Equals("absolute"))
            {
                return new AbsoluteDiscountOverThresholdStrategy(100, 10);
            }

            if (strategyName.Equals("percentage"))
            {
                return new PercentagePricingStrategy(10);
            }

            return new NullDiscountStrategy();
        }

        public IPricingStrategy Create(string name, params object[] ctorParams)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            var allStrategies = types.Where(x => x.Name.EndsWith("Strategy") && !x.IsInterface).ToList();

            var strategy = allStrategies.SingleOrDefault(x => x.Name.Equals($"{name}Strategy", StringComparison.OrdinalIgnoreCase));
            var strategyInstance =  Activator.CreateInstance(strategy, ctorParams);

            return (IPricingStrategy)strategyInstance;
        }
    }
}
