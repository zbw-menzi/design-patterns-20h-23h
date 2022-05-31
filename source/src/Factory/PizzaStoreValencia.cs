namespace ZbW.DesignPatterns.Factory
{
    public class PizzaStoreValencia : PizzaStoreBase
    {
        public PizzaStoreValencia()
        {
        }

        public override Pizza CreatePizza()
        {
            return new ValenciaPizza();
        }
    }
}
