namespace Zbw.DesignPatterns.Adapter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EmployeeManager
    {
        private readonly List<IEmployee> _employees;

        public EmployeeManager()
        {
            _employees = new List<IEmployee>();
        }

        public void Add(IEmployee employee)
        {
            _employees.Add(employee);
        }

        public void Remove(IEmployee employee)
        {
            _employees.Remove(employee);
        }

        public decimal PaySalaries()
        {
            var total = _employees.Sum(e => e.GetSalary());

            //// Console should be an interface or use ILogger
            Console.WriteLine(total);

            return total;
        }
    }
}
