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
        private readonly IConsole _console;

        public EmployeeManager(IConsole console)
        {
            _employees = new List<IEmployee>();
            _console = console;
        }

        public void Add(IEmployee employee)
        {
            _employees.Add(employee);
        }

        public void Remove(IEmployee employee)
        {
            _employees.Remove(employee);
        }

        public void PaySalaries()
        {
            var total = _employees.Sum(e => e.GetSalary());

            _console.WriteLine(total);
        }
    }
}
