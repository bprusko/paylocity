using Paylocity.Api.Models;

namespace Paylocity.Api.Services.Interfaces
{

    public interface ICalculationService {

        Fees CalculateFees(IBenefitsSubject benefitsSubject);

    }

}