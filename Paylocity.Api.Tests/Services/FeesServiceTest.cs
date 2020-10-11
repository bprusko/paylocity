using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Api.Services.Interfaces;
using Paylocity.Api.Services;
using Paylocity.Api.Models;
using Moq;

namespace Paylocity.Api.Tests
{

    [TestClass]
    public class FeesServiceTest
    {
        private Mock<ICalculationService> _calculationService;
        private FeesService _feesService;

        [TestInitialize]
        public void SetUp()
        {
            _calculationService = new Mock<ICalculationService>();
            _feesService = new FeesService(_calculationService.Object);
        }

        [TestMethod]
        public void GetFees_CallsCalculatesFees_ForEmployeeAndEachDependent()
        {
            _calculationService.Setup(s => s.CalculateFees(It.IsAny<Employee>()))
                .Returns(TestData.EmployeeFees);

            _calculationService.Setup(s => s.CalculateFees(It.IsAny<Dependent>()))
                .Returns(TestData.DependentFees);

            var fees = _feesService.GetFees(TestData.FeesRequestWithDependents);

            _calculationService.Verify(c => c.CalculateFees(It.IsAny<Employee>()), Times.Once);

            var numberDependents = TestData.FeesRequestWithDependents.Dependents.Count;
            _calculationService.Verify(c => c.CalculateFees(It.IsAny<Dependent>()), Times.Exactly(numberDependents));
        }

        [TestMethod]
        public void GetFees_CallsCalculatesFeesForOnlyEmployee_WhenThereAreNoDependents()
        {
            _calculationService.Setup(s => s.CalculateFees(It.IsAny<Employee>()))
                .Returns(TestData.EmployeeFees);

            var fees = _feesService.GetFees(TestData.FeesRequestWithoutDependents);

            _calculationService.Verify(c => c.CalculateFees(It.IsAny<Employee>()), Times.Once);

            _calculationService.Verify(c => c.CalculateFees(It.IsAny<Dependent>()),
                Times.Never);
        }

        [TestMethod]
        public void GetFees_ReturnsEmployeeFees()
        {
            _calculationService.Setup(s => s.CalculateFees(It.IsAny<Employee>()))
                .Returns(TestData.EmployeeFees);

            _calculationService.Setup(s => s.CalculateFees(It.IsAny<Dependent>()))
                .Returns(TestData.DependentFees);

            var fees = _feesService.GetFees(TestData.FeesRequestWithoutDependents);

            Assert.AreEqual(TestData.EmployeeFees.Discount, fees.Employee.FeeTotals.Discount);
            Assert.AreEqual(TestData.EmployeeFees.Gross, fees.Employee.FeeTotals.Gross);
            Assert.AreEqual(TestData.EmployeeFees.Net, fees.Employee.FeeTotals.Net);
        }

        [TestMethod]
        public void GetFees_ReturnsDependentFees()
        {
            _calculationService.Setup(s => s.CalculateFees(It.IsAny<Employee>()))
                .Returns(TestData.EmployeeFees);

            _calculationService.Setup(s => s.CalculateFees(It.IsAny<Dependent>()))
                .Returns(TestData.DependentFees);

            var fees = _feesService.GetFees(TestData.FeesRequestWithDependents);

            Assert.AreEqual(TestData.DependentFees.Discount, fees.Dependents[0].FeeTotals.Discount);
            Assert.AreEqual(TestData.DependentFees.Gross, fees.Dependents[0].FeeTotals.Gross);
            Assert.AreEqual(TestData.DependentFees.Net, fees.Dependents[0].FeeTotals.Net);
        }

        [TestMethod]
        public void GetFees_ReturnsCombinedFees_ForEmployeeAndDependents()
        {
            _calculationService.Setup(s => s.CalculateFees(It.IsAny<Employee>()))
                .Returns(TestData.EmployeeFees);

            _calculationService.Setup(s => s.CalculateFees(It.IsAny<Dependent>()))
                .Returns(TestData.DependentFees);

            var fees = _feesService.GetFees(TestData.FeesRequestWithDependents);

            Assert.AreEqual(0, fees.FeeTotals.Discount);
            Assert.AreEqual(76.92, fees.FeeTotals.Gross);
            Assert.AreEqual(76.92, fees.FeeTotals.Net);
        }

    }
}
