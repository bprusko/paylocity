using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paylocity.Api.Models;
using Paylocity.Api.ViewModels;
using Dependent = Paylocity.Api.ViewModels.Dependent;
using Employee = Paylocity.Api.ViewModels.Employee;
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
        public Paycheck GetDeductions([FromBody] PaycheckRequest feeRequest)
        {
            return _paycheckService.GetPaycheck(feeRequest);
        }

        [HttpGet]
        [Route("fees")]
        public Paycheck GetFeesOld()
        {
            return new Paycheck
            {
                Dependents = new List<Dependent> {
                    new Dependent {
                        FirstName = "Dependent11",
                        Deductions = new ViewModels.Deduction{
                            Discount = 50,
                            Gross = 500
                        },
                    },
                    new Dependent {
                        FirstName = "Dependent22",
                        Deductions = new ViewModels.Deduction{
                            Discount = 0,
                            Gross = 500
                        },
                    }
                },
                Employee = new Employee
                {
                    FirstName = "Piers",
                    LastName = "Morgan",
                    Deductions = new ViewModels.Deduction {
                        Discount = 0,
                        Gross = 1000
                    }
                }
            };
        }
    }
}
