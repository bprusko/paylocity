using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Paylocity.Api.Calculators;

namespace Paylocity.Api.Models {

    public class Dependent: IBenefitsSubject {

        [Required(ErrorMessage ="First name is required to calculate dependent deductions.")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        public DeductionCalculator GetCalculator () {
            return new DependentCalculator();
        }

    }

}