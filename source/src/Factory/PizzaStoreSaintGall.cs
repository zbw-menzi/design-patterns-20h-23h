namespace ZbW.DesignPatterns.Factory
{
    public class PizzaStoreSaintGall : PizzaStoreBase
    {
        public PizzaStoreSaintGall()
        {
        }

        public override Pizza CreatePizza()
        {
            return new SaintGallPizza();
        }
    }
}
