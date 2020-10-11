using System.Collections.Generic;
using Newtonsoft.Json;

namespace Paylocity.Api.ViewModels {

    public class FeeInfo {

        [JsonProperty("dependents")]
        public List<Dependent> Dependents { get; set; }

        [JsonProperty("employee")]
        public Employee Employee { get; set; }

        [JsonProperty("feeTotals")]
        public FeeTotal FeeTotals { get; set; }

    }

}