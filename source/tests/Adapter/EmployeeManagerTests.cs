namespace design_patterns.tests.Adapter
{
    using FluentAssertions;

    using Xunit;

    using Zbw.DesignPatterns.Adapter;

    public class EmployeeManagerTests
    {
        [Fact]
        public void GetSalaryObjectAdapter_WhenEmployeeAndPresident_ThenAllSalariesListed()
        {
            // Arrange
            var employeeManager = new EmployeeManager();

            employeeManager.Add(new Employee(100_000m));
            employeeManager.Add(new Employee(060_000m));
            employeeManager.Add(new EmployeeObjectAdapter(new PresidentOfTheBoard(1_000_000m)));

            // Act
            var result = employeeManager.PaySalaries();

            // Assert
            result.Should().Be(1_160_000m);
        }

        [Fact]
        public void GetSalaryClassAdapter_WhenEmployeeAndPresident_ThenAllSalariesListed()
        {
            // Arrange
            var employeeManager = new EmployeeManager();

            employeeManager.Add(new Employee(100_000m));
            employeeManager.Add(new Employee(060_000m));
            employeeManager.Add(new EmployeeClassAdapter(1_000_000));

            // Act
            var result = employeeManager.PaySalaries();

            // Assert
            result.Should().Be(1_160_000m);
        }
    }
}
