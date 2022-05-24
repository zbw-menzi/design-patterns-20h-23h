namespace Zbw.DesignPatterns.Adapter
{
    public class EmployeeObjectAdapter : IEmployee
    {
        private readonly PresidentOfTheBoard _presidentOfTheBoard;

        public EmployeeObjectAdapter(PresidentOfTheBoard presidentOfTheBoard)
        {
            _presidentOfTheBoard = presidentOfTheBoard;
        }

        public decimal GetSalary()
        {
            return _presidentOfTheBoard.Bonus;
        }
    }
}
