namespace Zbw.DesignPatterns.Tests.Adapter
{
    using FluentAssertions;

    using Moq;

    using Xunit;

    using Zbw.DesignPatterns.Adapter;

    public class EmployeeManagerTests
    {
        [Fact]
        public void GetSalaryObjectAdapter_WhenEmployeeAndPresident_ThenAllSalariesListed()
        {
            // Arrange
            var consoleMock = new Mock<IConsole>();
            var employeeManager = new EmployeeManager(consoleMock.Object);
            consoleMock.Setup(x => x.WriteLine(It.IsAny<decimal>()))
                       // Assert Option a)
                       .Callback<decimal>(x => x.Should().Be(1_160_000m));

            employeeManager.Add(new Employee(100_000m));
            employeeManager.Add(new Employee(060_000m));
            employeeManager.Add(new EmployeeObjectAdapter(new PresidentOfTheBoard(1_000_000m)));

            // Act
            employeeManager.PaySalaries();

            // Assert Option b)
            consoleMock.Verify(x => x.WriteLine(1_160_000m), Times.Once);
        }

        [Fact]
        public void GetSalaryClassAdapter_WhenEmployeeAndPresident_ThenAllSalariesListed()
        {
            // Arrange
            var result = 0m;
            var consoleMock = new Mock<IConsole>();
            var employeeManager = new EmployeeManager(consoleMock.Object);
            consoleMock.Setup(x => x.WriteLine(It.IsAny<decimal>()))
                       // Assert Option c)
                       .Callback<decimal>(x => result = x);

            employeeManager.Add(new Employee(100_000m));
            employeeManager.Add(new Employee(060_000m));
            employeeManager.Add(new EmployeeClassAdapter(1_000_000));

            // Act
            employeeManager.PaySalaries();

            // Assert Option c)
            result.Should().Be(1_160_000m);
        }
    }
}
