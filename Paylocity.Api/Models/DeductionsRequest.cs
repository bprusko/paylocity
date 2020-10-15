using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Paylocity.Api.Models {

    public class DeductionsRequest {

        [JsonProperty("employee")]
        [FromBody, ModelBinder(Name= "employee")]
        [Required(ErrorMessage ="Employee is required to calculate deductions.")]
        public Employee Employee { get; set; }

        [JsonProperty("dependents")]
        public List<Dependent> Dependents { get; set; }

    }

}