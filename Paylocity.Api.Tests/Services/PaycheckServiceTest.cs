using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Api.Services.Interfaces;
using Paylocity.Api.Services;
using Paylocity.Api.Models;
using Moq;

namespace Paylocity.Api.Tests
{

    [TestClass]
    public class PaycheckServiceTest
    {
        private Mock<ICalculationService> _calculationService;
        private PaycheckService _paycheckService;

        [TestInitialize]
        public void SetUp()
        {
            _calculationService = new Mock<ICalculationService>();
            _paycheckService = new PaycheckService(_calculationService.Object);
        }

        [TestMethod]
        public void GetPaycheck_CallsCalculateDeductions_ForEmployeeAndEachDependent()
        {
            _calculationService.Setup(s => s.CalculateDeductions(It.IsAny<Employee>()))
                .Returns(TestData.EmployeeDeductions);

            _calculationService.Setup(s => s.CalculateDeductions(It.IsAny<Dependent>()))
                .Returns(TestData.DependentDeductions);

            var fees = _paycheckService.GetPaycheck(TestData.PaycheckRequestWithDependents);

            _calculationService.Verify(c => c.CalculateDeductions(It.IsAny<Employee>()), Times.Once);

            var numberDependents = TestData.PaycheckRequestWithDependents.Dependents.Count;
            _calculationService.Verify(c => c.CalculateDeductions(It.IsAny<Dependent>()), Times.Exactly(numberDependents));
        }

        [TestMethod]
        public void GetPaycheck_CallsCalculateDeductionsForOnlyEmployee_WhenThereAreNoDependents()
        {
            _calculationService.Setup(s => s.CalculateDeductions(It.IsAny<Employee>()))
                .Returns(TestData.EmployeeDeductions);

            var fees = _paycheckService.GetPaycheck(TestData.PaycheckRequest);

            _calculationService.Verify(c => c.CalculateDeductions(It.IsAny<Employee>()), Times.Once);

            _calculationService.Verify(c => c.CalculateDeductions(It.IsAny<Dependent>()),
                Times.Never);
        }

        [TestMethod]
        public void GetPaycheck_ReturnsEmployeeDeductions()
        {
            _calculationService.Setup(s => s.CalculateDeductions(It.IsAny<Employee>()))
                .Returns(TestData.EmployeeDeductions);

            _calculationService.Setup(s => s.CalculateDeductions(It.IsAny<Dependent>()))
                .Returns(TestData.DependentDeductions);

            var fees = _paycheckService.GetPaycheck(TestData.PaycheckRequest);

            Assert.AreEqual(TestData.EmployeeDeductions.Discount, fees.Employee.Deductions.Discount);
            Assert.AreEqual(TestData.EmployeeDeductions.Gross, fees.Employee.Deductions.Gross);
            Assert.AreEqual(TestData.EmployeeDeductions.Net, fees.Employee.Deductions.Net);
        }

        [TestMethod]
        public void GetPaycheck_ReturnsDependentDeductions()
        {
            _calculationService.Setup(s => s.CalculateDeductions(It.IsAny<Employee>()))
                .Returns(TestData.EmployeeDeductions);

            _calculationService.Setup(s => s.CalculateDeductions(It.IsAny<Dependent>()))
                .Returns(TestData.DependentDeductions);

            var fees = _paycheckService.GetPaycheck(TestData.PaycheckRequestWithDependents);

            Assert.AreEqual(TestData.DependentDeductions.Discount, fees.Dependents[0].Deductions.Discount);
            Assert.AreEqual(TestData.DependentDeductions.Gross, fees.Dependents[0].Deductions.Gross);
            Assert.AreEqual(TestData.DependentDeductions.Net, fees.Dependents[0].Deductions.Net);
        }

        [TestMethod]
        public void GetPaycheck_ReturnsCombinedDeductions_ForEmployeeAndDependents()
        {
            _calculationService.Setup(s => s.CalculateDeductions(It.IsAny<Employee>()))
                .Returns(TestData.EmployeeDeductions);

            _calculationService.Setup(s => s.CalculateDeductions(It.IsAny<Dependent>()))
                .Returns(TestData.DependentDeductions);

            var fees = _paycheckService.GetPaycheck(TestData.PaycheckRequestWithDependents);

            Assert.AreEqual(0, fees.TotalDeductions.Discount);
            Assert.AreEqual(76.92, fees.TotalDeductions.Gross);
            Assert.AreEqual(76.92, fees.TotalDeductions.Net);
        }

    }
}
