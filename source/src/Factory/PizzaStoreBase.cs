namespace ZbW.DesignPatterns.Factory
{
    public abstract class PizzaStoreBase
    {
        protected PizzaStoreBase()
        {
        }

        public abstract Pizza CreatePizza();
    }
}
