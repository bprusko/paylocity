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
    [Route("api/v1/benefits/")]
    public class BenefitsController : ControllerBase
    {
        private readonly IFeesService _feesService;

        private readonly ILogger<BenefitsController> _logger;

        public BenefitsController(ILogger<BenefitsController> logger, IFeesService feesService)
        {
            _logger = logger;
            _feesService = feesService;
        }

        [HttpPost]
        [Route("fees")]
        public FeeInfo CalculateFees([FromBody] FeesRequest feeRequest)
        {
            return _feesService.GetFees(feeRequest);
        }

        [HttpGet]
        [Route("fees")]
        public FeeInfo GetFeesOld()
        {
            return new FeeInfo {
                Dependents = new List<Dependent> {
                    new Dependent {
                        FirstName = "Dependent11",
                        FeeTotals = new FeeTotal{
                            Discount = 50,
                            Gross = 500,
                            Net = 450
                        },
                    },
                    new Dependent {
                        FirstName = "Dependent22",
                        FeeTotals = new FeeTotal{
                            Discount = 0,
                            Gross = 500,
                            Net = 500
                        },
                    }
                },
                Employee = new Employee {
                    FirstName = "Piers",
                    LastName = "Morgan",
                    FeeTotals = new FeeTotal {
                        Discount = 0,
                        Gross = 1000,
                        Net = 1000
                    }
                },
                FeeTotals = new FeeTotal {
                    Discount = 50,
                    Gross = 2000,
                    Net = 1950
                }
            };
        }
    }
}
