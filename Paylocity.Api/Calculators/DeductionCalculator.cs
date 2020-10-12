using System;
using Paylocity.Api.Models;

namespace Paylocity.Api.Calculators
{

    public abstract class DeductionCalculator {

        public abstract double BaseAnnualDeduction { get; }

        private double BiweeklyPayPeriods = 26;

        public Deduction CalculateDeductions(string firstName) {

            var deduction = new Deduction {
                Discount = 0,
                Gross = BaseBiweeklyDeduction
            };

            if(IsEligibleForDiscount(firstName)){
                deduction.Discount = CalculateDiscount();
            }

            return deduction;
        }

        private double BaseBiweeklyDeduction => Math.Round(BaseAnnualDeduction/BiweeklyPayPeriods, 2);

        private bool IsEligibleForDiscount(string firstName) {
            return firstName.ToLower().StartsWith("a");
        }

        private double CalculateDiscount() {
            return Math.Round(BaseBiweeklyDeduction * .1, 2);
        }

    }

}