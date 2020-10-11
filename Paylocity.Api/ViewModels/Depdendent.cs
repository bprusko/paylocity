using Newtonsoft.Json;

namespace Paylocity.Api.ViewModels {

    public class Dependent {

        [JsonProperty("feeTotals")]
        public FeeTotal FeeTotals { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

    }

}