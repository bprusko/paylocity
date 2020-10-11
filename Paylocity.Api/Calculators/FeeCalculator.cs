using System;
using Paylocity.Api.Models;

namespace Paylocity.Api.Calculators
{

    public abstract class FeeCalculator {

        public abstract double BaseAnnualFee { get; }

        private double BiweeklyPayPeriods = 26;

        public Fees CalculateDeductions(string firstName) {

            var fees = new Fees {
                Discount = 0,
                Gross = BaseBiweeklyDeduction,
                Net = BaseBiweeklyDeduction
            };

            if(IsEligibleForDiscount(firstName)){
                fees.Discount = CalculateDiscount();
                fees.Net = CalculateNetDiscountedRate();
            }

            return fees;
        }

        private double BaseBiweeklyDeduction => Math.Round(BaseAnnualFee/BiweeklyPayPeriods, 2);

        private bool IsEligibleForDiscount(string firstName) {
            return firstName.ToLower().StartsWith("a");
        }

        private double CalculateDiscount() {
            return Calculate(.1);
        }

        private double CalculateNetDiscountedRate() {
            return Calculate(.9);
        }

        private double Calculate(double rate) {
            return Math.Round(BaseBiweeklyDeduction * rate, 2);
        }

    }

}