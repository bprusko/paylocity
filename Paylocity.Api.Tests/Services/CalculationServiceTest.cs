using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Api.Services;
using Paylocity.Api.Models;

namespace Paylocity.Api.Tests
{
    [TestClass]
    public class CalculationServiceTest
    {
        CalculationService _calculationService;

        [TestInitialize]
        public void SetUp()
        {
            _calculationService = new CalculationService();
        }

        [TestMethod]
        public void CalculateFees_CalculatesEmployeeFees()
        {
            var employee = new Employee{ FirstName = "Dwayne", LastName = "Johnson"};
            var fees = _calculationService.CalculateFees(employee);
            Assert.AreEqual(0, fees.Discount);
            Assert.AreEqual(38.46, fees.Gross);
            Assert.AreEqual(38.46, fees.Net);
        }

        [TestMethod]
        public void CalculateFees_CalculatesDependentFees()
        {
            var depdendent = new Dependent{ FirstName = "Mick", LastName = "Foley"};
            var fees = _calculationService.CalculateFees(depdendent);
            Assert.AreEqual(0, fees.Discount);
            Assert.AreEqual(19.23, fees.Gross);
            Assert.AreEqual(19.23, fees.Net);
        }
    }
}
