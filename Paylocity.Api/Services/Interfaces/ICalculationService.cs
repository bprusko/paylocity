using Paylocity.Api.Models;

namespace Paylocity.Api.Services.Interfaces
{

    public interface ICalculationService {

        Deduction CalculateDeductions(IBenefitsSubject benefitsSubject);

    }

}