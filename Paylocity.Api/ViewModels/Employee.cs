using Newtonsoft.Json;

namespace Paylocity.Api.ViewModels {

    public class Employee {

        [JsonProperty("deductions")]
        public Deduction Deductions { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

    }

}