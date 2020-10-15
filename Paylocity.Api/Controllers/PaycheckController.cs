using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paylocity.Api.Models;
using Paylocity.Api.Services.Interfaces;

namespace Paylocity.Api.Controllers
{
    [ApiController]
    [Route("api/v1/paycheck/")]
    public class PaycheckController : ControllerBase
    {
        private readonly IPaycheckService _paycheckService;

        private readonly ILogger<PaycheckController> _logger;

        public PaycheckController(ILogger<PaycheckController> logger, IPaycheckService paycheckService)
        {
            _logger = logger;
            _paycheckService = paycheckService;
        }

        [HttpPost]
        [Route("deductions")]
        public IActionResult GetDeductions([FromBody] DeductionsRequest deductionsRequest)
        {
            try {
                var paycheck = _paycheckService.GetPaycheckWithDeductions(deductionsRequest);
                _logger.LogInformation("[PAYCHECK CONTROLLER][GET DEDUCTIONS][SUCCESS]");
                return new OkObjectResult(paycheck);
            }
            catch (Exception ex){
                _logger.LogError(ex, "[PAYCHECK CONTROLLER][GET DEDUCTIONS][FAILED]");
                return StatusCode(500);
            }
        }

    }
}
