using System;
using Newtonsoft.Json;

namespace Paylocity.Api.Models
{

    public class Deduction
    {

        [JsonProperty("discount")]
        public double Discount { get; set; }

        [JsonProperty("gross")]
        public double Gross { get; set; }

        [JsonProperty("net")]
        public double Net
        {
            get
            {
                return Math.Round(Gross - Discount, 2);
            }
        }

    }

}
