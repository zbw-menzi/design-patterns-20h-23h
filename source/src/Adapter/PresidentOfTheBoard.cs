namespace Zbw.DesignPatterns.Adapter
{
    public class PresidentOfTheBoard
    {
        private readonly decimal _bonus;

        public PresidentOfTheBoard(decimal bonus)
        {
            _bonus = bonus;
        }

        public decimal Bonus => _bonus;
    }
}
