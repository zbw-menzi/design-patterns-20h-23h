using System.Collections.Generic;

namespace ZbW.DesignPatterns.Factory
{
    public abstract class Pizza
    {
        private readonly HashSet<string> _ingredients;

        protected Pizza()
        {
            _ingredients = new HashSet<string>();
            Add("Mozzarella");
            Add("Tomato");
        }

        public void Add(string ingredient)
        {
            _ingredients.Add(ingredient);
        }

        public IReadOnlyCollection<string> Ingredients => _ingredients;
    }
}