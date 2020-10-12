using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Api.ViewModels;

namespace Paylocity.Api.Tests
{
    [TestClass]
    public class DeductionVieModelTest
    {
        [TestMethod]
        public void DeductionViewModel_CalculatesNetDeduction_WhenThereIsNoDiscount()
        {
            var deduction = new Deduction {
                Discount = 0,
                Gross = 1000
            };
            Assert.AreEqual(1000, deduction.Net);
        }

        [TestMethod]
        public void DeductionViewModel_CalculatesNetDeduction_WhenThereIsDiscount()
        {
            var deduction = new Deduction {
                Discount = 100,
                Gross = 1000
            };
            Assert.AreEqual(900, deduction.Net);
        }

    }
}
