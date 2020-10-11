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
            Assert.AreEqual(500, _dependentCalculator.BaseAnnualFee);
        }

        [TestMethod]
        public void AppliesDiscount_WhenDependentNameStartsWithUppercaseA()
        {
            var fees = _dependentCalculator.CalculateDeductions("Alex");
            Assert.AreEqual(1.92, fees.Discount);
            Assert.AreEqual(19.23, fees.Gross);
            Assert.AreEqual(17.31, fees.Net);
        }

        [TestMethod]
        public void AppliesDiscount_WhenDependentNameStartsWithLowercaseA()
        {
            var fees = _dependentCalculator.CalculateDeductions("alex");
            Assert.AreEqual(1.92, fees.Discount);
            Assert.AreEqual(19.23, fees.Gross);
            Assert.AreEqual(17.31, fees.Net);
        }

        [TestMethod]
        public void DoesNotApplyDiscount_WhenDependentNameDoesNotStartsWithUppercaseOrLowerscaseA()
        {
            var fees = _dependentCalculator.CalculateDeductions("Bre");
            Assert.AreEqual(0, fees.Discount);
            Assert.AreEqual(19.23, fees.Gross);
            Assert.AreEqual(19.23, fees.Net);
        }
    }
}
