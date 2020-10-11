using Newtonsoft.Json;
using Paylocity.Api.Calculators;

namespace Paylocity.Api.Models {

    public class Employee: IBenefitsSubject {

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        public FeeCalculator GetCalculator () {
            return new EmployeeCalculator();
        }

    }

}