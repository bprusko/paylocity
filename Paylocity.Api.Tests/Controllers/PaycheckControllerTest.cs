using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Paylocity.Api.Models;
using Paylocity.Api.Services.Interfaces;
using Paylocity.Api.Controllers;
using Moq;

namespace Paylocity.Api.Tests
{
    [TestClass]
    public class PaycheckControllerTest
    {
        private PaycheckController _paycheckController;
        private Mock<IPaycheckService> _paycheckService;

        private Mock<ILogger<PaycheckController>> _logger;

        [TestInitialize]
        public void SetUp()
        {
            _paycheckService = new Mock<IPaycheckService>();
            _logger = new Mock<ILogger<PaycheckController>>();
            _paycheckController = new PaycheckController(_logger.Object, _paycheckService.Object);
        }

        [TestMethod]
        public void CalculateDeductions_ReturnsPaycheckWithDeductions()
        {
            _paycheckService.Setup(s => s.GetPaycheckWithDeductions(It.IsAny<DeductionsRequest>()))
                .Returns(TestData.Paycheck);

            var result = _paycheckController.GetDeductions(TestData.PaycheckRequestWithDependents);
            var okResult = result as OkObjectResult;

            _paycheckService.Verify(c => c.GetPaycheckWithDeductions(TestData.PaycheckRequestWithDependents),
                Times.Once);
            Assert.AreEqual(JsonConvert.SerializeObject(TestData.Paycheck),
                JsonConvert.SerializeObject(okResult.Value));
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
