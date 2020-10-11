using System.Collections.Generic;
using Newtonsoft.Json;

namespace Paylocity.Api.Models {

    public class FeesRequest {

        [JsonProperty("employee")]
        public Employee Employee { get; set; }

        [JsonProperty("dependents")]
        public List<Dependent> Dependents { get; set; }

    }

}