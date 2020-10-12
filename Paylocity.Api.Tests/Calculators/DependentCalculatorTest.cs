using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Api.Calculators;

namespace Paylocity.Api.Tests
{
    [TestClass]
    public class DependentCalculatorTest
    {
        private DependentCalculator _dependentCalculator;

        [TestInitialize]
        public void SetUp()
        {
            _dependentCalculator = new DependentCalculator();
        }


        [TestMethod]
        public void SetsTheBaseAnnualFeeTo_500()
        {
            Assert.AreEqual(500, _dependentCalculator.BaseAnnualDeduction);
        }

        [TestMethod]
        public void AppliesDiscount_WhenDependentNameStartsWithUppercaseA()
        {
            var deductions = _dependentCalculator.CalculateDeductions("Alex");
            Assert.AreEqual(1.92, deductions.Discount);
            Assert.AreEqual(19.23, deductions.Gross);
            Assert.AreEqual(17.31, deductions.Net);
        }

        [TestMethod]
        public void AppliesDiscount_WhenDependentNameStartsWithLowercaseA()
        {
            var deductions = _dependentCalculator.CalculateDeductions("alex");
            Assert.AreEqual(1.92, deductions.Discount);
            Assert.AreEqual(19.23, deductions.Gross);
            Assert.AreEqual(17.31, deductions.Net);
        }

        [TestMethod]
        public void DoesNotApplyDiscount_WhenDependentNameDoesNotStartsWithUppercaseOrLowerscaseA()
        {
            var deductions = _dependentCalculator.CalculateDeductions("Bre");
            Assert.AreEqual(0, deductions.Discount);
            Assert.AreEqual(19.23, deductions.Gross);
            Assert.AreEqual(19.23, deductions.Net);
        }
    }
}
