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
            Assert.AreEqual(1000, _employeeCalculator.BaseAnnualFee);
        }

        [TestMethod]
        public void AppliesDiscount_WhenEmployeeNameStartsWithUppercaseA()
        {
            var fees = _employeeCalculator.CalculateDeductions("Alex");
            Assert.AreEqual(3.85, fees.Discount);
            Assert.AreEqual(38.46, fees.Gross);
            Assert.AreEqual(34.61, fees.Net);
        }

        [TestMethod]
        public void AppliesDiscount_WhenEmployeeNameStartsWithLowercaseA()
        {
            var fees = _employeeCalculator.CalculateDeductions("alex");
            Assert.AreEqual(3.85, fees.Discount);
            Assert.AreEqual(38.46, fees.Gross);
            Assert.AreEqual(34.61, fees.Net);
        }

        [TestMethod]
        public void DoesNotApplyDiscount_WhenEmployeeNameDoesNotStartsWithUppercaseOrLowerscaseA()
        {
            var fees = _employeeCalculator.CalculateDeductions("Bre");
            Assert.AreEqual(0, fees.Discount);
            Assert.AreEqual(38.46, fees.Gross);
            Assert.AreEqual(38.46, fees.Net);
        }
    }
}
