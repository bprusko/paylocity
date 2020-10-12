namespace Paylocity.Api.Calculators
{
    public class EmployeeCalculator : DeductionCalculator {

        public override double BaseAnnualDeduction
        {
            get
            {
                return 1000;
            }
        }

    }

}