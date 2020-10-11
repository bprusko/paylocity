using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Paylocity.Api.Models;
using Paylocity.Api.Services.Interfaces;
using Paylocity.Api.Controllers;
using Moq;

namespace Paylocity.Api.Tests
{
    [TestClass]
    public class BenefitsControllerTest
    {
        private BenefitsController _benefitsController;
        private Mock<IFeesService> _feesService;

        private Mock<ILogger<BenefitsController>> _logger;

        [TestInitialize]
        public void SetUp()
        {
            _feesService = new Mock<IFeesService>();
            _logger = new Mock<ILogger<BenefitsController>>();
            _benefitsController = new BenefitsController(_logger.Object, _feesService.Object);
        }

        [TestMethod]
        public void CalculateFees_ReturnsFeeInfo()
        {
            _feesService.Setup(s => s.GetFees(It.IsAny<FeesRequest>()))
                .Returns(TestData.FeeInfo);

            var result = _benefitsController.CalculateFees(TestData.FeesRequestWithDependents);

            Assert.AreEqual(JsonConvert.SerializeObject(TestData.FeeInfo),
                JsonConvert.SerializeObject(result));
        }
    }
}
