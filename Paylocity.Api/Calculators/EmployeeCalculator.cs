namespace Paylocity.Api.Calculators
{
    public class EmployeeCalculator : FeeCalculator {

        public override double BaseAnnualDeduction
        {
            get
            {
                return 1000;
            }
        }

    }

}