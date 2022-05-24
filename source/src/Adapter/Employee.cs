namespace Zbw.DesignPatterns.Adapter
{
    public class Employee : IEmployee
    {
        private readonly decimal _salary;

        public Employee(decimal salary)
        {
            _salary = salary;
        }

        public decimal GetSalary()
        {
            return _salary;
        }
    }
}
