namespace Paylocity.Api.Calculators
{
    public class EmployeeCalculator : FeeCalculator
    {

        public override double BaseAnnualFee
        {
            get
            {
                return 1000;
            }
        }

    }

}