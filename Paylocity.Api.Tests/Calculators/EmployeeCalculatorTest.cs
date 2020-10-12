using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Api.Calculators;

namespace Paylocity.Api.Tests
{
    [TestClass]
    public class EmployeeCalculatorTest
    {
        private EmployeeCalculator _employeeCalculator;

        [TestInitialize]
        public void SetUp()
        {
            _employeeCalculator = new EmployeeCalculator();
        }

        [TestMethod]
        public void SetsTheBaseAnnualFeeTo_1000()
        {
            Assert.AreEqual(1000, _employeeCalculator.BaseAnnualDeduction);
        }

        [TestMethod]
        public void AppliesDiscount_WhenEmployeeNameStartsWithUppercaseA()
        {
            var deductions = _employeeCalculator.CalculateDeductions("Alex");
            Assert.AreEqual(3.85, deductions.Discount);
            Assert.AreEqual(38.46, deductions.Gross);
            Assert.AreEqual(34.61, deductions.Net);
        }

        [TestMethod]
        public void AppliesDiscount_WhenEmployeeNameStartsWithLowercaseA()
        {
            var deductions = _employeeCalculator.CalculateDeductions("alex");
            Assert.AreEqual(3.85, deductions.Discount);
            Assert.AreEqual(38.46, deductions.Gross);
            Assert.AreEqual(34.61, deductions.Net);
        }

        [TestMethod]
        public void DoesNotApplyDiscount_WhenEmployeeNameDoesNotStartsWithUppercaseOrLowerscaseA()
        {
            var deductions = _employeeCalculator.CalculateDeductions("Bre");
            Assert.AreEqual(0, deductions.Discount);
            Assert.AreEqual(38.46, deductions.Gross);
            Assert.AreEqual(38.46, deductions.Net);
        }
    }
}
