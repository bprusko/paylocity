using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Paylocity.Api.ViewModels
{

    public class Paycheck
    {

        [JsonProperty("biweeklyBase")]
        public double BiweeklyBase
        {
            get
            {
                return 2000;
            }
        }

        [JsonProperty("dependents")]
        public List<Dependent> Dependents { get; set; }

        [JsonProperty("employee")]
        public Employee Employee { get; set; }

        [JsonProperty("netPay")]
        public double NetPay
        {
            get
            {
                return BiweeklyBase - TotalDeductions.Net;
            }
        }

        [JsonProperty("totalDeductions")]
        public Deduction TotalDeductions
        {
            get
            {
                var totalDeductions = new Deduction {
                    Discount = Employee.Deductions.Discount,
                    Gross = Employee.Deductions.Gross
                };

                if (Dependents?.Count > 0)
                {
                    var dependentDiscounts = Dependents.Select(d => d.Deductions.Discount).Sum();
                    var dependentGross = Dependents.Select(d => d.Deductions.Gross).Sum();
                    totalDeductions.Discount += dependentDiscounts;
                    totalDeductions.Gross += dependentGross;
                }

                return totalDeductions;
            }
        }

    }

}