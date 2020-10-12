namespace Paylocity.Api.Calculators
{
    public class DependentCalculator: FeeCalculator {

        public override double BaseAnnualDeduction
        {
            get
            {
                return 500;
            }
        }

    }

}