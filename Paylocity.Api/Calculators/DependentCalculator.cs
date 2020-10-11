namespace Paylocity.Api.Calculators
{
    public class DependentCalculator: FeeCalculator {

        public override double BaseAnnualFee
        {
            get
            {
                return 500;
            }
        }

    }

}