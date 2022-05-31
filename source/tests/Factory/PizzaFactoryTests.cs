namespace Zbw.DesignPatterns.Tests.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FluentAssertions;

    using ZbW.DesignPatterns.Factory;

    public class PizzaFactoryTests
    {
        [Fact]
        public void AbstractFactoryCreatePizza_WhenSG_ThenBratwurst()
        {
            var factory = new SaintGallPizzaFactory();
            var store = new PizzaStore(factory);
            var pizza = store.CreatePizza();

            pizza.Ingredients.Should().Contain("OLMA Kinderfest Bratwurst");
        }

        [Fact]
        public void AbstractFactoryCreatePizza_WhenValencia_ThenPaella()
        {
            var factory = new ValenciaPizzaFactory();
            var store = new PizzaStore(factory);
            var pizza = store.CreatePizza();

            pizza.Ingredients.Should().Contain("Paella");
        }

        [Fact]
        public void FactoryMethodCreatePizza_WhenValencia_ThenPaella()
        {
            var pizzaStore = new PizzaStoreValencia();
            var pizza = pizzaStore.CreatePizza();

            pizza.Ingredients.Should().Contain("Paella");
        }

        [Fact]
        public void FactoryMethodCreatePizza_WhenSG_ThenBratwurst()
        {
            var pizzaStore = new PizzaStoreSaintGall();
            var pizza = pizzaStore.CreatePizza();

            pizza.Ingredients.Should().Contain("OLMA Kinderfest Bratwurst");
        }
    }
}
