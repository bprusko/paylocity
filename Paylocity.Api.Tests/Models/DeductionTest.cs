using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Api.Models;

namespace Paylocity.Api.Tests
{
    [TestClass]
    public class DeductionModelTest
    {
        [TestMethod]
        public void DeductionModel_CalculatesNetDeduction_WhenThereIsNoDiscount()
        {
            var deduction = new Deduction {
                Discount = 0,
                Gross = 1000
            };
            Assert.AreEqual(1000, deduction.Net);
        }

        [TestMethod]
        public void DeductionModel_CalculatesNetDeduction_WhenThereIsDiscount()
        {
            var deduction = new Deduction {
                Discount = 100,
                Gross = 1000
            };
            Assert.AreEqual(900, deduction.Net);
        }

    }
}
