namespace ZbW.DesignPatterns.Factory
{
    public class SaintGallPizzaFactory : IPizzaFactory
    {
        public Pizza CreatePizza()
        {
            return new SaintGallPizza();
        }
    }
}