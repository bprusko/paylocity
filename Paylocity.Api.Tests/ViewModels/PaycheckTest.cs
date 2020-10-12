using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Api.ViewModels;

namespace Paylocity.Api.Tests
{
    [TestClass]
    public class PaycheckVieModelTest
    {
        [TestMethod]
        public void PaycheckViewModel_DefinesBiweeklyBaseRate()
        {
            var paycheck = new Paycheck();
            Assert.AreEqual(2000, paycheck.BiweeklyBase);
        }

        [TestMethod]
        public void PaycheckViewModel_CalculatesNetPay()
        {
            var paycheck = new Paycheck{
                Employee = TestData.Paycheck.Employee,
                Dependents = TestData.Paycheck.Dependents
            };

            Assert.AreEqual(1942.31, paycheck.NetPay);
        }

        [TestMethod]
        public void PaycheckViewModel_CalculatesTotalDeductions_WhenAnEmployeeHasDependents()
        {
            var paycheck = new Paycheck{
                Employee = TestData.Paycheck.Employee,
                Dependents = TestData.Paycheck.Dependents
            };

            Assert.AreEqual(0, paycheck.TotalDeductions.Discount);
            Assert.AreEqual(57.69, paycheck.TotalDeductions.Gross);
            Assert.AreEqual(57.69, paycheck.TotalDeductions.Net);
        }

        [TestMethod]
        public void PaycheckViewModel_CalculatesTotalDeductions_WhenAnEmployeeHasNoDependents()
        {
            var paycheck = new Paycheck{
                Employee = TestData.Paycheck.Employee
            };

            Assert.AreEqual(0, paycheck.TotalDeductions.Discount);
            Assert.AreEqual(38.46, paycheck.TotalDeductions.Gross);
            Assert.AreEqual(38.46, paycheck.TotalDeductions.Net);
        }

    }
}
