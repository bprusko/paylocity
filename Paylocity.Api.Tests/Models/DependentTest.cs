using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Api.Calculators;
using Paylocity.Api.Models;

namespace Paylocity.Api.Tests
{
    [TestClass]
    public class DependentTest
    {
        [TestMethod]
        public void GetCalculator_ReturnsDependentCalculator()
        {
            var dependent = new Dependent();
            var calculator = dependent.GetCalculator();
            Assert.IsTrue(calculator is DependentCalculator);
        }
    }
}
