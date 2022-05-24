namespace Zbw.DesignPatterns.Adapter
{
    // DO NOT use this, it's not so a good design: https://stackoverflow.com/a/9980953/2537999
    public class EmployeeClassAdapter : PresidentOfTheBoard, IEmployee
    {
        public EmployeeClassAdapter(decimal bonus)
            : base(bonus)
        {
        }

        public decimal GetSalary()
        {
            return Bonus;
        }
    }
}
