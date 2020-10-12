using Paylocity.Api.Services.Interfaces;
using Paylocity.Api.Models;

namespace Paylocity.Api.Services
{

    public class CalculationService: ICalculationService {

        public Deduction CalculateDeductions (IBenefitsSubject benefitsSubject) {
            var calculator = benefitsSubject.GetCalculator();
            return calculator.CalculateDeductions(benefitsSubject.FirstName);
        }

    }

}