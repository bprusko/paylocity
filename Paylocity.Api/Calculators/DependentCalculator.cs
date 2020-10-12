namespace Paylocity.Api.Calculators
{
    public class DependentCalculator: DeductionCalculator {

        public override double BaseAnnualDeduction
        {
            get
            {
                return 500;
            }
        }

    }

}