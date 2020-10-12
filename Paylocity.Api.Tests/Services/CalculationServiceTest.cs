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
        public void CalculateDeductions_CalculatesEmployeeFees()
        {
            var employee = new Employee{ FirstName = "Dwayne", LastName = "Johnson"};
            var deductions = _calculationService.CalculateDeductions(employee);
            Assert.AreEqual(0, deductions.Discount);
            Assert.AreEqual(38.46, deductions.Gross);
            Assert.AreEqual(38.46, deductions.Net);
        }

        [TestMethod]
        public void CalculateDeductions_CalculatesDependentFees()
        {
            var depdendent = new Dependent{ FirstName = "Mick", LastName = "Foley"};
            var deductions = _calculationService.CalculateDeductions(depdendent);
            Assert.AreEqual(0, deductions.Discount);
            Assert.AreEqual(19.23, deductions.Gross);
            Assert.AreEqual(19.23, deductions.Net);
        }
    }
}
