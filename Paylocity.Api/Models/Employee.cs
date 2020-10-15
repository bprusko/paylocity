using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Paylocity.Api.Calculators;

namespace Paylocity.Api.Models {

    public class Employee: IBenefitsSubject {

        [JsonProperty("firstName")]
        [Required(ErrorMessage ="First name is required to calculate employee deductions.")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        public DeductionCalculator GetCalculator () {
            return new EmployeeCalculator();
        }

    }

}