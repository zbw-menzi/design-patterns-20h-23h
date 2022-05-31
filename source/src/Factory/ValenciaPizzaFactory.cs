namespace ZbW.DesignPatterns.Factory
{
    public class ValenciaPizzaFactory : IPizzaFactory
    {
        public Pizza CreatePizza()
        {
            return new ValenciaPizza();
        }
    }
}