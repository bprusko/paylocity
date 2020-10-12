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
        public void CalculateFees_ReturnsFeeInfo()
        {
            _paycheckService.Setup(s => s.GetPaycheck(It.IsAny<PaycheckRequest>()))
                .Returns(TestData.Paycheck);

            var result = _paycheckController.GetDeductions(TestData.PaycheckRequestWithDependents);

            Assert.AreEqual(JsonConvert.SerializeObject(TestData.Paycheck),
                JsonConvert.SerializeObject(result));
        }
    }
}
