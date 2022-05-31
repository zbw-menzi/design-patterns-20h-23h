namespace ZbW.DesignPatterns.Factory
{
    public class PizzaStore
    {
        private readonly IPizzaFactory _pizzaFactory;

        public PizzaStore(IPizzaFactory pizzaFactory)
        {
            _pizzaFactory = pizzaFactory;
        }

        public Pizza CreatePizza()
        {
            return _pizzaFactory.CreatePizza();
        }
    }
}
