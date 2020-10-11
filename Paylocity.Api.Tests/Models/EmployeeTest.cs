using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Api.Calculators;
using Paylocity.Api.Models;

namespace Paylocity.Api.Tests
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void GetCalculator_ReturnsEmployeeCalculator()
        {
            var employee = new Employee();
            var calculator = employee.GetCalculator();
            Assert.IsTrue(calculator is EmployeeCalculator);
        }

    }
}
