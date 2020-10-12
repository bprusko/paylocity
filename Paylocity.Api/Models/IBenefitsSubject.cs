using Paylocity.Api.Calculators;

namespace Paylocity.Api.Models {

    public interface IBenefitsSubject {

        string FirstName { get; set; }
        string LastName { get; set; }

        DeductionCalculator GetCalculator();

    }

}