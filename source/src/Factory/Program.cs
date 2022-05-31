using System;
using System.Configuration;
using System.Reflection;

namespace ZbW.DesignPatterns.Factory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var location = ConfigurationManager.AppSettings["location"];
            var type = Assembly.GetExecutingAssembly().GetType($"ZbW.DesignPatterns.Factory.{location}PizzaFactory");
            //var pizzaFactory = (IPizzaFactory)type.GetConstructor(Array.Empty<Type>()).Invoke(Array.Empty<object>());
            IPizzaFactory pizzaFactory = (IPizzaFactory)Activator.CreateInstance(type);

            var pizzaStore = new PizzaStore(pizzaFactory);
            var pizza = pizzaStore.CreatePizza();
            Console.WriteLine($"{pizza.GetType().Name} created: {string.Join(",", pizza.Ingredients)}.");
            Console.ReadLine();
        }
    }
}
